using CleanMusicMaker.Interfaces;
using CleanMusicMaker.Models;
using CleanMusicMaker.Extensions;

namespace CleanMusicMaker.Services
{
    public class LyricsService : ILyricsService
    {
        private readonly ITextAnalyticsService _textAnalyticsService;        

        public LyricsService(ITextAnalyticsService textAnalyticsService)
        {
            _textAnalyticsService = textAnalyticsService;
        }

        public async Task<List<DetectorResult?>> Analyse(string content)
        {
            var results = new List<DetectorResult?>();

            var sentences = await _textAnalyticsService.ExtractSentences(content);

            if (sentences  == null || !sentences.Success || sentences.Data == null || sentences.Data.Sentences == null)
                return results;

            foreach(var sentence in sentences.Data.Sentences)
            {
                var response = await _textAnalyticsService
                    .DetectForHateSpeech(content.GetSubString(sentence.Start, sentence.End));

                results.Add(DetectorResult.Create(response));
            }
                
            return results;
        }
    }
}
