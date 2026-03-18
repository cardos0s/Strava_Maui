namespace Strava.Views.Components;

public partial class Sidemenu : ContentView
{
    private bool _isOpen = false;

    public Sidemenu()
    {
        InitializeComponent();
    }

    public async Task Open()
    {
        if (_isOpen) return;
        _isOpen = true;

        IsVisible = true;
        InputTransparent = false;

        var overlayFade = Overlay.FadeTo(0.45, 280, Easing.CubicOut);
        var panelSlide = MenuPanel.TranslateTo(0, 0, 300, Easing.CubicOut);

        await Task.WhenAll(overlayFade, panelSlide);
    }

    public async Task Close()
    {
        if (!_isOpen) return;

        var overlayFade = Overlay.FadeTo(0, 220, Easing.CubicIn);
        var panelSlide = MenuPanel.TranslateTo(-300, 0, 260, Easing.CubicIn);

        await Task.WhenAll(overlayFade, panelSlide);

        IsVisible = false;
        InputTransparent = true;
        _isOpen = false;
    }

    public bool IsOpen => _isOpen;

    private async void OnOverlayTapped(object? sender, EventArgs e)
    {
        await Close();
    }

    private async void OnProfileTapped(object? sender, EventArgs e)
    {
        await Close();
        await Shell.Current.GoToAsync("//ProfilePage");
    }

    private async void OnProgressTapped(object? sender, EventArgs e)
    {
        await Close();
        await Shell.Current.DisplayAlert("Progresso", "Tela de progresso em breve!", "OK");
    }

    private async void OnActivitiesTapped(object? sender, EventArgs e)
    {
        await Close();
        await Shell.Current.DisplayAlert("Atividades", "Tela de atividades em breve!", "OK");
    }

    private async void OnAccountTapped(object? sender, EventArgs e)
    {
        await Close();
        await Shell.Current.DisplayAlert("Conta", "Configurações da conta em breve!", "OK");
    }

    private async void OnPremiumTapped(object? sender, EventArgs e)
    {
        await Close();
        await Shell.Current.DisplayAlert("Premium ⭐", "Funcionalidade Premium em breve!", "OK");
    }

    private async void OnLogoffTapped(object? sender, EventArgs e)
    {
        await Close();
        bool confirm = await Shell.Current.DisplayAlert("Logoff", "Deseja realmente sair?", "Sim", "Cancelar");
        if (confirm)
        {
            Preferences.Default.Remove("user_name");
            Preferences.Default.Remove("onboarding_completed");
            Application.Current!.Windows[0].Page = new Views.OnboardingScreen();
        }
    }
}