using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Strava.Models;
using Strava.Views;


namespace Strava.ViewModels;

public partial class FeedViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _userName;

    public ObservableCollection<ClubSuggestionModel> ClubSuggestions { get; } = new();
    public ObservableCollection<ActivityCard> Activities { get; } = new();

    public FeedViewModel()
    {
        UserName = Preferences.Default.Get("user_name", "Atleta");

        ClubSuggestions.Add(new ClubSuggestionModel
        {
            ClubName = "Run Nation",
            Subtitle = "With Sarah + friends",
            ClubLogoSource = "dotnet_bot.png"
        });
        ClubSuggestions.Add(new ClubSuggestionModel
        {
            ClubName = "Pedal Leve",
            Subtitle = "Grupo de ciclismo iniciante",
            ClubLogoSource = "dotnet_bot.png" 
        });
        ClubSuggestions.Add(new ClubSuggestionModel
        {
            ClubName = "Trilheiros da Serra",
            Subtitle = "Aventuras de fim de semana",
            ClubLogoSource = "dotnet_bot.png"
        });
        Activities.Add(new ActivityCard
        {
            UserName = "Sarah James",
            UserImage = "dotnet_bot.png", // Provisório
            LocationDate = "Yesterday, LA",
            Title = "Afternoon Ride",
            Stat1Label = "Distance", Stat1Value = "2.28km",
            Stat2Label = "Time", Stat2Value = "22m",
            MapImage = "dotnet_bot.png" // Provisório
        });

        Activities.Add(new ActivityCard
        {
            UserName = "John Sanaarh",
            UserImage = "dotnet_bot.png",
            LocationDate = "Today, Brazil",
            Title = "Night Run",
            Stat1Label = "Distance", Stat1Value = "5.00km",
            Stat2Label = "Time", Stat2Value = "30m",
            MapImage = "dotnet_bot.png"
        });
        
    }
    

    
    [RelayCommand]
    private void RemoveClub(ClubSuggestionModel club)
    {
        if (ClubSuggestions.Contains(club))
            ClubSuggestions.Remove(club);
    }

    [RelayCommand]
    private async Task JoinClub(ClubSuggestionModel club)
    {
        await Shell.Current.DisplayAlert(
            "Sucesso",
            $"Solicitação enviada para {club.ClubName}",
            "OK"
        );
    }

    [RelayCommand]
    private void SaveName(string newName)
    {
        if (!string.IsNullOrWhiteSpace(newName))
        {
            UserName = newName;
            Preferences.Default.Set("user_name", newName);
        }
    }
    [RelayCommand]
    private async Task OpenActivity(ActivityCard activity)
    {
        if (activity == null) return;


        await Shell.Current.GoToAsync(nameof(GoToUserProfile));
        await App.Current.MainPage.DisplayAlert("Navegação", $"Abrindo post de {activity.UserName}", "OK");
    }
    
}