
using Strava.Views;

namespace Strava;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(GoToUserProfile), typeof(GoToUserProfile));
    }
}