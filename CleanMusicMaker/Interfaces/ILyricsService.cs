using CleanMusicMaker.Models;

namespace CleanMusicMaker.Interfaces
{
    public interface ILyricsService
    {
        Task<List<DetectorResult?>> Analyse(string content);
    }
}
