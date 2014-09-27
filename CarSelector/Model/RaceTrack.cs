namespace CarSelector.Model
{
    public class RaceTrack
    {
        public double LapDistance { get; set; } // Measured in Kilometers
        public int NoOfLapsToComplete { get; set; }
        public int PitstopTimespan { get; set; } // Measured in Seconds
    }
}
