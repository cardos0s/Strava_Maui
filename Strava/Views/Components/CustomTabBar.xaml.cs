using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strava.Views.Components;

public partial class CustomTabBar : ContentView
{
    private async void OnHomeClicked(object sender, EventArgs e) 
        => await Shell.Current.GoToAsync("//Feed");

    private async void OnMapsClicked(object sender, EventArgs e) 
        => await Shell.Current.GoToAsync("//Maps");

    private async void OnProfileClicked(object sender, EventArgs e) 
        => await Shell.Current.GoToAsync("//Profile");
    private async void OnGroupsClicked(object sender, EventArgs e)
    {
        // Se você ainda não tem essa página, o app pode dar erro. 
        // Certifique-se de que a rota existe no AppShell.
    }
    private async void OnRecordTapped(object sender, TappedEventArgs e)
    {
        // Geralmente o botão de gravação abre uma página Modal (de baixo para cima)
        // await Shell.Current.GoToAsync(nameof(RecordPage));
        await App.Current.MainPage.DisplayAlert("Record", "Iniciando atividade...", "OK");
    }
    public CustomTabBar()
    {
        InitializeComponent();
    }
    
}