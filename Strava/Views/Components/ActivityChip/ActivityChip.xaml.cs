using System.Windows.Input;

namespace Strava.Views.Components.ActivityChip;

public partial class ActivityChip : ContentView
{
    public ActivityChip()
    {
        InitializeComponent();
    }

    // Text
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ActivityChip), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // Icon
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(string), typeof(ActivityChip), string.Empty);

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    // IsSelected
    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(
            nameof(IsSelected), typeof(bool), typeof(ActivityChip), false,
            propertyChanged: (b, _, _) => ((ActivityChip)b).UpdateVisualState());

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    // TapCommand
    public static readonly BindableProperty TapCommandProperty =
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(ActivityChip));

    public ICommand TapCommand
    {
        get => (ICommand)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }

    // Computed colors
    public Color ChipBackground => IsSelected ? Color.FromArgb("#FC4C02") : Colors.White;
    public Color LabelColor => IsSelected ? Colors.White : Color.FromArgb("#666666");
    public Color BorderColor => IsSelected ? Color.FromArgb("#FC4C02") : Color.FromArgb("#E0E0E0");

    private void UpdateVisualState()
    {
        OnPropertyChanged(nameof(ChipBackground));
        OnPropertyChanged(nameof(LabelColor));
        OnPropertyChanged(nameof(BorderColor));
    }
}