using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strava.Views.Components;

public partial class CustomTabBar : ContentView
{
    private async void OnHomeClicked(object sender, EventArgs e) 
        => await Shell.Current.GoToAsync("//FeedPage");

    private async void OnMapsClicked(object sender, EventArgs e) 
        => await Shell.Current.GoToAsync("//MapPage");

    private async void OnProfileClicked(object sender, EventArgs e) 
        => await Shell.Current.GoToAsync("//ProfilePage");
    private async void OnGroupsClicked(object sender, EventArgs e)
        => await App.Current.MainPage.DisplayAlert("Em breve", "Funcionalidade de Grupos!", "OK");
    
    private async void OnRecordTapped(object sender, TappedEventArgs e)
       => await App.Current.MainPage.DisplayAlert("Record", "Iniciando atividade...", "OK");
    
    public CustomTabBar()
    {
        InitializeComponent();
        Shell.Current.Navigated += Current_Navigated;
    }

    private void Current_Navigated(object? sender, ShellNavigatedEventArgs e)
    {
        var currentRoute = e.Current.Location.ToString();
        SetInactive(ImgHome);
        SetInactive(ImgMaps);
        SetInactive(ImgGroups);
        SetInactive(ImgProfile);

        // Destaca apenas o que bate com a rota atual
        if (currentRoute.Contains("FeedPage")) SetActive(ImgHome);
        else if (currentRoute.Contains("MapPage")) SetActive(ImgMaps);
        else if (currentRoute.Contains("ProfilePage")) SetActive(ImgProfile);
        // else if (currentRoute.Contains("Groups")) SetActive(ImgGroups);
    }
    private void SetActive(Image img)
    {
        img.Opacity = 1.0;
        img.Scale = 1.2; // Aumenta 20%
    }

    // Helper para deixar apagado (Inativo)
    private void SetInactive(Image img)
    {
        img.Opacity = 0.5; // 50% transparente
        img.Scale = 1.0;   // Tamanho normal
    }
}