using CarSelector.Model;

namespace CarSelector.Services
{
    public class CarEvaluatorService
    {
        public CarRaceTrackEvaluation DetermineCompletionTime(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            CarRaceTrackEvaluation carRaceTrackEvaluation = new CarRaceTrackEvaluation(raceTrack, carConfiguration);

            int totalPitstopsRequired = (int)(raceTrack.NoOfLapsToComplete / (carConfiguration.FuelCapacity / carConfiguration.AverageFuelConsumptionPerLap));

            carRaceTrackEvaluation.CompletionTime = carConfiguration.TimeToCompleteLap * raceTrack.NoOfLapsToComplete + totalPitstopsRequired * raceTrack.PitstopTimespan;

            return carRaceTrackEvaluation;
        }
    }
}
