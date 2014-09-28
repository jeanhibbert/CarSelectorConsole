namespace CarSelector.Contracts
{
    using CarSelector.Model;

    public interface ICarEvaluatorService
    {
        /// <summary>
        /// Determine completion time for a single Car configuration against a race track
        /// </summary>
        CarRaceTrackEvaluation Evaluate(RaceTrack raceTrack, CarConfiguration carConfiguration);

        /// <summary>
        /// Determine completion times for Car configurations and sort evaluations from fastest to slowest against a race track
        /// </summary>
        CarRaceTrackEvaluation[] EvaluateAndSort(RaceTrack raceTrack, CarConfiguration[] carConfigurations);
    }
}
