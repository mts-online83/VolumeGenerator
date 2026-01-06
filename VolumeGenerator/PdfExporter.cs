using Aspose.Words;
using Aspose.Words.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeGenerator
{
    public class PdfExporter
    {
        /// <summary>
        /// Extracts the Certificate of Filing and Certificate of Preparation
        /// from the merged document (by bookmark range) and saves each as a PDF.
        /// </summary>
        /// <param name="mergedDocPath">Full path to MERGED_DOC.docx</param>
        /// <param name="outputFolder">Folder to write the PDFs into</param>
        public void ExportCertificates(string mergedDocPath, string outputFolder)
        {
            if (string.IsNullOrWhiteSpace(mergedDocPath))
                throw new ArgumentException("mergedDocPath is required.", nameof(mergedDocPath));
            if (!File.Exists(mergedDocPath))
                throw new FileNotFoundException("Merged document not found.", mergedDocPath);

            if (string.IsNullOrWhiteSpace(outputFolder))
                throw new ArgumentException("outputFolder is required.", nameof(outputFolder));

            Directory.CreateDirectory(outputFolder);

            var doc = new Document(mergedDocPath);
            doc.UpdatePageLayout(); // ensure page indexes are up-to-date

            var collector = new LayoutCollector(doc);

            // 1) Certificate of Filing
            ExportBookmarkRangeToPdf(
                doc,
                collector,
                "certoffiling",
                "certoffilingbottom",
                Path.Combine(outputFolder, "Certificate of Filing.pdf"));

            // 2) Certificate of Preparation
            ExportBookmarkRangeToPdf(
                doc,
                collector,
                "certofpreparation",
                "certofpreparationbottom",
                Path.Combine(outputFolder, "Certificate of Preparation.pdf"));
        }

        /// <summary>
        /// Extract pages that contain the content from startBookmark to endBookmark and save as PDF.
        /// Uses page indices instead of copy/paste, assuming each cert lives on its own pages.
        /// </summary>
        private void ExportBookmarkRangeToPdf(
            Document doc,
            LayoutCollector collector,
            string startBookmarkName,
            string endBookmarkName,
            string outputPath)
        {
            var startBm = doc.Range.Bookmarks[startBookmarkName];
            var endBm = doc.Range.Bookmarks[endBookmarkName];

            if (startBm == null || endBm == null)
            {
                // Bookmark missing: skip this cert.
                return;
            }

            // Get page indexes (1-based) for the bookmark start/end
            int startPage = collector.GetStartPageIndex(startBm.BookmarkStart);
            int endPage = collector.GetEndPageIndex(endBm.BookmarkEnd);

            if (endPage < startPage)
                return;

            int pageCount = endPage - startPage + 1;

            // Extract pages (ExtractPages uses 0-based page index)
            Document extracted = doc.ExtractPages(startPage - 1, pageCount);

            // Save as PDF
            extracted.Save(outputPath, SaveFormat.Pdf);
        }
    }
}
