namespace Strava.Views.Components;

public partial class CustomTabBar : ContentView
{
    private string _currentTab = "Home";
    private bool _isPickerOpen = false;

    public CustomTabBar()
    {
        InitializeComponent();
        SetActiveState("Home");
    }

    // ========== TAB NAVIGATION ==========

    private async void OnHomeClicked(object? sender, EventArgs e)
    {
        if (_isPickerOpen) await ClosePicker();
        if (_currentTab == "Home") return;
        SetActiveState("Home");
        await AnimateIcon(ImgHome);
        await Shell.Current.GoToAsync("//FeedPage");
    }

    private async void OnMapsClicked(object? sender, EventArgs e)
    {
        if (_isPickerOpen) await ClosePicker();
        if (_currentTab == "Maps") return;
        SetActiveState("Maps");
        await AnimateIcon(ImgMaps);
        await Shell.Current.GoToAsync("//MapPage");
    }

    private async void OnProfileClicked(object? sender, EventArgs e)
    {
        if (_isPickerOpen) await ClosePicker();
        if (_currentTab == "Profile") return;
        SetActiveState("Profile");
        await AnimateIcon(ImgProfile);
        await Shell.Current.GoToAsync("//ProfilePage");
    }

    private async void OnGroupsClicked(object? sender, EventArgs e)
    {
        if (_isPickerOpen) await ClosePicker();
        await AnimateIcon(ImgGroups);
        await Shell.Current.DisplayAlert("Em breve", "Funcionalidade de Grupos!", "OK");
    }

    // ========== RECORD BUTTON / PICKER ==========

    private async void OnRecordTapped(object? sender, EventArgs e)
    {
        if (_isPickerOpen)
            await ClosePicker();
        else
            await OpenPicker();
    }

    private async Task OpenPicker()
    {
        _isPickerOpen = true;

        RecordEllipse.Fill = new SolidColorBrush(Color.FromArgb("#080352"));
        RecordIcon.Text = "✕";
        RecordIcon.FontSize = 22;

        ActivityPicker.IsVisible = true;
        ActivityPicker.Scale = 0.3;
        ActivityPicker.Opacity = 0;
        ActivityPicker.TranslationY = 20;

        await Task.WhenAll(
            ActivityPicker.ScaleTo(1.0, 250, Easing.CubicOut),
            ActivityPicker.FadeTo(1.0, 200),
            ActivityPicker.TranslateTo(0, 0, 250, Easing.CubicOut),
            RecordButton.RotateTo(90, 200, Easing.CubicOut)
        );
    }

    private async Task ClosePicker()
    {
        _isPickerOpen = false;

        RecordEllipse.Fill = new SolidColorBrush(Color.FromArgb("#FC5200"));
        RecordIcon.Text = "▶";
        RecordIcon.FontSize = 18;

        await Task.WhenAll(
            ActivityPicker.ScaleTo(0.3, 200, Easing.CubicIn),
            ActivityPicker.FadeTo(0, 150),
            ActivityPicker.TranslateTo(0, 20, 200, Easing.CubicIn),
            RecordButton.RotateTo(0, 200, Easing.CubicIn)
        );

        ActivityPicker.IsVisible = false;
    }

    // ========== ACTIVITY SELECTION ==========

    private async void OnRunSelected(object? sender, EventArgs e)
    {
        await ClosePicker();
        await Shell.Current.GoToAsync($"{nameof(RecordingPage)}?type=run");
    }

    private async void OnSwimSelected(object? sender, EventArgs e)
    {
        await ClosePicker();
        await Shell.Current.GoToAsync($"{nameof(RecordingPage)}?type=swim");
    }

    private async void OnBikeSelected(object? sender, EventArgs e)
    {
        await ClosePicker();
        await Shell.Current.GoToAsync($"{nameof(RecordingPage)}?type=bike");
    }

    // ========== TAB STATE ==========

    private void SetActiveState(string tab)
    {
        _currentTab = tab;

        ImgHome.Opacity = 0.35;
        ImgMaps.Opacity = 0.35;
        ImgGroups.Opacity = 0.35;
        ImgProfile.Opacity = 0.35;

        DotHome.IsVisible = false;
        DotMaps.IsVisible = false;
        DotGroups.IsVisible = false;
        DotProfile.IsVisible = false;

        switch (tab)
        {
            case "Home":
                ImgHome.Opacity = 1.0;
                DotHome.IsVisible = true;
                break;
            case "Maps":
                ImgMaps.Opacity = 1.0;
                DotMaps.IsVisible = true;
                break;
            case "Profile":
                ImgProfile.Opacity = 1.0;
                DotProfile.IsVisible = true;
                break;
        }
    }

    private async Task AnimateIcon(Image icon)
    {
        await icon.ScaleTo(0.75, 100, Easing.CubicIn);
        await icon.ScaleTo(1.15, 150, Easing.CubicOut);
        await icon.ScaleTo(1.0, 100, Easing.CubicInOut);
    }
}