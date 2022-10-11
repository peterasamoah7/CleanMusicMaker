using CleanMusicMaker.Interfaces;
using CleanMusicMaker.Models;
using Newtonsoft.Json;

namespace CleanMusicMaker.Services
{
    public class TextAnalyticsService : ITextAnalyticsService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;

        public TextAnalyticsService(HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));  
        }

        public async Task<DisambiguationResponse?> ExtractSentences(string content)
        {
            var request = new DocumentRequest(new Document(content));

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = await _tokenService.GetToken();

            var response = await _httpClient.PostAsJsonAsync("/v2/analyze/standard/en/disambiguation", request);
            response.EnsureSuccessStatusCode();

            var model = JsonConvert.DeserializeObject<DisambiguationResponse>(
                await response.Content.ReadAsStringAsync());

            return model;
        }


        public async Task<DetectorResponse?> DetectForHateSpeech(string content)
        {
            var request = new DocumentRequest(new Document(content));

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = await _tokenService.GetToken();

            var response = await _httpClient.PostAsJsonAsync("/v2/detect/hate-speech/en", request);
            response.EnsureSuccessStatusCode();

            var model = JsonConvert.DeserializeObject<DetectorResponse>(
                await response.Content.ReadAsStringAsync());

            return model;
        }
    }
}
