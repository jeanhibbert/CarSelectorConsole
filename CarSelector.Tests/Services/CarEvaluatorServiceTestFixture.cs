using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSelector.Tests.Services
{
    using CarSelector.Model;
    using CarSelector.Services;

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
            carEvaluatorService.DetermineCompletionTime(raceTrack, carConfiguration);

            Assert.AreEqual(30060, carConfiguration.TimeToCompleteRace);
        }
    }
}
