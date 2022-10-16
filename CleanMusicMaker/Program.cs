using CleanMusicMaker.Interfaces;
using CleanMusicMaker.Models;
using CleanMusicMaker.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<NlpConfiguation>(
    builder.Configuration.GetSection(NlpConfiguation.Section));

builder.Services.Configure<SpeechConfiguration>(
    builder.Configuration.GetSection(SpeechConfiguration.Section));

// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson(options => {
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});

builder.Services.AddHttpClient<ITextAnalyticsService, TextAnalyticsService>(options => {
    options.BaseAddress = new Uri(builder.Configuration["NlpConfig:ApiUrl"]);
});

builder.Services.AddHttpClient<ITokenService, TokenService>(options => {
    options.BaseAddress = new Uri(builder.Configuration["NlpConfig:AuthUrl"]);
});

builder.Services.AddScoped<ILyricsService, LyricsService>();
builder.Services.AddScoped<IAudioService, AudioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
