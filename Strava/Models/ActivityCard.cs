namespace Strava.Models;

public class ActivityCard
{
    public string UserName { get; set; }        // Ex: Sarah James
    public string UserImage { get; set; }       // Foto do perfil
    public string LocationDate { get; set; }    // Ex: Yesterday, LA
    
    public string Title { get; set; }           // Ex: Afternoon Ride
    public string Stat1Value { get; set; }      // Ex: 2.28 km
    public string Stat1Label { get; set; }      // Ex: Distance
    public string Stat2Value { get; set; }      // Ex: 22m 9s
    public string Stat2Label { get; set; }      // Ex: Time
    
    public string MapImage { get; set; }
}