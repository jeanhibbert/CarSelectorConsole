namespace CarSelectorConsole
{
    using System;

    using CarSelector.Model;
    using CarSelector.Services;
    using CarSelector.Tests.Utils;
    using CarSelector.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            RaceTrack _raceTrack = new RaceTrack
            {
                LapDistance = 3, // kilometers
                NoOfLapsToComplete = 100,
                PitstopTimespan = 30 // Seconds
            };

            CarGenerator carGenerator = new CarGenerator();
            CarConfiguration[] carConfigurations = carGenerator.GenerateCarConfigurations(100000);

            ICarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation[] carRaceTrackEvaluations;
            using (MeasureUtil measureUtil = new MeasureUtil("Evaluating 100000 cars against race track"))
            {
                carRaceTrackEvaluations =
                    carEvaluatorService.EvaluateAndSort(_raceTrack, carConfigurations);
            }

            Console.WriteLine("The fastest car was {0}", carRaceTrackEvaluations[0]);
            Console.WriteLine("The slowest car was {0}", carRaceTrackEvaluations[carRaceTrackEvaluations.Length - 1]);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
