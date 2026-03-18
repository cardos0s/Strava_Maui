using System.Collections.ObjectModel;

namespace Strava.Views;

public class OnboardingItem
{
    public string Title { get; set; } = string.Empty;
    public string ImageSource { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public partial class OnboardingScreen : ContentPage
{
    public ObservableCollection<OnboardingItem> OnboardingItems { get; set; } = new();

    public OnboardingScreen()
    {
        InitializeComponent();
        LoadData();
        BindingContext = this;
        UpdateDots(0);
    }

    private void LoadData()
    {
        OnboardingItems.Add(new OnboardingItem
        {
            Title = "Designed by athletes,\nfor athletes.",
            ImageSource = "atletas_ab",
            Description = "Connect with millions of runners and cyclists\nfrom all around the world."
        });

        OnboardingItems.Add(new OnboardingItem
        {
            Title = "Share your success\nwith the world.",
            ImageSource = "onb_2.jpg",
            Description = "Track every run, ride and workout.\nCelebrate every milestone."
        });
    }

    private void OnCarouselPositionChanged(object? sender, CurrentItemChangedEventArgs e)
    {
        UpdateDots(OnboardingCarousel.Position);
    }

    private void UpdateDots(int index)
    {
        // Dot ativo = largo e laranja, inativo = pequeno e cinza
        Dot1.BackgroundColor = index == 0 ? Color.FromArgb("#FC5200") : Color.FromArgb("#666666");
        Dot1.WidthRequest = index == 0 ? 24 : 8;

        Dot2.BackgroundColor = index == 1 ? Color.FromArgb("#FC5200") : Color.FromArgb("#666666");
        Dot2.WidthRequest = index == 1 ? 24 : 8;
    }

    private async void OnContinueClicked(object? sender, EventArgs e)
    {
        var currentIndex = OnboardingCarousel.Position;

        if (currentIndex < OnboardingItems.Count - 1)
        {
            OnboardingCarousel.Position = currentIndex + 1;
        }
        else
        {
            await NavigateToMainApp();
        }
    }

    private async void OnSkipClicked(object? sender, EventArgs e)
    {
        await NavigateToMainApp();
    }

    private Task NavigateToMainApp()
    {
        Preferences.Default.Set("onboarding_completed", true);
        Application.Current!.Windows[0].Page = new AppShell();
        return Task.CompletedTask;
    }
}