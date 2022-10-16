using CleanMusicMaker.Models;

namespace CleanMusicMaker.Interfaces
{
    public interface IAudioService
    {
        Task<SpeechResult?> ExtractTextContent(IFormFile file);
    }
}
