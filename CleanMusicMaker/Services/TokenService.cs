using CleanMusicMaker.Interfaces;
using CleanMusicMaker.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace CleanMusicMaker.Services
{
    public class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient; 
        private readonly IMemoryCache _memoryCache;
        private readonly NlpConfiguation _nlpConfig;
        private const string tokenKey = "auth_key";

        public TokenService(IOptions<NlpConfiguation> options ,HttpClient httpClient, IMemoryCache memoryCache)
        {           
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _nlpConfig = options.Value;
        }

        public async Task<AuthenticationHeaderValue?> GetToken()
        {
            if (!_nlpConfig.IsValid) return null;

            if (_memoryCache.TryGetValue<string>(tokenKey, out var value))
            {
                var jwtToken = new JwtSecurityToken(value);
                if (jwtToken.ValidTo > DateTime.UtcNow)
                    return new AuthenticationHeaderValue("Bearer", value);
            }

            var request = new TokenRequest(_nlpConfig.Username, _nlpConfig.Password);

            var response = await _httpClient.PostAsJsonAsync("/oauth2/token", request);
            response.EnsureSuccessStatusCode();

            var token = await response.Content.ReadAsStringAsync();

            _memoryCache.Set(tokenKey, token);

            return new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
