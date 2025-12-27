namespace Strava.Views;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
        LoadMap();
    }

    private void LoadMap()
    {
        // HTML simples que carrega o Leaflet (OpenStreetMap)
        // Centralizado em Vitória da Conquista: [-14.8661, -40.8394]
        var htmlSource = new HtmlWebViewSource();
        htmlSource.Html = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no' />
                <link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css' />
                <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
                <style>
                    body { margin: 0; padding: 0; }
                    #map { height: 100vh; width: 100vw; }
                </style>
            </head>
            <body>
                <div id='map'></div>
                <script>
                    // 1. Inicializa o mapa
                    var map = L.map('map').setView([-14.8661, -40.8394], 15);

                    // 2. Carrega os azulejos do OpenStreetMap (Grátis)
                    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                        attribution: '© OpenStreetMap contributors'
                    }).addTo(map);

                    // 3. Adiciona um marcador (Pin)
                    L.marker([-14.8661, -40.8394]).addTo(map)
                        .bindPopup('Você está aqui!')
                        .openPopup();
                </script>
            </body>
            </html>";

        MapWebView.Source = htmlSource;
    }
}