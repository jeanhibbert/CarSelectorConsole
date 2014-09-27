using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSelector.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;

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
            CarRaceTrackEvaluation carRaceTrackEvaluation = carEvaluatorService.DetermineCompletionTime(_raceTrack, carConfiguration);

            Assert.AreEqual(30060, carRaceTrackEvaluation.CompletionTime);
        }

        [TestMethod]
        public void CanEvaluateMultipleCarsForSingleTrack()
        {
            CarGenerator carGenerator = new CarGenerator();
            CarConfiguration[] carConfigurations = carGenerator.GenerateCarConfigurations(10000);

            CarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation[] carRaceTrackEvaluations =
                carEvaluatorService.EvaluateCarsAgainstRaceTrack(_raceTrack, carConfigurations);

            for (int i = 0; i < carRaceTrackEvaluations.Length ; i++ )
            {
                if (i > 0)
                {
                    Assert.IsTrue(carRaceTrackEvaluations[i].CompletionTime >= carRaceTrackEvaluations[i - 1].CompletionTime);       
                }
            }
        }

    }
}
