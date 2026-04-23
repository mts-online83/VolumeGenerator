using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolumeGenerator;
using static System.Collections.Specialized.BitVector32;

namespace VolumeGeneratorApp.Oregon
{
    public class OregonWorkFlow
    {
        public string County { get; init; } = "";
        public string Name1 { get; init; } = "";
        public string Name2 { get; init; } = "";
        public string Party1 { get; init; } = "";
        public string Party2 { get; init; } = "";
        public string CaseNumber { get; init; } = "";
        public string AppealNumber { get; init; } = "";
        public string AppellantAttorney { get; init; } = "";
        public string AppellantFirm { get; init; } = "";
        public string AppellantAddress { get; init; } = "";
        public string AppellantCity { get; init; } = "";
        public string AppellantState { get; init; } = "";
        public string AppellantZip { get; init; } = "";
        public string AppellantEmail { get; init; } = "";
        public string AppellantPhone { get; init; } = "";

        // Respondent side
        public string RespondentAttorney { get; init; } = "";
        public string RespondentFirm { get; init; } = "";
        public string RespondentAddress { get; init; } = "";
        public string RespondentCity { get; init; } = "";
        public string RespondentState { get; init; } = "";
        public string RespondentZip { get; init; } = "";
        public string RespondentEmail { get; init; } = "";
        public string RespondentPhone { get; init; } = "";

        public void InsertOregonCertificatesWithAspose(string mergedDocPath, frmCertCaption dataForm)
        {
            // Load merged document
            var doc = new Document(mergedDocPath);

            var builder = new DocumentBuilder(doc);

            // Move to end of document
            builder.MoveToDocumentEnd();

            // Section break next page
            builder.InsertBreak(BreakType.SectionBreakNewPage);

            // Remove the line numbers
            HeaderLineNumbers.RemoveLineNumbers(doc, removeLineNumberShapes: false);
            // =========================
            // CERTIFICATE OF FILING
            // =========================

            // Bookmark at this position (zero-length bookmark like your macro)
            builder.StartBookmark("certoffiling");
            builder.EndBookmark("certoffiling");

            SS(builder, "ESFilingCenter");
            TT(builder, "IN THE COURT OF APPEALS OF THE");
            TP(builder, 1);
            TT(builder, "STATE OF OREGON");
            TP(builder, 2);

            string cpCounty = dataForm.County;

            // Start table
            builder.StartTable();

            // 🔹 Remove ALL table borders
            builder.CellFormat.Borders.ClearFormatting();
            builder.RowFormat.Borders.ClearFormatting();

            // =====================
            // FIRST CELL (LEFT)
            // =====================
            builder.InsertCell();

            // clear inherited borders first
            builder.CellFormat.Borders.ClearFormatting();

            // Apply ONLY bottom + right
            builder.CellFormat.Borders[BorderType.Bottom].LineStyle = LineStyle.Single;
            builder.CellFormat.Borders[BorderType.Bottom].LineWidth = 0.5;

            builder.CellFormat.Borders[BorderType.Right].LineStyle = LineStyle.Single;
            builder.CellFormat.Borders[BorderType.Right].LineWidth = 0.5;

            SS(builder, "ESFilingNormalSingle");
            TT(builder, dataForm.Name1.ToUpper() + ",");
            TP(builder, 2);
            TT(builder, "\t" + dataForm.Party1 + ",");
            TP(builder, 2);
            TT(builder, "vs.");
            TP(builder, 2);
            TT(builder, dataForm.Name2.ToUpper() + ",");
            TP(builder, 2);
            TT(builder, "\t" + dataForm.Party2 + ".");

            // =====================
            // SECOND CELL (RIGHT)
            // =====================
            builder.InsertCell();

            // ensure NO borders
            builder.CellFormat.Borders.ClearFormatting();

            SS(builder, "ESFilingNormalSingle");
            TT(builder, cpCounty + " Circuit Court");
            TP(builder, 1);
            TT(builder, "Court No. " + dataForm.CaseNumber);
            TP(builder, 2);
            TT(builder, "CA " + dataForm.AppealNumber);

            // Finish table
            builder.EndRow();
            builder.EndTable();


            // Move to end of document again
            builder.MoveToDocumentEnd();
            TP(builder, 1);

            // =========================
            // "comebackhere" bookmark
            // =========================
            builder.StartBookmark("insertcaptionhere");
            builder.EndBookmark("insertcaptionhere");
            TP(builder, 1);


            // =========================
            // CERTIFICATE OF PREPARATION
            // =========================

            // Page break (you could also use another section break if needed)
            builder.InsertBreak(BreakType.PageBreak);

            builder.StartBookmark("certofpreparation");
            builder.EndBookmark("certofpreparation");

            SS(builder, "ESFilingCenter");
            TT(builder, "IN THE COURT OF APPEALS OF THE");
            TP(builder, 1);
            TT(builder, "STATE OF OREGON");
            TP(builder, 2);

            // Table again: 1x2
            builder.StartTable();

            // FIRST CELL (left)
            builder.InsertCell();

            builder.CellFormat.Borders[BorderType.Bottom].LineStyle = LineStyle.Single;
            builder.CellFormat.Borders[BorderType.Bottom].LineWidth = 0.5;
            builder.CellFormat.Borders[BorderType.Right].LineStyle = LineStyle.Single;
            builder.CellFormat.Borders[BorderType.Right].LineWidth = 0.5;

            SS(builder, "ESFilingNormalSingle");
            TT(builder, dataForm.Name1.ToUpper() + ",");
            TP(builder, 2);
            TT(builder, "\t" + dataForm.Party1 + ",");
            TP(builder, 2);
            TT(builder, "vs.");
            TP(builder, 2);
            TT(builder, dataForm.Name2.ToUpper() + ",");
            TP(builder, 2);
            TT(builder, "\t" + dataForm.Party2 + ".");

            // SECOND CELL (right)
            builder.InsertCell();

            builder.CellFormat.Borders.ClearFormatting();

            SS(builder, "ESFilingNormalSingle");
            TT(builder, cpCounty + " Circuit Court");
            TP(builder, 1);
            TT(builder, "Court No. " + dataForm.CaseNumber);
            TP(builder, 2);
            TT(builder, "CA " + dataForm.AppealNumber);

            builder.EndRow();
            builder.EndTable();

            // Move to end of doc
            builder.MoveToDocumentEnd();
            TP(builder, 1);


            // Save back over the merged doc
            doc.Save(mergedDocPath);

        }
        public void InsertOregonCertAppearancesWithAspose(string mergedDocPath, frmCertAppearances dataForm, string _cpCountyFromCertCaption)
        {
            // Load merged document
            var doc = new Document(mergedDocPath);

            var builder = new DocumentBuilder(doc);

            // Move to the insertcaptionhere bookmark to start the caption on the first cert page
            if (doc.Range.Bookmarks["insertcaptionhere"] != null)
            {
                builder.MoveToBookmark("insertcaptionhere", true, true);
                doc.Range.Bookmarks["insertcaptionhere"].Remove();
                // At this point you can continue writing whatever “rest of the info” you want
            }

            // ---------------- CERTIFICATE OF FILING ----------------
            SS(builder, "ESFilingCenterBoldSingle");
            TT(builder, "CERTIFICATE OF FILING");
            TP(builder, 1);
            TT(builder, "OF TRANSCRIPT");
            TP(builder, 4);

            SS(builder, "ESFilingNormalSingle");
            TT(builder, "I certify that I prepared:");
            TP(builder, 2);
            TT(builder, "All of the transcripts designated as part of the record for this appeal.");
            TP(builder, 2);

            builder.StartBookmark("certofprep");
            builder.EndBookmark("certofprep");

            TP(builder, 2);
            TT(builder, "The transcript is now settled");
            TP(builder, 2);
            TT(builder, "I certify that on ");
            TT(builder, "__________________");
            TT(builder, ", the transcript or part thereof prepared by me was filed with the Appellate court Administrator in electronic form required by ORAP 3.35(2).");
            TP(builder, 2);
            TT(builder, "I certify on ");
            TT(builder, "__________________");
            TT(builder, ", a copy of the certificate was served on:");
            TP(builder, 2);

            // Appearances table (Certificate of Filing)
            InsertAppearancesTable(builder,
                dataForm.AppellantAttorney,
                dataForm.AppellantFirm,
                dataForm.AppellantAddress,
                dataForm.AppellantCity,
                dataForm.AppellantState,
                dataForm.AppellantZip,
                dataForm.AppellantPhone,
                dataForm.AppellantEmail,

                dataForm.RespondentAttorney,
                dataForm.RespondentFirm,
                dataForm.RespondentAddress,
                dataForm.RespondentCity,
                dataForm.RespondentState,
                dataForm.RespondentZip,
                dataForm.RespondentPhone,
                dataForm.RespondentEmail
            );

            TP(builder, 1);

            InsertCourtInfo(builder, _cpCountyFromCertCaption);
            InsertCertLine(builder);

            builder.StartBookmark("certoffilingbottom");
            builder.EndBookmark("certoffilingbottom");

            // ---------------- CERTIFICATE OF PREPARATION ----------------
            builder.MoveToDocumentEnd();

            SS(builder, "ESFilingCenterBoldSingle");
            TT(builder, "CERTIFICATE OF PREPARATION");
            TP(builder, 1);
            TT(builder, "AND SERVICE OF TRANSCRIPT");
            TP(builder, 4);

            SS(builder, "ESFilingNormalSingle");
            TT(builder, "I certify that I prepared:");
            TP(builder, 2);
            TT(builder, "All of the transcripts designated as part of the record for this appeal.");
            TP(builder, 2);

            builder.StartBookmark("certofprep2");
            builder.EndBookmark("certofprep2");

            TP(builder, 2);

            TT(builder, "I certify that the original of this Certificate was filed with the Appellate Court Administrator and copies were served on the trial court administrator and transcript coordinator on ");
            TT(builder, "__________________");
            TT(builder, ".");
            TP(builder, 2);
            TT(builder, "I certify that on ");
            TT(builder, "__________________");
            TT(builder, " a copy of the transcript prepared by me and a copy of this Certificate were served on:");
            TP(builder, 2);

            // Appearances table (Certificate of Preparation)
            InsertAppearancesTable(builder,
                dataForm.AppellantAttorney,
                dataForm.AppellantFirm,
                dataForm.AppellantAddress,
                dataForm.AppellantCity,
                dataForm.AppellantState,
                dataForm.AppellantZip,
                dataForm.AppellantPhone,
                dataForm.AppellantEmail,

                dataForm.RespondentAttorney,
                dataForm.RespondentFirm,
                dataForm.RespondentAddress,
                dataForm.RespondentCity,
                dataForm.RespondentState,
                dataForm.RespondentZip,
                dataForm.RespondentPhone,
                dataForm.RespondentEmail
            );

            builder.MoveToDocumentEnd();
            TP(builder, 2);

            InsertCertLine(builder);
            builder.StartBookmark("certofpreparationbottom");
            builder.EndBookmark("certofpreparationbottom");

            doc.Save(mergedDocPath);
        }

        private void InsertAppearancesTable(
            DocumentBuilder builder,
            string appAtty, string appFirm, string appAddr, string appCity, string appState, string appZip, string appPhone, string appEmail,
            string respAtty, string respFirm, string respAddr, string respCity, string respState, string respZip, string respPhone, string respEmail)
        {
            Table tbl = builder.StartTable();

            // First cell: Appellant
            builder.InsertCell();
            InsertAttorneyInfo(builder, "Appellant",
                appAtty, appFirm, appAddr, appCity, appState, appZip, appPhone, appEmail);

            // Second cell: Respondent
            builder.InsertCell();
            InsertAttorneyInfo(builder, "Respondent",
                respAtty, respFirm, respAddr, respCity, respState, respZip, respPhone, respEmail);

            builder.EndRow();
            tbl = builder.EndTable();
            tbl.ClearBorders();
        }
        private void SS(DocumentBuilder builder, string styleName)
        {
            builder.ParagraphFormat.ClearFormatting();
            builder.Font.ClearFormatting();
            builder.ParagraphFormat.StyleName = styleName;
        }

        private static void TT(DocumentBuilder builder, string text)
        {
            // Type text only – NO paragraph break (like Selection.TypeText)
            builder.Write(text);
        }

        private static void TP(DocumentBuilder builder, int count)
        {
            // Insert 'count' paragraph breaks (like Selection.TypeParagraph)
            for (int i = 0; i < count; i++)
            {
                builder.Writeln();
            }
        }

        private void InsertAttorneyInfo(
            DocumentBuilder builder,
            string party,
            string attorney,
            string firm,
            string address,
            string city,
            string state,
            string zip,
            string phone,
            string email)
        {
            SS(builder, "ESFilingNormalSingle");

            WriteLine(builder, $"Attorney for {party}:");
            WriteLine(builder, attorney);
            WriteLine(builder, firm);
            WriteLine(builder, address);
            WriteLine(builder, FormatCityStateZip(city, state, zip));
            WriteLine(builder, phone);
            WriteLine(builder, email);
        }

        private string FormatCityStateZip(string city, string state, string zip)
        {
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(city))
                parts.Add(city.Trim());

            if (!string.IsNullOrWhiteSpace(state))
                parts.Add(state.Trim());

            var result = string.Join(", ", parts);

            if (!string.IsNullOrWhiteSpace(zip))
                result += (result.Length > 0 ? "  " : "") + zip.Trim();

            return result;
        }

        private void WriteLine(DocumentBuilder builder, string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                TT(builder, text.Trim());
                TP(builder, 1);
            }
        }



        private void InsertCertLine(DocumentBuilder builder)
        {
            TP(builder, 2);
            SS(builder, "ESFilingNormalSingle");
            TT(builder, "Date:  ");
            TP(builder, 2);
            TT(builder, "/s/");
            TP(builder, 1);
            SS(builder, "ESFilingCert");
            TT(builder, "\t");
            TP(builder, 1);
            SS(builder, "ESFilingNormalSingle");
            TT(builder, "eScribers, LLC");
        }

        private void InsertCourtInfo(DocumentBuilder builder, string cpCounty)
        {
            SS(builder, "ESFilingNormalSingle");

            if (string.Equals(cpCounty, "Multnomah", StringComparison.OrdinalIgnoreCase))
            {
                TT(builder, "Multnomah County Courthouse" + Environment.NewLine +
                            "Trial Court Administrator" + Environment.NewLine +
                            "1200 SW First Avenue" + Environment.NewLine +
                            "Portland, Oregon 97204" + Environment.NewLine +
                            "MUL.Transcript.Coordinator@ojd.State.or.us");
                TP(builder, 2);

                TT(builder, "Multnomah County Courthouse" + Environment.NewLine +
                            "Transcript Coordinator" + Environment.NewLine +
                            "1200 SW First Avenue" + Environment.NewLine +
                            "Portland, Oregon 97204" + Environment.NewLine +
                            "MUL.Transcript.Coordinator@ojd.State.or.us");
                TP(builder, 2);

                TT(builder, "Multnomah County District Attorney" + Environment.NewLine +
                            "1200 SW First Avenue" + Environment.NewLine +
                            "Portland, Oregon 97204" + Environment.NewLine +
                            "DA@mcda.us");
                TP(builder, 2);
            }
            else if (string.Equals(cpCounty, "Lane", StringComparison.OrdinalIgnoreCase))
            {
                TT(builder, "State Court Administrator" + Environment.NewLine +
                            "Supreme Court Building" + Environment.NewLine +
                            "1163 state Street" + Environment.NewLine +
                            "Salem, Oregon 97301" + Environment.NewLine +
                            "AppealsClerk@ojd.state.or.us");
                TP(builder, 2);

                TT(builder, "Trial Court Administrator" + Environment.NewLine +
                            "Lane County Circuit Court" + Environment.NewLine +
                            "125 E 8th Avenue" + Environment.NewLine +
                            "Eugene, Oregon 97401" + Environment.NewLine +
                            "lan.transcriptcoordinator@ojd.state.or.us");
                TP(builder, 2);

                TT(builder, "Lane County District Attorney" + Environment.NewLine +
                            "125 E 8th Avenue" + Environment.NewLine +
                            "Eugene, Oregon 97401" + Environment.NewLine +
                            "LCDAmail@lanecountyor.gov");
            }
            else if (string.Equals(cpCounty, "Marion", StringComparison.OrdinalIgnoreCase))
            {
                TT(builder, "Marion County District Attorney's Office" + Environment.NewLine +
                            "P.O. Box 14500" + Environment.NewLine +
                            "Salem, Oregon 97309");
                TP(builder, 2);

                TT(builder, "TRIAL COURT ADMINISTRATOR" + Environment.NewLine +
                            "P.O. Box 12869" + Environment.NewLine +
                            "Salem, Oregon 97309");
                TP(builder, 2);

                TT(builder, "TRANSCRIPT COORDINATOR" + Environment.NewLine +
                            "P.O. Box 12869" + Environment.NewLine +
                            "Salem, Oregon 97309");
            }
            else if (string.Equals(cpCounty, "Jackson", StringComparison.OrdinalIgnoreCase))
            {
                TT(builder, "Jackson County Justice Building" + Environment.NewLine +
                            "Trial Court Administrator" + Environment.NewLine +
                            "100 S. Oakdale Avenue" + Environment.NewLine +
                            "Medford, OR 97501" + Environment.NewLine +
                            "jac-transcript@ojd.state.or.us");
                TP(builder, 2);

                TT(builder, "Jackson County Justice Building" + Environment.NewLine +
                            "Transcript Coordinator" + Environment.NewLine +
                            "100 S. Oakdale Avenue" + Environment.NewLine +
                            "Medford, OR 97501" + Environment.NewLine +
                            "jac-transcript@ojd.state.or.us");
                TP(builder, 2);

                TT(builder, "Jackson County District Attorney" + Environment.NewLine +
                            "815 W 10th Street" + Environment.NewLine +
                            "Medford, OR 97501" + Environment.NewLine +
                            "DistrictAttorney@jacksoncounty.org");
                TP(builder, 2);
            }
        }
        // Build the "date + volume + page range" lines
        public List<string> BuildVolumeListing(List<VolumeInfo> volumes)
        {
            var result = new List<string>();

            foreach (var vol in volumes)
            {
                foreach (var entry in vol.Entries)
                {
                    // Ensure SortDate is set in your MergeEntry; we used it earlier when merging
                    string line =
                        $"{entry.SortDate:MM/dd/yyyy}  " +
                        $"Volume {vol.VolumeNumber} " +
                        $"(pages {entry.StartPage} - {entry.EndPage})";

                    result.Add(line);
                }
            }

            return result;
        }

        // Insert a list of lines at a bookmark
        public void InsertLinesAtBookmark(String mergedDocPath, string bookmarkName, List<string> lines)
        {
            // Load merged document
            var doc = new Document(mergedDocPath);

            var builder = new DocumentBuilder(doc);

            if (doc.Range.Bookmarks[bookmarkName] != null)
                builder.MoveToBookmark(bookmarkName, true, false);

            foreach (var line in lines)
            {
                builder.Writeln(line);
            }

            doc.Save(mergedDocPath);
        }
        public void CollectTranscriberOverridesPerVolume(Form owner, List<VolumeInfo> volumes, VolumeService service)
        {
            foreach (var vol in volumes.OrderBy(v => v.VolumeNumber))
            {
                if (string.IsNullOrWhiteSpace(vol.OutputPath))
                    continue;

                // maps transcriber to the correct hearing date using page ranges
                var entries = service.GetDateAndTranscriberForVolume(vol.OutputPath, vol);

                using (var frm = new frmTranscribers($"Volume {vol.VolumeNumber}", entries))
                {
                    if (frm.ShowDialog(owner) != DialogResult.OK)
                        return;

                    vol.SelectedTranscriber = frm.SelectedTranscriber; // property you added
                }
            }
        }

        public string CreateCaptionDocument(string outputFolder, OregonWorkFlow appearances, OregonWorkFlow data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (string.IsNullOrWhiteSpace(outputFolder)) throw new ArgumentException("outputFolder required.");

            Directory.CreateDirectory(outputFolder);

            // Use your appeal number in the filename if you want
            string appeal = MakeSafeFilePart(data.AppealNumber);
            string fileName = "Request for Extension of Time.docx";
            string outputPath = Path.Combine(outputFolder, fileName);

            var doc = new Document();
            var builder = new DocumentBuilder(doc);

            // 1-row, 3-col table
            Table tbl = builder.StartTable();
            builder.InsertCell(); // col 1
            builder.InsertCell(); // col 2
            builder.InsertCell(); // col 3
            builder.EndRow();
            builder.EndTable();

            // No borders
            tbl.SetBorders(LineStyle.None, 0, System.Drawing.Color.Empty);

            // Column widths (inches -> points)
            tbl.FirstRow.Cells[0].CellFormat.Width = ConvertUtil.InchToPoint(3.25);
            tbl.FirstRow.Cells[1].CellFormat.Width = ConvertUtil.InchToPoint(0.19);
            tbl.FirstRow.Cells[2].CellFormat.Width = ConvertUtil.InchToPoint(2.75);
            tbl.AutoFit(AutoFitBehavior.FixedColumnWidths);

            var cell1 = tbl.FirstRow.Cells[0];
            var cell2 = tbl.FirstRow.Cells[1];
            var cell3 = tbl.FirstRow.Cells[2];

            // Column 1 text (matches your VBA intent)
            builder.MoveTo(cell1.FirstParagraph);
            // If you have styles available, apply them here:
            // builder.ParagraphFormat.StyleName = "ESFilingNormalSingle";

            builder.Writeln($"{data.Name1},");
            builder.Writeln();
            builder.Writeln($"\t{data.Party1},");
            builder.Writeln();
            builder.Writeln("\t\tv.");
            builder.Writeln();
            builder.Writeln($"{data.Name2},");
            builder.Writeln();
            builder.Write($"\t{data.Party2}.");

            // Column 3 text
            builder.MoveTo(cell3.FirstParagraph);
            // builder.ParagraphFormat.StyleName = "ESFilingNormalSingle";

            builder.Writeln($"{data.County} County Circuit Court");
            builder.Writeln($"Case No. {data.CaseNumber}");
            builder.Writeln();
            builder.Write($"CA {data.AppealNumber}");

            // Column 2 stacked ")"
            int approxLines = Math.Max(6, cell1.Paragraphs.Count);
            builder.MoveTo(cell2.FirstParagraph);
            // builder.ParagraphFormat.StyleName = "ESFilingNormalSingle";

            for (int i = 0; i < approxLines; i++)
                builder.Writeln(")");

            doc.Save(outputPath, SaveFormat.Docx);
            return outputPath;
        }

        private static string MakeSafeFilePart(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                input = input.Replace(c, '_');
            return input.Trim();
        }
        public string CreateNoPaymentLetter(string outputFolder)
        {
            if (string.IsNullOrWhiteSpace(outputFolder)) throw new ArgumentException("outputFolder is required.", nameof(outputFolder));

            Directory.CreateDirectory(outputFolder);

            string outputPath = Path.Combine(outputFolder, "Request for Payment.docx");

            var doc = new Document();
            var builder = new DocumentBuilder(doc);

            // If you have a specific style, apply it here
            // builder.ParagraphFormat.StyleName = "ESFilingNormalSingle";

            // "nopaystart" bookmark
            builder.StartBookmark("nopaystart");
            builder.EndBookmark("nopaystart");

            // Date line (MMMM d, yyyy)
            builder.Writeln(DateTime.Now.ToString("MMMM d, yyyy", CultureInfo.InvariantCulture));
            TP(builder, 4);

            // Address block (bookmark + optional text)
            InsertBookmarkWithOptionalText(builder, "nopay_address");
            TP(builder, 3);

            // Caption block (bookmark + optional text)
            InsertBookmarkWithOptionalText(builder, "nopay_caption");
            TP(builder, 1);

            // County
            builder.Write("County: ");
            InsertBookmarkWithOptionalText(builder, "nopay_county");
            TP(builder, 1);

            // Case number
            builder.Write("County Case No. ");
            InsertBookmarkWithOptionalText(builder, "nopay_casenumber");
            TP(builder, 1);

            // Appeal number
            builder.Write("(Appellate Case No.) ");
            InsertBookmarkWithOptionalText(builder, "nopay_appealnumber");
            TP(builder, 4);

            builder.Writeln("Whom It May Concern:");
            TP(builder, 2);

            builder.Writeln("Please be advised the transcript in this matter has not been produced because appellant has not responded to my requests to make the financial arrangements necessary for transcript preparation.");
            TP(builder, 3);

            builder.Writeln("Sincerely,");
            TP(builder, 1);

            builder.Writeln("eScribers");

            // "nopayend" bookmark
            builder.StartBookmark("nopayend");
            builder.EndBookmark("nopayend");

            // Update fields if you ever add any
            doc.UpdateFields();

            doc.Save(outputPath, SaveFormat.Docx);
            return outputPath;
        }

        private static void InsertBookmarkWithOptionalText(DocumentBuilder builder, string bookmarkName)
        {
            builder.StartBookmark(bookmarkName);
            builder.Write(bookmarkName);
            builder.EndBookmark(bookmarkName);
        }
    }
}
