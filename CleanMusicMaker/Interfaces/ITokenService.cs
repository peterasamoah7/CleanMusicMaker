using System.Net.Http.Headers;

namespace CleanMusicMaker.Interfaces
{
    public interface ITokenService
    {
        Task<AuthenticationHeaderValue?> GetToken();
    }
}
