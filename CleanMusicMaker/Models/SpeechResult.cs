namespace CleanMusicMaker.Models
{
    public class SpeechResult
    {
        public string? Content { get; }

        public SpeechResult(string? content)
        {
            Content = content;
        }
    }
}
