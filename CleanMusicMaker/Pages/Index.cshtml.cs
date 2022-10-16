using CleanMusicMaker.Interfaces;
using CleanMusicMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace CleanMusicMaker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILyricsService _lyricsService;
        private readonly IMemoryCache _memoryCache;

        [BindProperty]
        public string? Lyrics { get; set; }

        [BindProperty]
        public bool ShowAll { get; set; }

        public List<DetectorResult?> Results { get; set; }

        public IndexModel(ILyricsService lyricsService, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _lyricsService = lyricsService ?? throw new ArgumentException(nameof(ILyricsService));
            Results = new List<DetectorResult?>();
        }        

        public IActionResult OnGetAsync()
        {
            if (_memoryCache.TryGetValue<List<DetectorResult?>>("text-results", out var results) &&
                _memoryCache.TryGetValue<string?>("text-lyrics", out var lyrics))
            {
                Results = results;
                Lyrics = lyrics;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Lyrics))
            {
                return Page();
            }

            var results = await _lyricsService.Analyse(Lyrics);

            if(!ShowAll)
            {
                results = results.Where(x => x!.Issues != "No Issues Found").ToList();
            }

            _memoryCache.Set("text-results", results, DateTimeOffset.Now.AddMinutes(1));
            _memoryCache.Set("text-lyrics", Lyrics, DateTimeOffset.Now.AddMinutes(1));

            return RedirectToPage("./Index");
        }
    }
}