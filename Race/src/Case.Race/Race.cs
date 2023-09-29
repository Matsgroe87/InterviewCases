namespace Case.Race;

public class Race
{
    public Race(string raceTrack, Contestant[] contestants)
    {
        RaceTrack = raceTrack;
        Contestants = contestants;
    }

    public Contestant[] Contestants { get; }

    public string RaceTrack { get; }

    public void Start()
    {
        int lengthOfTrackInKm = 10;

        foreach (Contestant contestant in Contestants)
        {
            decimal skillLevelDriver = contestant.Driver.SkillLevel;
            if (skillLevelDriver > contestant.Car.HandelingLevel) skillLevelDriver = contestant.Car.HandelingLevel;

            decimal averageSpeed = contestant.Car.TopSpeed * (skillLevelDriver / contestant.Car.HandelingLevel);
            decimal totalHours = lengthOfTrackInKm / averageSpeed;
            
            TimeSpan contestantLapTime = TimeSpan.FromHours((double)totalHours);
            
            Console.WriteLine($"Elapsed time for contestant, driving {contestant.Car.Brand}, is {Math.Round(contestantLapTime.TotalHours,1)} hours");
        }
    }
}
