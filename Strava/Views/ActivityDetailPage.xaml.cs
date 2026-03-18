namespace Strava.Views;

public partial class ActivityDetailPage : ContentPage
{
    public ActivityDetailPage(ViewModels.ActivityDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnBackTapped(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}