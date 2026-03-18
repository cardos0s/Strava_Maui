using System.Windows.Input;

namespace Strava.Views.Components;

public partial class ClubCard : ContentView
{
    public static readonly BindableProperty ClubNameProperty =
        BindableProperty.Create(nameof(ClubName), typeof(string), typeof(ClubCard), string.Empty);

    public static readonly BindableProperty SubtitleProperty =
        BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(ClubCard), string.Empty);

    public static readonly BindableProperty ClubLogoSourceProperty =
        BindableProperty.Create(nameof(ClubLogoSource), typeof(string), typeof(ClubCard), string.Empty);

    public static readonly BindableProperty DismissCommandProperty =
        BindableProperty.Create(nameof(DismissCommand), typeof(ICommand), typeof(ClubCard));

    public static readonly BindableProperty JoinCommandProperty =
        BindableProperty.Create(nameof(JoinCommand), typeof(ICommand), typeof(ClubCard));

    public string ClubName
    {
        get => (string)GetValue(ClubNameProperty);
        set => SetValue(ClubNameProperty, value);
    }

    public string Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    public string ClubLogoSource
    {
        get => (string)GetValue(ClubLogoSourceProperty);
        set => SetValue(ClubLogoSourceProperty, value);
    }

    public ICommand DismissCommand
    {
        get => (ICommand)GetValue(DismissCommandProperty);
        set => SetValue(DismissCommandProperty, value);
    }

    public ICommand JoinCommand
    {
        get => (ICommand)GetValue(JoinCommandProperty);
        set => SetValue(JoinCommandProperty, value);
    }

    public ClubCard()
    {
        InitializeComponent();
    }
}