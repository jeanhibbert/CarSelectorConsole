using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSelector.Tests.Services
{

    using CarSelector.Contracts;
    using CarSelector.Model;
    using CarSelector.Services;
    using CarSelector.Tests.Utils;

    [TestClass]
    public class CarEvaluatorServiceTestFixture
    {
        private RaceTrack _raceTrack;

        [TestInitialize]
        public void Setup()
        {
            _raceTrack = new RaceTrack
            {
                LapDistance = 3, // kilometers
                NoOfLapsToComplete = 100,
                PitstopTimespan = 30 // Seconds
            };
        }

        [TestMethod]
        public void CanEvaluateCarForSingleTrack()
        {
            CarConfiguration carConfiguration = new CarConfiguration();
            carConfiguration.FuelCapacity = 80; // Total Litres of fuel that the car can hold
            carConfiguration.TimeToCompleteLap = 300; // Seconds to complete lap
            carConfiguration.AverageFuelConsumptionPerLap = 2; // Average fuel consumption per lap in Litres

            CarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation carRaceTrackEvaluation = carEvaluatorService.Evaluate(_raceTrack, carConfiguration);

            Assert.AreEqual(30060, carRaceTrackEvaluation.CompletionTime);
        }

        [TestMethod]
        public void CanEvaluateMultipleCarsForSingleTrack()
        {
            CarGenerator carGenerator = new CarGenerator();
            CarConfiguration[] carConfigurations = carGenerator.GenerateCarConfigurations(10000);

            ICarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation[] carRaceTrackEvaluations =
                carEvaluatorService.EvaluateAndSort(_raceTrack, carConfigurations);

            for (int i = 0; i < carRaceTrackEvaluations.Length ; i++ )
            {
                if (i > 0)
                {
                    Assert.IsTrue(carRaceTrackEvaluations[i].CompletionTime >= carRaceTrackEvaluations[i - 1].CompletionTime);       
                }
            }
        }

        [TestMethod]
        public void EnsureValidExceptionIsThrownForBadCarConfiguration()
        {
            CarConfiguration carConfiguration = new CarConfiguration();
            carConfiguration.FuelCapacity = 80; // Total Litres of fuel that the car can hold
            carConfiguration.TimeToCompleteLap = 10; // Seconds to complete lap
            carConfiguration.AverageFuelConsumptionPerLap = 0; // Average fuel consumption per lap in Litres

            ICarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation carRaceTrackEvaluation = carEvaluatorService.Evaluate(_raceTrack, carConfiguration);
        }

    }
}
