namespace VolumeGeneratorApp.Oregon
{
    public record OregonCaptionData
    {
        public string County { get; init; } = "";
        public string Name1 { get; init; } = "";
        public string Name2 { get; init; } = "";
        public string Party1 { get; init; } = "";
        public string Party2 { get; init; } = "";
        public string CaseNumber { get; init; } = "";
        public string AppealNumber { get; init; } = "";
    }
}