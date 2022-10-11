namespace CleanMusicMaker.Models
{
    public class DisambiguationData
    {
        public string? Content { get; set; }

        public string? Language { get; set; }

        public string? Version { get; set; }

        public Sentence[]? Sentences { get; set; }
    }
}
