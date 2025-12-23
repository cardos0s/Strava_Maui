using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidX.Lifecycle;
using Strava.ViewModels;

namespace Strava.Views;

public partial class OnboardingScreen : ContentPage
{
    
    public OnboardingScreen(OnboardingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}