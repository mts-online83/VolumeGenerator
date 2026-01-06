using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeGenerator
{
    public class MergeEntry
    {
        public string FileName { get; set; } = "";
        public string FullPath { get; set; } = "";
        public DateTime SortDate { get; set; }

        public int PageCount { get; set; }

        // Page range of this doc inside the merged document (1-based)
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
