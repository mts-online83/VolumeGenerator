using Aspose.Words;
using Aspose.Words.Layout;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace VolumeGenerator
{
    public class VolumeService
    {
        public List<MergeEntry> LastMergeEntries { get; private set; } = new();
        public string? LastMergedDocumentPath { get; private set; }

        // Stores per-volume date + transcriber info:
        //   "Volume_1.docx" -> ["04/09/2021||Transcriber One", "04/10/2021||Transcriber Two", ...]
        public Dictionary<string, List<string>> VolumeDateTranscriberData { get; private set; }
            = new Dictionary<string, List<string>>();

        public string MergeWordDocsInFolder(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                throw new ArgumentException("folderPath is required.", nameof(folderPath));

            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException($"Folder not found: {folderPath}");

            var files = Directory.GetFiles(folderPath, "*.docx");
            if (files.Length == 0)
                throw new InvalidOperationException("No .docx files found in the selected folder.");

            var list = new List<(DateTime SortDate, string Path)>();

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string[] parts = fileName.Split('_');

                DateTime sortDate;

                if (parts.Length >= 2)
                {
                    string datePart = parts[1].Replace("-", "/");
                    if (!DateTime.TryParse(datePart, out sortDate))
                    {
                        sortDate = DateTime.MaxValue;
                    }
                }
                else
                {
                    sortDate = DateTime.MaxValue;
                }

                list.Add((sortDate, file));
            }

            var ordered = list
                .OrderBy(t => t.SortDate)
                .ThenBy(t => Path.GetFileName(t.Path))
                .ToList();

            // 1) Use the first ordered document as the base
            var firstItem = ordered[0];
            var mergedDoc = new Document(firstItem.Path);
            mergedDoc.UpdatePageLayout();
            int firstDocPages = mergedDoc.PageCount;

            // 2) Prepare results list and page tracking
            var results = new List<MergeEntry>();

            int runningPage = 0;

            // Add entry for the first (base) document
            var firstEntry = new MergeEntry
            {
                FileName = Path.GetFileName(firstItem.Path),
                FullPath = firstItem.Path,
                SortDate = firstItem.SortDate,
                PageCount = firstDocPages,
                StartPage = 1,
                EndPage = firstDocPages
            };
            results.Add(firstEntry);

            runningPage = firstDocPages;

            // 3) Create a builder on the base doc and move to the end
            var builder = new DocumentBuilder(mergedDoc);
            builder.MoveToDocumentEnd();

            // 4) Append remaining documents with page breaks
            for (int idx = 1; idx < ordered.Count; idx++)
            {
                var item = ordered[idx];

                var docToInsert = new Document(item.Path);
                docToInsert.UpdatePageLayout();
                int pages = docToInsert.PageCount;

                // Insert a page break before each appended doc
                builder.InsertBreak(BreakType.PageBreak);
                builder.InsertDocument(docToInsert, ImportFormatMode.KeepSourceFormatting);

                var entry = new MergeEntry
                {
                    FileName = Path.GetFileName(item.Path),
                    FullPath = item.Path,
                    SortDate = item.SortDate,
                    PageCount = pages,
                    StartPage = runningPage + 1,
                    EndPage = runningPage + pages
                };

                results.Add(entry);
                runningPage += pages;
            }

            string outputPath = Path.Combine(folderPath, "MERGED_DOC.docx");
            mergedDoc.Save(outputPath, SaveFormat.Docx);

            LastMergeEntries = results;
            LastMergedDocumentPath = outputPath;

            return outputPath;
        }

        /// <summary>
        /// Splits a merged document into volumes where each volume's total pages
        /// does not exceed maxPages, unless a single hearing itself exceeds maxPages.
        /// In that case, that hearing becomes its own volume and may exceed maxPages.
        /// 
        /// The method assumes entries are in the same order as in the merged document.
        /// </summary>
        public List<VolumeInfo> SplitMergedDocumentIntoVolumes(
            string mergedDocPath,
            IList<MergeEntry> orderedEntries,
            int maxPages,
            string? outputFolder = null)
        {
            if (string.IsNullOrWhiteSpace(mergedDocPath))
                throw new ArgumentException("mergedDocPath is required.", nameof(mergedDocPath));

            if (!File.Exists(mergedDocPath))
                throw new FileNotFoundException("Merged document not found.", mergedDocPath);

            if (orderedEntries == null || orderedEntries.Count == 0)
                throw new ArgumentException("orderedEntries is empty.", nameof(orderedEntries));

            if (maxPages <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxPages), "maxPages must be > 0.");

            if (outputFolder == null)
                outputFolder = Path.GetDirectoryName(mergedDocPath)
                                ?? throw new InvalidOperationException("Could not determine output folder.");

            Directory.CreateDirectory(outputFolder);

            var mergedDoc = new Document(mergedDocPath);
            mergedDoc.UpdatePageLayout();

            var volumes = new List<VolumeInfo>();

            int volumeNumber = 1;
            int currentVolumePages = 0;
            var currentEntries = new List<MergeEntry>();

            foreach (var entry in orderedEntries)
            {
                // If this single hearing exceeds maxPages,
                // it must be its own volume (cannot split a hearing).
                if (entry.PageCount > maxPages)
                {
                    // If we already have some entries in current volume, close that volume first.
                    if (currentEntries.Count > 0)
                    {
                        volumes.Add(CreateVolumeFromEntries(
                            mergedDoc,
                            currentEntries,
                            volumeNumber++,
                            outputFolder));
                        currentEntries.Clear();
                        currentVolumePages = 0;
                    }

                    // This entry alone becomes a volume.
                    volumes.Add(CreateVolumeFromEntries(
                        mergedDoc,
                        new List<MergeEntry> { entry },
                        volumeNumber++,
                        outputFolder));

                    continue;
                }

                // If adding this entry would exceed maxPages, close current volume and start a new one.
                if (currentVolumePages + entry.PageCount > maxPages && currentEntries.Count > 0)
                {
                    volumes.Add(CreateVolumeFromEntries(
                        mergedDoc,
                        currentEntries,
                        volumeNumber++,
                        outputFolder));

                    currentEntries = new List<MergeEntry>();
                    currentVolumePages = 0;
                }

                currentEntries.Add(entry);
                currentVolumePages += entry.PageCount;
            }

            // Close final volume if any entries remain
            if (currentEntries.Count > 0)
            {
                volumes.Add(CreateVolumeFromEntries(
                    mergedDoc,
                    currentEntries,
                    volumeNumber++,
                    outputFolder));
            }

            return volumes;
        }

        private VolumeInfo CreateVolumeFromEntries(
            Document mergedDoc,
            List<MergeEntry> entries,
            int volumeNumber,
            string outputFolder)
        {
            if (entries.Count == 0)
                throw new ArgumentException("entries must not be empty.", nameof(entries));

            int startPage = entries.First().StartPage;
            int endPage = entries.Last().EndPage;
            int pageCount = endPage - startPage + 1;

            // Aspose.Words ExtractPages(startIndex, count):
            // startIndex is zero-based page index.
            int startIndex = startPage - 1;

            Document volumeDoc = mergedDoc.ExtractPages(startIndex, pageCount);

            string outputPath = Path.Combine(outputFolder, $"Volume_{volumeNumber}.docx");
            volumeDoc.Save(outputPath, SaveFormat.Docx);

            var info = new VolumeInfo
            {
                VolumeNumber = volumeNumber,
                OutputPath = outputPath,
                StartPage = startPage,
                EndPage = endPage
            };

            info.Entries.AddRange(entries);

            return info;
        }

        public List<VolumeInfo> SplitLastMergedIntoVolumes(int maxPages, string? outputFolder = null)
        {
            if (LastMergedDocumentPath == null)
                throw new InvalidOperationException("No merged document found. Run MergeWordDocsInFolder first.");

            if (LastMergeEntries == null || LastMergeEntries.Count == 0)
                throw new InvalidOperationException("No merge entry data found. Run MergeWordDocsInFolder first.");

            return SplitMergedDocumentIntoVolumes(
                LastMergedDocumentPath,
                LastMergeEntries,
                maxPages,
                outputFolder);
        }

        /// <summary>
        /// For a given Volume_#.docx:
        /// 1) Finds each "commencing on the ..." occurrence, extracts the date,
        ///    converts to MM/dd/yyyy and stores as the first part of an entry.
        /// 2) Finds each line containing TAB + "Date" and extracts the transcriber's name
        ///    (text before the first TAB).
        /// 3) Appends "||Transcriber Name" to each entry in order.
        /// 
        /// Returns entries like: "04/09/2021||Jane Smith".
        /// Also stores them in VolumeDateTranscriberData keyed by file name.
        /// </summary>
        public List<string> GetDateAndTranscriberForVolume(string volumeDocPath, VolumeInfo volumeInfo)
        {
            var doc = new Document(volumeDocPath);
            doc.UpdatePageLayout();

            var collector = new LayoutCollector(doc);

            var results = new List<string>();

            foreach (var entry in volumeInfo.Entries.OrderBy(e => e.StartPage))
            {
                // Convert merged-global pages to volume-local pages
                int localStart = entry.StartPage - volumeInfo.StartPage + 1;
                int localEnd = entry.EndPage - volumeInfo.StartPage + 1;

                string transcriber = FindFirstTranscriberInPageRange(doc, collector, localStart, localEnd);

                // If nothing found, keep blank (or default to "escribers" if you prefer)
                string dateStr = entry.SortDate.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);

                results.Add($"{dateStr}||{transcriber}".TrimEnd('|'));
            }

            return results;
        }

        private string FindFirstTranscriberInPageRange(Document doc, LayoutCollector collector, int startPage, int endPage)
        {
            foreach (Paragraph para in doc.GetChildNodes(NodeType.Paragraph, true))
            {
                int page = collector.GetStartPageIndex(para);
                if (page < startPage || page > endPage)
                    continue;

                string line = para.ToString(SaveFormat.Text).Trim();

                // match: vbTab & "Date"
                if (line.IndexOf("\tDate", StringComparison.OrdinalIgnoreCase) < 0)
                    continue;

                // first value before tab is the transcriber name
                string[] parts = line.Split('\t');
                if (parts.Length > 0)
                {
                    string name = parts[0].Trim();
                    if (!string.IsNullOrWhiteSpace(name))
                        return name; // FIRST match in that hearing’s page range
                }
            }

            return ""; // not found for that hearing
        }

        private static DateTime? ParseHearingDate(string rawText)
        {
            if (string.IsNullOrWhiteSpace(rawText))
                return null;

            // e.g. "9th day of April 2021" or "9th day of April, 2021."
            var text = rawText.Trim();

            // Remove common words
            text = text.Replace("day of", "", StringComparison.OrdinalIgnoreCase);
            text = text.Replace("the", "", StringComparison.OrdinalIgnoreCase);
            text = text.Replace(",", "");   // remove commas
            text = text.Replace(".", "");   // remove trailing period if any

            // Remove ordinal suffixes from day ("st", "nd", "rd", "th")
            text = System.Text.RegularExpressions.Regex.Replace(
                text,
                @"\b(\d+)(st|nd|rd|th)\b",
                "$1",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " "); // normalize spaces
            text = text.Trim();

            // At this point, aim for something like "9 April 2021"
            string[] formats =
            {
                "d MMMM yyyy",
                "dd MMMM yyyy",
                "d MMM yyyy",
                "dd MMM yyyy"
            };

            if (DateTime.TryParseExact(
                    text,
                    formats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var result))
            {
                return result;
            }

            // As a fallback, try a generic parse
            if (DateTime.TryParse(text, out result))
                return result;

            return null;
        }

    }
}
