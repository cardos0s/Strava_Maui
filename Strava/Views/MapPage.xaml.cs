namespace Strava.Views;

public partial class MapPage : ContentPage
{
    private bool _isSheetOpen = false;

    public MapPage()
    {
        InitializeComponent();
        LoadMap();
    }

    private void LoadMap()
    {
        var htmlSource = new HtmlWebViewSource();
        htmlSource.Html = @"
<!DOCTYPE html>
<html>
<head>
    <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no' />
    <link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css' />
    <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
    <style>
        * { margin: 0; padding: 0; }
        html, body { height: 100%; overflow: hidden; }
        #map { height: 100%; width: 100%; }
        .leaflet-control-attribution { display: none !important; }
        .leaflet-control-zoom { display: none !important; }
    </style>
</head>
<body>
    <div id='map'></div>
    <script>
        var map = L.map('map', {
            zoomControl: false,
            attributionControl: false
        }).setView([-14.8615, -40.8370], 15);

        L.tileLayer('https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png', {
            maxZoom: 19
        }).addTo(map);

        var routeCoords = [
            [-14.8580, -40.8410],
            [-14.8590, -40.8395],
            [-14.8605, -40.8388],
            [-14.8615, -40.8375],
            [-14.8610, -40.8355],
            [-14.8620, -40.8340],
            [-14.8635, -40.8335],
            [-14.8650, -40.8345],
            [-14.8645, -40.8360],
            [-14.8630, -40.8370],
            [-14.8625, -40.8385],
            [-14.8615, -40.8395],
            [-14.8605, -40.8388]
        ];

        L.polyline(routeCoords, {
            color: '#FC5200',
            weight: 4,
            opacity: 0.9,
            smoothFactor: 1.5,
            lineCap: 'round',
            lineJoin: 'round'
        }).addTo(map);

        L.circleMarker(routeCoords[0], {
            radius: 6, fillColor: '#FC5200', color: '#FFF', weight: 2, fillOpacity: 1
        }).addTo(map);

        L.circleMarker(routeCoords[routeCoords.length - 1], {
            radius: 10, fillColor: '#FC5200', color: '#FFF', weight: 3, fillOpacity: 1
        }).addTo(map);

        [3, 6, 9].forEach(function(i) {
            L.circleMarker(routeCoords[i], {
                radius: 5, fillColor: '#FC5200', color: '#FFF', weight: 2, fillOpacity: 0.8
            }).addTo(map);
        });

        map.fitBounds(L.polyline(routeCoords).getBounds(), {
            padding: [60, 40], maxZoom: 16
        });
    </script>
</body>
</html>";

        MapWebView.Source = htmlSource;
    }

    private async void OnStartRouteTapped(object? sender, EventArgs e)
    {
        if (_isSheetOpen) return;
        await OpenSheet();
    }

    private async void OnCloseSheet(object? sender, EventArgs e)
    {
        await CloseSheet();
    }

    private async Task OpenSheet()
    {
        _isSheetOpen = true;

        BtnStartRoute.IsVisible = false;

        Overlay.IsVisible = true;
        Overlay.InputTransparent = false;

        var overlayFade = Overlay.FadeTo(0.4, 300, Easing.CubicOut);
        var sheetSlide = BottomSheet.TranslateTo(0, 0, 350, Easing.CubicOut);

        await Task.WhenAll(overlayFade, sheetSlide);
    }

    private async Task CloseSheet()
    {
        var overlayFade = Overlay.FadeTo(0, 250, Easing.CubicIn);
        var sheetSlide = BottomSheet.TranslateTo(0, 700, 300, Easing.CubicIn);

        await Task.WhenAll(overlayFade, sheetSlide);

        Overlay.IsVisible = false;
        BtnStartRoute.IsVisible = true;

        _isSheetOpen = false;
    }

    private async void OnBackTapped(object? sender, EventArgs e)
    {
        if (_isSheetOpen)
        {
            await CloseSheet();
            return;
        }
        await Shell.Current.GoToAsync("//FeedPage");
    }
}