using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Strava;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        HideSystemBars();
    }

    protected override void OnResume()
    {
        base.OnResume();
        HideSystemBars();
    }

    public override void OnWindowFocusChanged(bool hasFocus)
    {
        base.OnWindowFocusChanged(hasFocus);

        if (hasFocus)
            HideSystemBars();
    }

    private void HideSystemBars()
    {
        if (Window?.DecorView == null)
            return;

        Window.DecorView.SystemUiVisibility =
            (StatusBarVisibility)(
                SystemUiFlags.Fullscreen |
                SystemUiFlags.HideNavigation |
                SystemUiFlags.ImmersiveSticky |
                SystemUiFlags.LayoutFullscreen |
                SystemUiFlags.LayoutHideNavigation |
                SystemUiFlags.LayoutStable
            );
    }
}