namespace CleanMusicMaker.Models
{
    public class NlpConfiguation
    {
        public const string Section = "NlpConfig";
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsValid => Username != null && Password != null;
    }
}
