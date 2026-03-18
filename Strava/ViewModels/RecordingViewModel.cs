using CommunityToolkit.Mvvm.ComponentModel;

namespace Strava.ViewModels;

[QueryProperty(nameof(ActivityType), "type")]
public partial class RecordingViewModel : BaseViewModel
{
    private IDispatcherTimer? _timer;
    private int _elapsedSeconds = 0;
    private bool _isPaused = false;
    private double _distance = 0;
    private readonly Random _random = new();

    [ObservableProperty]
    private string _activityType = "run";

    [ObservableProperty]
    private string _distanceDisplay = "0,00";

    [ObservableProperty]
    private string _paceDisplay = "0'00\"";

    [ObservableProperty]
    private string _bpmDisplay = "--";

    [ObservableProperty]
    private string _timeDisplay = "00:00";

    [ObservableProperty]
    private string _buttonText = "PAUSAR";

    [ObservableProperty]
    private string _backgroundImage = "running.png";

    [ObservableProperty]
    private string _unitLabel = "Quilômetros";

    partial void OnActivityTypeChanged(string value)
    {
        switch (value?.ToLower())
        {
            case "swim":
                BackgroundImage = "natacaos.png";
                UnitLabel = "Metros";
                break;
            case "bike":
                BackgroundImage = "pedalando.jpg";
                UnitLabel = "Quilômetros";
                break;
            case "run":
            default:
                BackgroundImage = "runnings.jpg";
                UnitLabel = "Quilômetros";
                break;
        }
    }

    public void StartRecording()
    {
        OnActivityTypeChanged(ActivityType);
        
        _elapsedSeconds = 0;
        _distance = 0;
        _isPaused = false;
        ButtonText = "PAUSAR";

        UpdateDisplays();

        _timer = Application.Current?.Dispatcher.CreateTimer();
        if (_timer == null) return;

        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += OnTimerTick;
        _timer.Start();
    }

    public void StopRecording()
    {
        _timer?.Stop();
        _timer = null;
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        ButtonText = _isPaused ? "RETOMAR" : "PAUSAR";
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        if (_isPaused) return;

        _elapsedSeconds++;

        // Velocidade varia por tipo de atividade
        double speed = ActivityType?.ToLower() switch
        {
            "swim" => 0.00167,   // ~1.67m/s = ~6km/h
            "bike" => 0.00556,   // ~5.56m/s = ~20km/h
            _ => 0.00278         // ~2.78m/s = ~10km/h (run)
        };

        _distance += speed + (_random.NextDouble() * 0.001);

        UpdateDisplays();
    }

    private void UpdateDisplays()
    {
        // Distância
        if (ActivityType?.ToLower() == "swim")
        {
            // Metros para natação
            DistanceDisplay = ((int)(_distance * 1000)).ToString();
        }
        else
        {
            DistanceDisplay = _distance.ToString("F2").Replace(".", ",");
        }

        // Tempo
        var minutes = _elapsedSeconds / 60;
        var seconds = _elapsedSeconds % 60;
        TimeDisplay = $"{minutes:D2}:{seconds:D2}";

        // Pace (min/km)
        if (_distance > 0.01)
        {
            var paceMinutes = (_elapsedSeconds / 60.0) / _distance;
            var paceMin = (int)paceMinutes;
            var paceSec = (int)((paceMinutes - paceMin) * 60);
            PaceDisplay = $"{paceMin}'{paceSec:D2}\"";
        }
        else
        {
            PaceDisplay = "0'00\"";
        }

        // BPM simulado
        if (_elapsedSeconds > 3)
        {
            int baseBpm = ActivityType?.ToLower() switch
            {
                "swim" => 110 + (_elapsedSeconds / 8),
                "bike" => 95 + (_elapsedSeconds / 12),
                _ => 102 + (_elapsedSeconds / 10)
            };
            var bpm = Math.Min(baseBpm + _random.Next(-3, 4), 185);
            BpmDisplay = bpm.ToString();
        }
    }
}