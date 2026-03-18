namespace Strava.Models;

public class ActivityCardModel
{
    public string UserName { get; set; } = string.Empty;
    public string UserImage { get; set; } = string.Empty;
    public string LocationDate { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
    public string Stat1Value { get; set; } = string.Empty;
    public string Stat1Label { get; set; } = string.Empty;
    public string Stat2Value { get; set; } = string.Empty;
    public string Stat2Label { get; set; } = string.Empty;

    public string MapImage { get; set; } = string.Empty;

    /// <summary>
    /// Coordenadas da rota no formato "lat,lng|lat,lng|lat,lng"
    /// Usado pelo ActivityCard pra desenhar a rota no mini mapa
    /// </summary>
    public string RouteCoordinates { get; set; } = string.Empty;
}