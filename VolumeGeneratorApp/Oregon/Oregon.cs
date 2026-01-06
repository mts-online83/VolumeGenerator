using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolumeGenerator;

namespace VolumeGeneratorApp.Oregon
{
    public class OregonWorkFlow
    {
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

            // Start table: 1 row, 2 columns
            builder.StartTable();

            // FIRST CELL (left)
            builder.InsertCell();

            // Bottom + right border like in VBA
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

            // Clear borders so this cell has no borders
            builder.CellFormat.Borders.ClearFormatting();

            SS(builder, "ESFilingNormalSingle");
            TT(builder, cpCounty + " Circuit Court");
            TP(builder, 1);
            TT(builder, "Court No. " + dataForm.CaseNumber);
            TP(builder, 2);
            TT(builder, "CA " + dataForm.AppealNumber);

            // End row + table
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
        private static void SS(DocumentBuilder builder, string styleName)
        {
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
            TT(builder, "Attorney for " + party + ":");
            TP(builder, 1);
            TT(builder, attorney);
            TP(builder, 1);
            TT(builder, firm);
            TP(builder, 1);
            TT(builder, address);
            TP(builder, 1);
            TT(builder, city + ", " + state + "  " + zip);
            TP(builder, 1);
            TT(builder, phone);
            TP(builder, 1);
            TT(builder, email);
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

                // Build the display list for this volume (date||transcriber entries)
                var entries = service.GetDateAndTranscriberForVolume(vol.OutputPath);

                using (var frm = new frmTranscribers(
                    $"Volume {vol.VolumeNumber}",
                    entries))
                {
                    if (frm.ShowDialog(owner) != DialogResult.OK)
                        return; // user cancelled out of the workflow

                    // Store the user's decision (can be blank)
                    vol.SelectedTranscriber = frm.SelectedTranscriber;
                }
            }
        }
    }
}
