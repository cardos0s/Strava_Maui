using Microsoft.Extensions.DependencyInjection;
using Strava.Views;

namespace Strava;

public partial class App : Application
{
    public App(OnboardingScreen OnboardingScreen)
    {
        InitializeComponent();
        MainPage = OnboardingScreen;
    }

    
}