using CarSelector.Contracts;
using CarSelector.Model;

namespace CarSelector.Services
{
    public class CarEvaluatorService : ICarEvaluatorService
    {
        public virtual CarRaceTrackEvaluation Evaluate(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            CarRaceTrackEvaluation carRaceTrackEvaluation = new CarRaceTrackEvaluation(raceTrack, carConfiguration);

            // Determine total pitstops and round down by casting to int
            int totalPitstopsRequired = (int)(raceTrack.NoOfLapsToComplete / (carConfiguration.FuelCapacity / carConfiguration.AverageFuelConsumptionPerLap));

            carRaceTrackEvaluation.CompletionTime = carConfiguration.TimeToCompleteLap * raceTrack.NoOfLapsToComplete + totalPitstopsRequired * raceTrack.PitstopTimespan;

            return carRaceTrackEvaluation;
        }

        public virtual  CarRaceTrackEvaluation[] EvaluateAndSort(
            RaceTrack raceTrack, CarConfiguration[] carConfigurations)
        {
            CarRaceTrackEvaluation[] carRaceTrackEvaluations = new CarRaceTrackEvaluation[carConfigurations.Length];

            for (int i = 0; i < carConfigurations.Length; i++)
            {
                carRaceTrackEvaluations[i] = this.Evaluate(raceTrack, carConfigurations[i]);
            }

            QuickSort<CarRaceTrackEvaluation> evaluationSorter = new QuickSort<CarRaceTrackEvaluation>(carRaceTrackEvaluations);
            evaluationSorter.Sort();

            return evaluationSorter.Output;
        }
    }
}
