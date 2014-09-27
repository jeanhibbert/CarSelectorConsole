namespace CarSelector.Model
{
    public class CarRaceTrackEvaluation : ICompletionTime
    {
        public RaceTrack RaceTrack { get; set; }

        public CarConfiguration CarConfiguration { get; set; }

        public double CompletionTime { get; set; }

        public CarRaceTrackEvaluation(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            this.RaceTrack = raceTrack;
            this.CarConfiguration = carConfiguration;
        }

        public override string ToString()
        {
            return string.Format(
                "Completion Time {6} : Car {0} - {1} - {2} : Track {3} - {4} - {5}",
                CarConfiguration.AverageFuelConsumptionPerLap,
                CarConfiguration.FuelCapacity,
                CarConfiguration.TimeToCompleteLap,
                RaceTrack.LapDistance,
                RaceTrack.NoOfLapsToComplete,
                RaceTrack.PitstopTimespan,
                CompletionTime);
        }
    }
}
