using Aspose.Words;
using Aspose.Words.Layout;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeGeneratorApp.Oregon
{
    public class OregonTimeExtensionDocBuilder
    {
        public string CreateTimeExtensionDocument(
        string outputFolder,
        OregonCaptionData caption,
        OregonWorkFlow appearances)
        {
            if (string.IsNullOrWhiteSpace(outputFolder))
                throw new ArgumentException("outputFolder required.");

            Directory.CreateDirectory(outputFolder);

            string outputPath = Path.Combine(outputFolder, "Request for Extension of Time.docx");

            var doc = new Document();
            var builder = new DocumentBuilder(doc);

            // Global font setting
            doc.Styles[StyleIdentifier.Normal].Font.Name = "Arial";
            doc.Styles[StyleIdentifier.Normal].Font.Size = 11;

            // Start bookmark
            builder.StartBookmark("timeextstart");
            builder.EndBookmark("timeextstart");

            // Header
            SS(builder, true, false);
            TT(builder, "IN THE COURT OF APPEALS OF THE STATE OF OREGON");
            TP(builder, 2);

            // Caption
            InsertCaptionTable(builder, caption);
            builder.MoveToDocumentEnd();
            TP(builder, 4);

            // Title
            SS(builder, true, true);
            TT(builder, "REQUEST BY REPORTER OR TRANSCRIBER FOR TIME EXTENSION");
            TP(builder, 2);
            TT(builder, "FOR PREPARATION OF TRANSCRIPT");
            TP(builder, 2);

            SS(builder, false, false);

            // Body with bookmarks only

            TT(builder, "1.\tI am responsible for preparing a transcript for ");
            InsertBook(builder, "hearing_days");
            TT(builder, " day of proceedings. A transcript of those proceedings will be approximately ");
            InsertBook(builder, "hearing_pages");
            TT(builder, " pages. The transcript was ordered on ");
            InsertBook(builder, "order_date");
            TT(builder, ".");
            TP(builder, 2);

            TT(builder, "2.\tI request an extension of time of ");
            InsertBook(builder, "extension_days");
            TT(builder, " days, from ");
            InsertBook(builder, "extension_start");
            TT(builder, ", through ");
            InsertBook(builder, "extension_end");
            TT(builder, ", within which to prepare, serve, and file the transcript. This is the first request for a time extension and is sought because:");
            TP(builder, 2);

            TT(builder, "\t");
            InsertBook(builder, "extension_reason");
            TP(builder, 2);

            TT(builder, "3.\tOn order from me, and undelivered to date, are transcripts in the following cases: ");
            TP(builder, 2);

            TT(builder, "4.\tI have served copies of this request on: ");
            InsertBook(builder, "served_on");
            TT(builder, " via the Court's Public Portal eService.");

            builder.InsertBreak(BreakType.PageBreak);

            // Appearances
            InsertAppearances(builder, caption, appearances);
            builder.MoveToDocumentEnd();

            // Signature block
            InsertSignatureLine(builder);

            builder.StartBookmark("timeextend");
            builder.EndBookmark("timeextend");

            doc.Save(outputPath, SaveFormat.Docx);
            return outputPath;
        }

        // ----------------------------
        // Helpers
        // ----------------------------

        private static void InsertBook(DocumentBuilder builder, string name)
        {
            builder.StartBookmark(name);
            builder.Write(name);
            builder.EndBookmark(name);
        }

        private static void InsertCaptionTable(DocumentBuilder builder, OregonCaptionData c)
        {
            var tbl = builder.StartTable();
            builder.InsertCell();
            builder.InsertCell();
            builder.InsertCell();
            builder.EndRow();
            builder.EndTable();

            tbl.SetBorders(LineStyle.None, 0, System.Drawing.Color.Empty);

            tbl.FirstRow.Cells[0].CellFormat.Width = ConvertUtil.InchToPoint(3.25);
            tbl.FirstRow.Cells[1].CellFormat.Width = ConvertUtil.InchToPoint(0.19);
            tbl.FirstRow.Cells[2].CellFormat.Width = ConvertUtil.InchToPoint(2.75);
            tbl.AutoFit(AutoFitBehavior.FixedColumnWidths);

            var cell1 = tbl.FirstRow.Cells[0];
            var cell2 = tbl.FirstRow.Cells[1];
            var cell3 = tbl.FirstRow.Cells[2];

            // Build left cell
            builder.MoveTo(cell1.FirstParagraph);
            SS(builder, centered: false, bold: false);
            TT(builder, $"{c.Name1},"); TP(builder, 2);
            TT(builder, "\t" + c.Party1 + ","); TP(builder, 2);
            TT(builder, "\t\tv."); TP(builder, 2);
            TT(builder, $"{c.Name2},"); TP(builder, 2);
            TT(builder, "\t" + c.Party2 + ".");

            // Build right cell
            builder.MoveTo(cell3.FirstParagraph);
            SS(builder, centered: false, bold: false);
            TT(builder, $"{c.County} County Circuit Court"); TP(builder, 1);
            TT(builder, "Case No. " + c.CaseNumber); TP(builder, 2);
            TT(builder, c.AppealNumber);

            // Count rendered (wrapped) lines in the left cell
            int renderedLines = CountRenderedLinesFromNames(c.Name1, c.Name2, charsPerLine: 65);

            // Fill middle cell with ")" down to the same visual bottom
            builder.MoveTo(cell2.FirstParagraph);
            SS(builder, centered: false, bold: false);

            for (int i = 0; i < renderedLines; i++)
                builder.Writeln(")");
        }

        private static void InsertAppearances(DocumentBuilder builder, OregonCaptionData caption, OregonWorkFlow a)
        {
            Table tbl = builder.StartTable();

            for (int r = 0; r < 3; r++)
            {
                builder.InsertCell();
                builder.InsertCell();
                builder.EndRow();
            }

            builder.EndTable();
            tbl.SetBorders(LineStyle.None, 0, System.Drawing.Color.Empty);

            foreach (Row row in tbl.Rows)
            {
                row.Cells[0].CellFormat.Width = ConvertUtil.InchToPoint(3.1);
                row.Cells[1].CellFormat.Width = ConvertUtil.InchToPoint(3.1);
            }

            SetCell(builder, tbl, 0, 0, GetCourtContact1(caption.County));
            SetCell(builder, tbl, 0, 1, GetCourtContact2(caption.County));

            SetCell(builder, tbl, 1, 0, CreatePartyBlock(a.Party1, a.AppellantAttorney, a.AppellantFirm, a.AppellantAddress, a.AppellantCity, a.AppellantState, a.AppellantZip, a.AppellantEmail, a.AppellantPhone));
            SetCell(builder, tbl, 1, 1, CreatePartyBlock(a.Party2, a.RespondentAttorney, a.RespondentFirm, a.RespondentAddress, a.RespondentCity, a.RespondentState, a.RespondentZip, a.RespondentEmail, a.RespondentPhone));

            SetCell(builder, tbl, 2, 0,
                "Transcriber\r\nMallory Sanders, eScribers, LLC\r\n7227 North 16th St, Ste 207\r\nPhoenix, AZ 85020\r\nsales@escribers.net");
        }

        private static string CreatePartyBlock(
    string party,
    string attorney,
    string firm,
    string address,
    string city,
    string state,
    string zip,
    string email,
    string phone)
        {
            string output = "";

            if (!string.IsNullOrWhiteSpace(party)) output += party + "\r\n";
            if (!string.IsNullOrWhiteSpace(attorney)) output += attorney + "\r\n";
            if (!string.IsNullOrWhiteSpace(firm)) output += firm + "\r\n";
            if (!string.IsNullOrWhiteSpace(address)) output += address + "\r\n";

            if (!string.IsNullOrWhiteSpace(city) ||
                !string.IsNullOrWhiteSpace(state) ||
                !string.IsNullOrWhiteSpace(zip))
            {
                output += city ?? "";
                if (!string.IsNullOrWhiteSpace(state)) output += ", " + state;
                if (!string.IsNullOrWhiteSpace(zip)) output += " " + zip;
                output += "\r\n";
            }

            if (!string.IsNullOrWhiteSpace(email)) output += email + "\r\n";
            if (!string.IsNullOrWhiteSpace(phone)) output += phone + "\r\n";

            return output.TrimEnd();
        }


        private static void InsertSignatureLine(DocumentBuilder builder)
        {
            builder.MoveToDocumentEnd();
            TP(builder, 3);

            TT(builder, DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            TP(builder, 1);
            TT(builder, "  Date");
            TP(builder, 4);

            TT(builder, "eScribers\t\tMaricopa\t\t602-263-088");
            TP(builder, 2);
            TT(builder, "Court Reporter\tCounty\t\t\tTelephone No.");
            TP(builder, 1);
            TT(builder, "or Transcriber");
        }

        private static void SetCell(DocumentBuilder builder, Table tbl, int row, int col, string text)
        {
            var cell = tbl.Rows[row].Cells[col];
            cell.FirstParagraph.RemoveAllChildren();
            builder.MoveTo(cell.FirstParagraph);
            builder.Write(text);
            TP(builder, 2);
        }

        private static string GetCourtContact1(string county) =>
            county switch
            {
                "Multnomah" => "Trial Court Administrator\r\n1200 SW First Avenue\r\nPortland, Oregon 97204\r\nMUL.Transcript.Coordinator@ojd.State.or.us",
                "Lane" => "State Court Administrator\r\nSupreme Court Building\r\n1163 State Street\r\nSalem, Oregon 97301\r\nAppealsClerk@ojd.state.or.us",
                "Marion" => "Trial Court Administrator\r\nP.O. Box 12869\r\nSalem, Oregon 97309",
                "Jackson" => "Trial Court Administrator\r\n100 S. Oakdale Avenue\r\nMedford, OR 97501\r\njac-transcript@ojd.state.or.us",
                _ => ""
            };

        private static string GetCourtContact2(string county) =>
            county switch
            {
                "Multnomah" => "Transcript Coordinator\r\n1200 SW First Avenue\r\nPortland, Oregon 97204\r\nMUL.Transcript.Coordinator@ojd.State.or.us",
                "Lane" => "Trial Court Administrator\r\nLane County Circuit Court\r\n125 E 8th Avenue\r\nEugene, Oregon 97401\r\nlan.transcriptcoordinator@ojd.state.or.us",
                "Marion" => "Transcript Coordinator\r\nP.O. Box 12869\r\nSalem, Oregon 97309",
                "Jackson" => "Transcript Coordinator\r\n100 S. Oakdale Avenue\r\nMedford, OR 97501\r\njac-transcript@ojd.state.or.us",
                _ => ""
            };

        private static void SS(DocumentBuilder builder, bool centered = false, bool bold = false)
        {
            builder.ParagraphFormat.ClearFormatting();
            builder.Font.ClearFormatting();

            builder.ParagraphFormat.Alignment = centered
                ? ParagraphAlignment.Center
                : ParagraphAlignment.Left;

            builder.Font.Bold = bold;
        }


        private static void TT(DocumentBuilder builder, string text)
        {
            builder.Write(text);
        }

        private static void TP(DocumentBuilder builder, int lines)
        {
            for (int i = 0; i < lines; i++)
                builder.Writeln();
        }

        private static int CountRenderedLinesFromNames(string? name1, string? name2, int charsPerLine = 65)
        {
            static int LinesFor(string? s, int cpl)
            {
                s = (s ?? "").Trim();
                if (s.Length == 0) return 1; // treat empty as one line so layout stays stable

                // ceil(length / charsPerLine)
                return (int)Math.Ceiling(s.Length / (double)cpl);
            }

            int n1 = LinesFor(name1, charsPerLine);
            int n2 = LinesFor(name2, charsPerLine);

            // Your fixed baseline lines for the other caption content
            return n1 + n2 + 7;
        }

    }
}
