namespace Strava;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.ActivityDetailPage), typeof(Views.ActivityDetailPage));
        Routing.RegisterRoute(nameof(Views.GoToUserProfile), typeof(Views.GoToUserProfile));
        Routing.RegisterRoute(nameof(Views.RecordingPage), typeof(Views.RecordingPage));
    }
}