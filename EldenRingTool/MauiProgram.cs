using Microsoft.AspNetCore.Components.WebView.Maui;
using EldenRingTool.Data;
using EldenRingTool.EldenRingFanApi;

namespace EldenRingTool;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSingleton<IFanApiService, FanApiService>();

        return builder.Build();
    }
}