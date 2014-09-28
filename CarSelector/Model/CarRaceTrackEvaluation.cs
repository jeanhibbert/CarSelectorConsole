namespace CarSelector.Model
{
    public class CarRaceTrackEvaluation : ICompletionTime
    {
        public RaceTrack RaceTrack { get; set; }

        public CarConfiguration CarConfiguration { get; set; }

        public double CompletionTime { get; set; } // Measured in seconds

        public CarRaceTrackEvaluation(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            this.RaceTrack = raceTrack;
            this.CarConfiguration = carConfiguration;
        }

        public override string ToString()
        {
            return string.Format(
                "Completion Time {6} seconds. \n Car {0} Av. Fuel Consump. Per Lap, {1} Fuel Capacity, {2} Time to complete lap \n Track {3} Lap Distance, {4} no. of laps to complete, {5} Pitstop timespan",
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
