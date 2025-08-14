class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * LapLengthMeters) / 1000; // km
    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
}