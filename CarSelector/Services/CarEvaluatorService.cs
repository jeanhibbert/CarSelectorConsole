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

        public CarRaceTrackEvaluation[] EvaluateCarsAgainstRaceTrack(
            RaceTrack raceTrack, CarConfiguration[] carConfigurations)
        {
            CarRaceTrackEvaluation[] carRaceTrackEvaluations = new CarRaceTrackEvaluation[carConfigurations.Length];

            for (int i = 0; i < carConfigurations.Length; i++)
            {
                carRaceTrackEvaluations[i] = DetermineCompletionTime(raceTrack, carConfigurations[i]);
            }

            QuickSort<CarRaceTrackEvaluation> evaluationSorter = new QuickSort<CarRaceTrackEvaluation>(carRaceTrackEvaluations);
            evaluationSorter.Sort();

            return evaluationSorter.Output;
        }
    }
}
