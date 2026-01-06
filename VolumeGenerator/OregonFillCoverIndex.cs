using Aspose.Words;
using Aspose.Words.Layout;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeGenerator
{
    public class OregonFillCoverIndex
    {
        /// <summary>
        /// Updates the cover and index pages for each volume in the merged document,
        /// using volume, date, and page range information.
        /// </summary>
        /// <param name="mergedDocPath">Full path to MERGED_DOC.docx.</param>
        /// <param name="volumes">List of VolumeInfo created during splitting.</param>
        public void ProcessAllVolumeDocs(List<VolumeInfo> volumes, string appealNumber)
        {
            if (volumes == null || volumes.Count == 0)
                throw new ArgumentException("volumes must not be empty.", nameof(volumes));

            if (string.IsNullOrWhiteSpace(appealNumber))
                throw new ArgumentException("appealNumber is required.", nameof(appealNumber));

            int totalVolumes = volumes.Count;

            foreach (var vol in volumes)
            {
                if (string.IsNullOrWhiteSpace(vol.OutputPath) || !File.Exists(vol.OutputPath))
                    continue;

                // Determine volume date range (from entries)
                // Using SortDate as the hearing date you already extracted from filenames.
                var orderedEntries = vol.Entries
                    .OrderBy(e => e.SortDate)
                    .ToList();

                DateTime startDate = orderedEntries.First().SortDate;
                DateTime endDate = orderedEntries.Last().SortDate;

                // Build filename: appeal_transcript_vol X_yyyy-mm-ddtoyyyy-mm-dd_escribers.docx
                string safeAppeal = MakeSafeFilePart(appealNumber);

                string startStr = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                string endStr = endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                string newFileName =
                    $"{safeAppeal}_transcript_vol {vol.VolumeNumber}_{startStr}to{endStr}_escribers.docx";

                string folder = Path.GetDirectoryName(vol.OutputPath) ?? "";
                string newPath = Path.Combine(folder, newFileName);

                // Open, update, save to new name
                var doc = new Document(vol.OutputPath);
                doc.UpdatePageLayout();

                UpdateTranscriptHeadingsForVolume(doc, vol, totalVolumes);

                doc.Save(newPath, SaveFormat.Docx);

                // Optional: delete old "Volume_#.docx"
                if (!string.Equals(newPath, vol.OutputPath, StringComparison.OrdinalIgnoreCase))
                {
                    try { File.Delete(vol.OutputPath); } catch { /* ignore */ }
                }

                // Update OutputPath so later steps use the renamed file
                vol.OutputPath = newPath;
            }
        }

        private static string MakeSafeFilePart(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                input = input.Replace(c, '_');

            return input.Trim();
        }

        /// <summary>
        /// Inside a single volume document:
        /// Finds "TRANSCRIPT OF PROCEEDINGS" and, two lines below that heading,
        /// replaces the line with "Volume X of Y (pages A - B)" using the
        /// correct page range for the hearing that starts on that page.
        /// </summary>
        private void UpdateTranscriptHeadingsForVolume(Document volumeDoc, VolumeInfo volume, int totalVolumes)
        {
            var collector = new LayoutCollector(volumeDoc);
            var builder = new DocumentBuilder(volumeDoc);

            foreach (Paragraph para in volumeDoc.GetChildNodes(NodeType.Paragraph, true))
            {
                string text = para.ToString(SaveFormat.Text).Trim();
                if (!text.Equals("TRANSCRIPT OF PROCEEDINGS", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Local page inside this volume doc (1..PageCount)
                int localPage = collector.GetStartPageIndex(para);

                // Convert to global page number (relative to merged doc)
                int globalPage = volume.StartPage + localPage - 1;

                // Find the hearing whose global StartPage matches this global page
                MergeEntry matchingEntry = null;
                foreach (var entry in volume.Entries)
                {
                    if (entry.StartPage == globalPage)
                    {
                        matchingEntry = entry;
                        break;
                    }
                }

                int rangeStart;
                int rangeEnd;

                if (matchingEntry != null)
                {
                    // Use the hearing's global page range
                    rangeStart = matchingEntry.StartPage;
                    rangeEnd = matchingEntry.EndPage;
                }
                else
                {
                    // Fallback: full volume global range
                    rangeStart = volume.StartPage;
                    rangeEnd = volume.EndPage;
                }

                string lineText =
                    $"Volume {volume.VolumeNumber} of {totalVolumes} (pages {rangeStart} - {rangeEnd})";

                // Go two paragraphs down from the heading within the same body
                if (para.ParentNode is not Body body)
                    continue;

                int idx = body.Paragraphs.IndexOf(para);
                int targetIdx = idx + 2; // "move down two lines"

                if (targetIdx >= body.Paragraphs.Count)
                    continue;

                Paragraph targetPara = body.Paragraphs[targetIdx];

                // Clear existing content and replace with our line
                targetPara.RemoveAllChildren();
                builder.MoveTo(targetPara);
                builder.Write(lineText);
            }            
        }
        public void GatherTranscribersForVolumes(List<VolumeInfo> volumes)
        {
            if (volumes == null || volumes.Count == 0)
                throw new ArgumentException("volumes must not be empty.", nameof(volumes));

            foreach (var vol in volumes)
            {
                if (string.IsNullOrWhiteSpace(vol.OutputPath) || !File.Exists(vol.OutputPath))
                    continue;

                var doc = new Document(vol.OutputPath);

                // Store on the VolumeInfo so it's reusable later
                vol.Transcribers = FindTranscribers(doc);
            }
        }
        /// <summary>
        /// Finds all transcriber names by locating lines containing "\tDate"
        /// and taking the text before the first tab on that line.
        /// </summary>
        private List<string> FindTranscribers(Document doc)
        {
            var names = new List<string>();

            foreach (Paragraph para in doc.GetChildNodes(NodeType.Paragraph, true))
            {
                // Get clean text for the whole line
                string line = para.ToString(SaveFormat.Text).Trim();

                // Equivalent to VBA searching for vbTab & "Date"
                if (!line.Contains("\tDate", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Split on tab, take the first chunk
                string[] parts = line.Split('\t');

                if (parts.Length > 0)
                {
                    string firstValue = parts[0].Trim();

                    if (!string.IsNullOrWhiteSpace(firstValue))
                        names.Add(firstValue);
                }
            }

            // Optional: remove duplicates while preserving order
            return names
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

    }
}
