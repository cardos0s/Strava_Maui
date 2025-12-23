using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kotlin.Reflect;

namespace Strava.Views.Components;

public partial class ClubCard : ContentView
{
    // ============================================================================
    // PROPRIEDADES VISUAIS (Dados)
    // ============================================================================

    public static readonly BindableProperty ClubNameProperty =
        BindableProperty.Create(nameof(ClubName), typeof(string), typeof(ClubCard), string.Empty);

    // Subtítulo (ex: "With Sarah + friends") - Opcional, pode deixar fixo se preferir
    public static readonly BindableProperty SubtitleProperty =
        BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(ClubCard), "With friends");

    // Imagem do logo do clube
    public static readonly BindableProperty ClubLogoSourceProperty =
        BindableProperty.Create(nameof(ClubLogoSource), typeof(ImageSource), typeof(ClubCard), null);

    // ============================================================================
    // PROPRIEDADES DE COMANDO (Ações)
    // ============================================================================
    public static readonly BindableProperty CloseCommandProperty =
        BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(ClubCard));
    
    public static readonly BindableProperty CommandParameterProperty = 
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ClubCard));
    
    public static readonly BindableProperty JoinCommandProperty =
        BindableProperty.Create(nameof(JoinCommand), typeof(ICommand), typeof(ClubCard));

    // ============================================================================
    // ACESSORES PÚBLICOS
    // ============================================================================
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

    public ImageSource ClubLogoSource
    {
        get => (ImageSource)GetValue(ClubLogoSourceProperty);
        set => SetValue(ClubLogoSourceProperty, value);
    }
    
    
    public ICommand CloseCommand
    {
        get => (ICommand)GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
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