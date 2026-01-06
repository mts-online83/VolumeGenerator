using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VolumeGenerator.VolumeService;

namespace VolumeGenerator
{
    public class VolumeInfo
    {
        public int VolumeNumber { get; set; }
        public string OutputPath { get; set; } = "";

        // Page range within the merged document (1-based)
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public int TotalPages => EndPage - StartPage + 1;

        public List<MergeEntry> Entries { get; } = new();

        public List<string> Transcribers { get; set; } = new();

        public string SelectedTranscriber { get; set; } = "";


    }
}
