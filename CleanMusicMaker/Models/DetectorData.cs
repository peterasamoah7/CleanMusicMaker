namespace CleanMusicMaker.Models
{
    public class DetectorData
    {
        public string? Content { get; set; }

        public string? Language { get; set; }

        public string? Version { get; set; }

        public DetectorCategory[]? Categories { get; set; }

        public DetectorExtraction[]? Extractions { get; set; }
    }
}
