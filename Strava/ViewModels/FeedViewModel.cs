using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Strava.Models;
using Strava.Views;

namespace Strava.ViewModels;

public partial class FeedViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _userName = string.Empty;

    public ObservableCollection<ClubSuggestionModel> ClubSuggestions { get; } = new();
    public ObservableCollection<ActivityCardModel> Activities { get; } = new();

    public FeedViewModel()
    {
        UserName = Preferences.Default.Get("user_name", "John");

        LoadClubs();
        LoadActivities();
    }

    private void LoadClubs()
    {
        ClubSuggestions.Add(new ClubSuggestionModel
        {
            ClubName = "Run Nation",
            Subtitle = "With Sarah + friends",
            ClubLogoSource = "run_nation.png"
        });
        ClubSuggestions.Add(new ClubSuggestionModel
        {
            ClubName = "Pedal Leve",
            Subtitle = "Grupo de ciclismo iniciante",
            ClubLogoSource = "pedal.png"
        });
        ClubSuggestions.Add(new ClubSuggestionModel
        {
            ClubName = "Trilheiros da Serra",
            Subtitle = "Aventuras de fim de semana",
            ClubLogoSource = "trilheiros_serra.jpg"
        });
        ClubSuggestions.Add(new ClubSuggestionModel
        {
            ClubName = "Coastal Cyclists",
            Subtitle = "Will James + 9 friends",
            ClubLogoSource = "coastal.jpg"
        });
    }

    private void LoadActivities()
    {
        Activities.Add(new ActivityCardModel
        {
            UserName = "Sarah James",
            UserImage = "sarah.jpg",
            LocationDate = "Yesterday, Conquista",
            Title = "Afternoon Ride",
            Stat1Label = "Distance",
            Stat1Value = "2.28km",
            Stat2Label = "Time",
            Stat2Value = "22m 9s",
            MapImage = "https://maps.geoapify.com/v1/staticmap?style=osm-bright-smooth&width=600&height=300&center=lonlat:-40.837,-14.862&zoom=15&apiKey=ac7d466254be49a0bdd1b32b620fd7dd",
        });

        Activities.Add(new ActivityCardModel
        {
            UserName = "JPedro",
            UserImage = "jonh.jpg",
            LocationDate = "Today, Brazil",
            Title = "Night Run",
            Stat1Label = "Distance",
            Stat1Value = "5.00km",
            Stat2Label = "Time",
            Stat2Value = "30m",
            MapImage = "https://maps.geoapify.com/v1/staticmap?style=osm-bright-smooth&width=600&height=300&center=lonlat:-40.844,-14.858&zoom=15&apiKey=ac7d466254be49a0bdd1b32b620fd7dd",
        });

        Activities.Add(new ActivityCardModel
        {
            UserName = "Maria Silva",
            UserImage = "maria.jpg",
            LocationDate = "2 days ago, Conquista",
            Title = "Morning Hike",
            Stat1Label = "Distance",
            Stat1Value = "8.5km",
            Stat2Label = "Time",
            Stat2Value = "1h 15m",
            MapImage = "https://maps.geoapify.com/v1/staticmap?style=osm-bright-smooth&width=600&height=300&center=lonlat:-40.830,-14.870&zoom=15&apiKey=ac7d466254be49a0bdd1b32b620fd7dd",
        });
    }

    [RelayCommand]
    private async Task NavigateToActivity(string activityType)
    {
        if (string.IsNullOrWhiteSpace(activityType)) return;
        await Shell.Current.GoToAsync($"{nameof(ActivityDetailPage)}?type={activityType}");
    }

    [RelayCommand]
    private void RemoveClub(ClubSuggestionModel club)
    {
        if (club != null && ClubSuggestions.Contains(club))
            ClubSuggestions.Remove(club);
    }

    [RelayCommand]
    private async Task JoinClub(ClubSuggestionModel club)
    {
        if (club == null) return;
        await Shell.Current.DisplayAlert("Joined! 🎉", $"You joined {club.ClubName}!", "OK");
        ClubSuggestions.Remove(club);
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
    private async Task OpenActivity(ActivityCardModel activity)
    {
        if (activity == null) return;
        await Shell.Current.GoToAsync(nameof(GoToUserProfile));
    }
}