using System.Windows.Input;

namespace Strava.Views.Components;

public partial class ActivityCard : ContentView
{
    public static readonly BindableProperty UserNameProperty =
        BindableProperty.Create(nameof(UserName), typeof(string), typeof(ActivityCard), "User");

    public static readonly BindableProperty UserImageProperty =
        BindableProperty.Create(nameof(UserImage), typeof(string), typeof(ActivityCard), "profile_placeholder.png");

    public static readonly BindableProperty LocationDateProperty =
        BindableProperty.Create(nameof(LocationDate), typeof(string), typeof(ActivityCard), string.Empty);

    public static readonly BindableProperty ActivityTitleProperty =
        BindableProperty.Create(nameof(ActivityTitle), typeof(string), typeof(ActivityCard), string.Empty);

    public static readonly BindableProperty Stat1LabelProperty =
        BindableProperty.Create(nameof(Stat1Label), typeof(string), typeof(ActivityCard), "Distance");

    public static readonly BindableProperty Stat1ValueProperty =
        BindableProperty.Create(nameof(Stat1Value), typeof(string), typeof(ActivityCard), "0.0 km");

    public static readonly BindableProperty Stat2LabelProperty =
        BindableProperty.Create(nameof(Stat2Label), typeof(string), typeof(ActivityCard), "Time");

    public static readonly BindableProperty Stat2ValueProperty =
        BindableProperty.Create(nameof(Stat2Value), typeof(string), typeof(ActivityCard), "0m");

    public static readonly BindableProperty MapImageProperty =
        BindableProperty.Create(nameof(MapImage), typeof(string), typeof(ActivityCard), "map_sample_orange.png");

    public static readonly BindableProperty TapCommandProperty =
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(ActivityCard));

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ActivityCard));

    public string UserName
    {
        get => (string)GetValue(UserNameProperty);
        set => SetValue(UserNameProperty, value);
    }

    public string UserImage
    {
        get => (string)GetValue(UserImageProperty);
        set => SetValue(UserImageProperty, value);
    }

    public string LocationDate
    {
        get => (string)GetValue(LocationDateProperty);
        set => SetValue(LocationDateProperty, value);
    }

    public string ActivityTitle
    {
        get => (string)GetValue(ActivityTitleProperty);
        set => SetValue(ActivityTitleProperty, value);
    }

    public string Stat1Label
    {
        get => (string)GetValue(Stat1LabelProperty);
        set => SetValue(Stat1LabelProperty, value);
    }

    public string Stat1Value
    {
        get => (string)GetValue(Stat1ValueProperty);
        set => SetValue(Stat1ValueProperty, value);
    }

    public string Stat2Label
    {
        get => (string)GetValue(Stat2LabelProperty);
        set => SetValue(Stat2LabelProperty, value);
    }

    public string Stat2Value
    {
        get => (string)GetValue(Stat2ValueProperty);
        set => SetValue(Stat2ValueProperty, value);
    }

    public string MapImage
    {
        get => (string)GetValue(MapImageProperty);
        set => SetValue(MapImageProperty, value);
    }

    public ICommand TapCommand
    {
        get => (ICommand)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public ActivityCard()
    {
        InitializeComponent();
    }
}