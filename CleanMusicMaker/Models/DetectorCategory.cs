namespace CleanMusicMaker.Models
{
    public class DetectorCategory
    {
        public string? Namespace { get; set; }
        public string? Id { get; set; }

        public string? Label { get; set; }

        public string[]? Hierachy { get; set; }

        public int Score { get; set; }

        public decimal Frequency { get; set; }

        public bool Winner { get; set; }

        public Position[]? Positions { get; set; }
    }
}
