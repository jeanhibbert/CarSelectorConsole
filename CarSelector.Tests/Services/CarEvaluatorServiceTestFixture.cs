using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSelector.Tests.Services
{

    using CarSelector.Contracts;
    using CarSelector.Model;
    using CarSelector.Services;
    using CarSelector.Tests.Utils;
    using System;

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
        [ExpectedException(typeof(NullReferenceException))]
        public void WillThrowNullReferenceExceptionIfACarConfigurationIsNullInArray()
        {
            CarGenerator carGenerator = new CarGenerator();
            CarConfiguration[] carConfigurations = carGenerator.GenerateCarConfigurations(100);

            carConfigurations[50] = null;

            ICarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            carEvaluatorService.EvaluateAndSort(_raceTrack, carConfigurations);
        }

        [TestMethod]
        public void EnsureZeroCarValuesAreHandledAndNoExceptionIsThrown()
        {
            CarConfiguration carConfiguration = new CarConfiguration();
            carConfiguration.FuelCapacity = 0;
            carConfiguration.TimeToCompleteLap = 0;
            carConfiguration.AverageFuelConsumptionPerLap = 0;

            ICarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            carEvaluatorService.Evaluate(_raceTrack, carConfiguration);
        }

        [TestMethod]
        public void EnsureZeroTrackandCarValuesAreHandledAndNoExceptionIsThrown()
        {
            RaceTrack raceTrack = new RaceTrack{ LapDistance = 0, NoOfLapsToComplete = 0, PitstopTimespan = 0 };

            CarConfiguration carConfiguration = new CarConfiguration();
            carConfiguration.FuelCapacity = 0; 
            carConfiguration.TimeToCompleteLap = 0; 
            carConfiguration.AverageFuelConsumptionPerLap = 0; 

            ICarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation carRaceTrackEvaluation = carEvaluatorService.Evaluate(raceTrack, carConfiguration);
            Assert.IsNotNull(carRaceTrackEvaluation);
        }

        [TestMethod]
        public void EnsureZeroTrackValuesAreHandledAndNoExceptionIsThrown()
        {
            RaceTrack raceTrack = new RaceTrack { LapDistance = 0, NoOfLapsToComplete = 0, PitstopTimespan = 0 };

            CarConfiguration carConfiguration = new CarConfiguration();
            carConfiguration.FuelCapacity = 100;
            carConfiguration.TimeToCompleteLap = 400;
            carConfiguration.AverageFuelConsumptionPerLap = 7.862;

            ICarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            CarRaceTrackEvaluation carRaceTrackEvaluation = carEvaluatorService.Evaluate(raceTrack, carConfiguration);
            Assert.IsNotNull(carRaceTrackEvaluation);
        }

    }
}
