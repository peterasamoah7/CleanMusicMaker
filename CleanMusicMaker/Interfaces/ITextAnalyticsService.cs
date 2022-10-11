using CleanMusicMaker.Models;

namespace CleanMusicMaker.Interfaces
{
    public interface ITextAnalyticsService
    {
        Task<DetectorResponse?> DetectForHateSpeech(string content);
        Task<DisambiguationResponse?> ExtractSentences(string content);
    }
}
