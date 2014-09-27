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
        [TestMethod]
        public void CanEvaluateCarForSingleTrack()
        {
            CarConfiguration carConfiguration = new CarConfiguration();
            carConfiguration.FuelCapacity = 80; // Total Litres of fuel that the car can hold
            carConfiguration.TimeToCompleteLap = 300; // Seconds to complete lap
            carConfiguration.AverageFuelConsumptionPerLap = 2; // Average fuel consumption per lap in Litres

            RaceTrack raceTrack = new RaceTrack
            {
                LapDistance = 3, // kilometers
                NoOfLapsToComplete = 100,
                PitstopTimespan = 30 // Seconds
            };

            CarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation carRaceTrackEvaluation = carEvaluatorService.DetermineCompletionTime(raceTrack, carConfiguration);

            Assert.AreEqual(30060, carRaceTrackEvaluation.CompletionTime);
        }

        [TestMethod]
        public void CanEvaluateMultipleCarsForSingleTrack()
        {
            CarGenerator carGenerator = new CarGenerator();
            CarConfiguration[] carConfigurations = carGenerator.GenerateCarConfigurations(10000);

            RaceTrack raceTrack = new RaceTrack
            {
                LapDistance = 3, // kilometers
                NoOfLapsToComplete = 100,
                PitstopTimespan = 30 // Seconds
            };

            CarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            List<CarRaceTrackEvaluation> carRaceTrackEvaluations = new List<CarRaceTrackEvaluation>();
            foreach(CarConfiguration carConfiguration in carConfigurations)
            {
                carRaceTrackEvaluations.Add(carEvaluatorService.DetermineCompletionTime(raceTrack, carConfiguration));
            }

            Assert.IsTrue(carRaceTrackEvaluations.Where(crt => crt.CompletionTime != default(double)).Count() == 10000);
        }

    }
}
