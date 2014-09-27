namespace CarSelector.Model
{
    public class CarRaceTrackEvaluation
    {
        public RaceTrack RaceTrack { get; set; }

        public CarConfiguration CarConfiguration { get; set; }

        public double CompletionTime { get; set; }

        public CarRaceTrackEvaluation(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            this.RaceTrack = raceTrack;
            this.CarConfiguration = carConfiguration;
        }
    }
}
