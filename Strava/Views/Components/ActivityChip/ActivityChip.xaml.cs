using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strava.Views.Components.ActivityChip;

public partial class ActivityChip : ContentView
{
    public ActivityChip()
    {
        InitializeComponent();
        UpdateVisualState();
    }
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ActivityChip));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // Ícone
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(string), typeof(ActivityChip));

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    // Seleção
    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(ActivityChip),
            false,
            propertyChanged: (_, __, ___) => ((ActivityChip)_)!.UpdateVisualState()
        );

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    // Cores derivadas do estado
    public Color ChipBackground => IsSelected ? Color.FromArgb("#FC4C02") : Colors.White;
    public Color TextColor => IsSelected ? Colors.White : Colors.Gray;

    private void UpdateVisualState()
    {
        OnPropertyChanged(nameof(ChipBackground));
        OnPropertyChanged(nameof(TextColor));
    }
}