using Aspose.Words;
using Aspose.Words.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeGenerator
{
    public static class HeaderLineNumbers
    {
        /// <summary>
        /// Unlinks headers/footers in the specified section from the previous section
        /// and optionally removes shapes used for line numbers.
        /// This is the Aspose.Words equivalent of your RemoveLineNumbers macro.
        /// </summary>
        public static void RemoveLineNumbers(Document doc, int sectionIndex, bool removeLineNumberShapes = false)
        {
            if (doc == null)
                throw new ArgumentNullException(nameof(doc));

            if (sectionIndex < 0 || sectionIndex >= doc.Sections.Count)
                throw new ArgumentOutOfRangeException(nameof(sectionIndex));

            Section section = doc.Sections[sectionIndex];

            // Equivalent of:
            //   For j = 1 To 3
            //       .Headers(j).LinkToPrevious = False
            //   Next j
            //
            // In Aspose, this unlinks *all* headers/footers in this section.
            section.HeadersFooters.LinkToPrevious(false);

            if (removeLineNumberShapes)
            {
                DeleteLineNumberShapes(section);
            }
        }

        /// <summary>
        /// Convenience overload: operate on the last section in the document,
        /// which is usually the one you just added.
        /// </summary>
        public static void RemoveLineNumbers(Document doc, bool removeLineNumberShapes = false)
        {
            if (doc == null)
                throw new ArgumentNullException(nameof(doc));

            if (doc.Sections.Count == 0)
                return;

            int lastIndex = doc.Sections.Count - 1;
            RemoveLineNumbers(doc, lastIndex, removeLineNumberShapes);
        }

        /// <summary>
        /// Rough equivalent of your DeleteShape macro. Here we remove shapes
        /// in the headers/footers of the given section that are used as
        /// line-number text boxes. Adjust the predicate as needed.
        /// </summary>
        private static void DeleteLineNumberShapes(Section section)
        {
            // If you know a specific name / alt text / style of the line-number shape,
            // update the predicate below accordingly.
            foreach (HeaderFooter hf in section.HeadersFooters)
            {
                // Collect shapes first to avoid modifying the collection while iterating
                var shapes = hf.GetChildNodes(NodeType.Shape, true).OfType<Shape>().ToList();

                foreach (var shape in shapes)
                {
                    // Example: if the shape name or alt text identifies line numbers:
                    // if (shape.Name == "LineNumberBox" || shape.AlternativeText.Contains("Line Numbers"))
                    //     shape.Remove();

                    // If line numbers are the ONLY shapes in header, you could be more aggressive:
                    // shape.Remove();

                    // For now, this is left as a placeholder:
                    // shape.Remove();
                }
            }
        }
    }
}
