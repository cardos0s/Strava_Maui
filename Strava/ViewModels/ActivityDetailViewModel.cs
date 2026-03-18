using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Strava.Models;

namespace Strava.ViewModels;

[QueryProperty(nameof(ActivityType), "type")]
public partial class ActivityDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _activityType = "Bike";

    [ObservableProperty]
    private ActivityCardModel? _todayActivity;

    [ObservableProperty]
    private string _streakMessage = "Complete 4 more workouts this week to start your streak";

    [ObservableProperty]
    private int _streakCompleted = 1;

    [ObservableProperty]
    private int _streakTotal = 5;

    public Color ChipColor => Color.FromArgb("#FC5200");

    public ObservableCollection<RaceCardModel> WeekRaces { get; } = new();
    public ObservableCollection<StreakDay> StreakDays { get; } = new();

    public ActivityDetailViewModel()
    {
        LoadData();
        LoadStreak();
    }

    private void LoadData()
    {
        TodayActivity = new ActivityCardModel
        {
            UserName = "Mi. Brooks",
            UserImage = "pos_corrida.png",
            LocationDate = "Today",
            Title = "Morning Ride",
            Stat1Label = "Distance",
            Stat1Value = "8.25km",
            Stat2Label = "Duration",
            Stat2Value = "32m",
            MapImage = "pos_corrida.png"
        };

        WeekRaces.Add(new RaceCardModel
        {
            Title = "Hill Climb Challenge",
            ImageSource = "ciclista.jpeg",
            Location = "Mt. Wilson · LA",
            Distance = "24.8km/1:1.5h"
        });

        WeekRaces.Add(new RaceCardModel
        {
            Title = "Swimming",
            ImageSource = "natacao.jpg",
            Location = "Malibu · LA",
            Distance = "18.2km/1:1h"
        });
    }

    private void LoadStreak()
    {
        // 5 dias da semana, 1 completado
        StreakDays.Add(new StreakDay { IsCompleted = true });
        StreakDays.Add(new StreakDay { IsCompleted = false });
        StreakDays.Add(new StreakDay { IsCompleted = false });
        StreakDays.Add(new StreakDay { IsCompleted = false });
        StreakDays.Add(new StreakDay { IsCompleted = false });
    }
}

public class StreakDay
{
    public bool IsCompleted { get; set; }
    public double FireOpacity => IsCompleted ? 1.0 : 0.25;
}