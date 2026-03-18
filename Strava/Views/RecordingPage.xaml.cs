namespace Strava.Views;

public partial class RecordingPage : ContentPage
{
    private readonly ViewModels.RecordingViewModel _vm;

    public RecordingPage(ViewModels.RecordingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.StartRecording();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _vm.StopRecording();
    }

    private void OnPauseTapped(object? sender, EventArgs e)
    {
        _vm.TogglePause();
    }

    private async void OnCloseTapped(object? sender, EventArgs e)
    {
        bool confirm = await Shell.Current.DisplayAlert(
            "Encerrar atividade",
            "Deseja encerrar a gravação?",
            "Sim", "Continuar");

        if (confirm)
        {
            _vm.StopRecording();
            await Shell.Current.GoToAsync("..");
        }
    }

    private async void OnMusicTapped(object? sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Música", "Conectar ao Spotify ou Apple Music em breve!", "OK");
    }

    protected override bool OnBackButtonPressed()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            bool confirm = await Shell.Current.DisplayAlert(
                "Encerrar atividade",
                "Deseja encerrar a gravação?",
                "Sim", "Continuar");

            if (confirm)
            {
                _vm.StopRecording();
                await Shell.Current.GoToAsync("..");
            }
        });

        return true;
    }
}