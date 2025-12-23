using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Strava.Models;

namespace Strava.ViewModels;

public partial class OnboardingViewModel : ObservableObject
{
    [ObservableProperty]
    private int _position;
    
    public ObservableCollection<OnBoardingModel> Items { get; }

    public OnboardingViewModel()
    {
        Items = new ObservableCollection<OnBoardingModel>
        {
            new OnBoardingModel
            {
                IntroTitle = "Rastreie suas atividades",
                IntroDescription = "Grave suas corridas, pedaladas e muito mais",
                IntroImage = "running.png"
            },
            
            
            new OnBoardingModel
            {
                IntroTitle = "Rastreie suas atividades",
                IntroDescription = "BBd",
                IntroImage = "running.png"
            }
            
        };
    }

    [RelayCommand]
    private void FinishOnBoarding()
    {

        // Troca a Root Page para o AppShell (Navegação principal)
        Application.Current.MainPage = new AppShell();
    }
}