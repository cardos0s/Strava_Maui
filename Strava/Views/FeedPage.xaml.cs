using Strava.Views.Components;

namespace Strava.Views;

public partial class FeedPage : ContentPage
{
    public FeedPage(ViewModels.FeedViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnMenuTapped(object? sender, EventArgs e)
    {
        if (Sidemenu.IsOpen)
            await Sidemenu.Close();
        else
            await Sidemenu.Open();
    }
}