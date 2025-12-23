using Microsoft.Extensions.Logging;
using Strava.ViewModels;
using Strava.Views;

namespace Strava;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<OnboardingScreen>();
        builder.Services.AddTransient<OnboardingViewModel>();        
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient<FeedPage>();
        builder.Services.AddTransient<FeedViewModel>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}