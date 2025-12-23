using System.Windows.Input;

namespace Strava.Views.Components;

public partial class ActivityCard : ContentView
{
    public static readonly BindableProperty UserNameProperty = 
        BindableProperty.Create(nameof(UserName), typeof(string), typeof(ActivityCard), "User");

    public static readonly BindableProperty DistanceProperty = 
        BindableProperty.Create(nameof(Distance), typeof(string), typeof(ActivityCard), "0.0 km");
    
    public static readonly BindableProperty TapCommandProperty =
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(ActivityCard));
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ActivityCard));

    public string UserName
    {
        get => (string)GetValue(UserNameProperty);
        set => SetValue(UserNameProperty, value);
    }

    public string Distance
    {
        get => (string)GetValue(DistanceProperty);
        set => SetValue(DistanceProperty, value);
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