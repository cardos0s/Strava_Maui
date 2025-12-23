using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strava.Models;
using Strava.ViewModels; 
using System.Diagnostics;

namespace Strava.Views;

public partial class FeedPage : ContentPage
{
    
    public FeedPage()
    {
        InitializeComponent();

        // 1. Instancia a ViewModel
        var viewModel = new FeedViewModel();

        // 2. Define o Contexto da Página (para Comandos, etc)
        BindingContext = viewModel;
        
    }
}