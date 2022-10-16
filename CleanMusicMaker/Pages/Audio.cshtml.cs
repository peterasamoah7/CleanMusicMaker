using CleanMusicMaker.Interfaces;
using CleanMusicMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace CleanMusicMaker.Pages
{
    public class AudioModel : PageModel
    {
        private readonly ILyricsService _lyricsService;
        private readonly IAudioService _audioService;
        private readonly IMemoryCache _memoryCache;

        [BindProperty]
        public IFormFile? Upload { get; set; }

        [BindProperty]
        public bool ShowAll { get; set; }

        public string? AudioContent { get; set; }

        public List<DetectorResult?> Results { get; set; }

        public AudioModel(ILyricsService lyricsService, IAudioService audioService, IMemoryCache memoryCache)
        {
            _lyricsService = lyricsService ?? throw new ArgumentException(nameof(ILyricsService));
            _audioService = audioService ?? throw new ArgumentException(nameof(audioService));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            Results = new List<DetectorResult?>();
        }

        public IActionResult OnGet()
        {
            if (_memoryCache.TryGetValue<List<DetectorResult?>>("audio-results", out var results) &&
                _memoryCache.TryGetValue<string?>("audio-lyrics", out var lyrics))
            {
                Results = results;
                AudioContent = lyrics;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Upload is null)
                return Page();

            var audioContent = await _audioService.ExtractTextContent(Upload);

            if (audioContent == null || string.IsNullOrEmpty(audioContent.Content))
                return Page();

            AudioContent = audioContent.Content;
            var results = await _lyricsService.Analyse(audioContent.Content);

            if (!ShowAll)
            {
                results = results.Where(x => x!.Issues != "No Issues Found").ToList();
            }

            _memoryCache.Set("audio-results", results, DateTimeOffset.Now.AddMinutes(1));
            _memoryCache.Set("audio-lyrics", AudioContent, DateTimeOffset.Now.AddMinutes(1));

            return RedirectToPage("./Audio");
        }
    }
}
