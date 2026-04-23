using Aspose.Words;
using Aspose.Words.Layout;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace VolumeGeneratorApp.Oregon
{
    public class OregonCaptionScraper
    {
        public OregonCaptionData ParseFirstPage(string mergedDocPath)
        {
            if (string.IsNullOrWhiteSpace(mergedDocPath))
                throw new ArgumentException("mergedDocPath is required.", nameof(mergedDocPath));

            var doc = new Document(mergedDocPath);
            doc.UpdatePageLayout();

            var collector = new LayoutCollector(doc);

            // 1) COUNTY comes from normal paragraphs on page 1
            var page1Paragraphs = doc.GetChildNodes(NodeType.Paragraph, true)
                .OfType<Paragraph>()
                .Where(p => collector.GetStartPageIndex(p) == 1)
                .Select(p => p.ToString(SaveFormat.Text).Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .ToList();

            string county = "";
            var countyLine = page1Paragraphs.FirstOrDefault(x =>
                x.StartsWith("FOR THE COUNTY OF", StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(countyLine))
            {
                county = countyLine
                    .Replace("FOR THE COUNTY OF", "", StringComparison.OrdinalIgnoreCase)
                    .Trim();

                county = ToTitleCaseSafe(county);
            }

            // 2) Everything else comes from the caption table
            var captionTable = FindCaptionTableOnFirstPage(doc, collector);

            string caseNo = "";
            string appealNo = "";
            string name1 = "";
            string name2 = "";
            string party1 = "";
            string party2 = "";

            if (captionTable != null)
            {
                var tableLines = GetLinesFromTable(captionTable);

                // Court No.
                var courtLine = tableLines.FirstOrDefault(x =>
                    x.StartsWith("Court No.", StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(courtLine))
                {
                    caseNo = Regex.Replace(
                        courtLine,
                        @"^Court No\.?\s*:?\s*",
                        "",
                        RegexOptions.IgnoreCase).Trim();
                }

                // Appeal No.
                var appealLine = tableLines.FirstOrDefault(x =>
                    x.StartsWith("Appeal No.", StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(appealLine))
                {
                    appealNo = Regex.Replace(
                        appealLine,
                        @"^Appeal No\.?\s*:?\s*",
                        "",
                        RegexOptions.IgnoreCase).Trim();
                }

                // Split around vs. / v.
                int vsIndex = tableLines.FindIndex(x =>
                    x.Equals("vs.", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("v.", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("vs", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("v", StringComparison.OrdinalIgnoreCase));

                if (vsIndex >= 0)
                {
                    var topBlock = tableLines.Take(vsIndex).ToList();

                    var bottomBlock = tableLines.Skip(vsIndex + 1)
                        .TakeWhile(x =>
                            !x.StartsWith("Court No.", StringComparison.OrdinalIgnoreCase) &&
                            !x.StartsWith("Appeal No.", StringComparison.OrdinalIgnoreCase) &&
                            !x.Contains("TRANSCRIPT OF PROCEEDINGS", StringComparison.OrdinalIgnoreCase) &&
                            !x.Contains("HEARING", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    ParsePartyBlock(topBlock, out name1, out party1);
                    ParsePartyBlock(bottomBlock, out name2, out party2);
                }
            }

            return new OregonCaptionData
            {
                County = county,
                Name1 = name1,
                Name2 = name2,
                Party1 = party1,
                Party2 = party2,
                CaseNumber = caseNo,
                AppealNumber = appealNo
            };
        }

        private Table? FindCaptionTableOnFirstPage(Document doc, LayoutCollector collector)
        {
            return doc.GetChildNodes(NodeType.Table, true)
                .OfType<Table>()
                .FirstOrDefault(t =>
                    collector.GetStartPageIndex(t.FirstRow) == 1 &&
                    (
                        t.ToString(SaveFormat.Text).IndexOf("vs.", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        t.ToString(SaveFormat.Text).IndexOf("v.", StringComparison.OrdinalIgnoreCase) >= 0
                    ));
        }

        private List<string> GetLinesFromTable(Table table)
        {
            var lines = new List<string>();

            foreach (Row row in table.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    foreach (Paragraph para in cell.Paragraphs)
                    {
                        string text = para.ToString(SaveFormat.Text).Trim();
                        if (!string.IsNullOrWhiteSpace(text))
                            lines.Add(text);
                    }
                }
            }

            return lines;
        }

        private void ParsePartyBlock(List<string> block, out string name, out string party)
        {
            name = "";
            party = "";

            if (block == null || block.Count == 0)
                return;

            // Clean lines
            var cleaned = block
                .Select(x => x?.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if (cleaned.Count == 0)
                return;

            // The last non-empty line is the party type
            party = cleaned.Last().Trim().TrimEnd(',', '.');

            // Everything before that is the party name
            if (cleaned.Count > 1)
            {
                name = string.Join(" ", cleaned.Take(cleaned.Count - 1))
                .Trim()
                .TrimEnd(',', '.');
            }
            else
            {
                name = "";
            }
        }

        private static string ToTitleCaseSafe(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}