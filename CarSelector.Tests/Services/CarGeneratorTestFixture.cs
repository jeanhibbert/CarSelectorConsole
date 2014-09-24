using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSelector.Tests.Generators
{
    using System.Collections.Generic;

    using CarSelector.Services;
    using CarSelector.Model;

    [TestClass]
    public class CarGeneratorTestFixture
    {
        [TestMethod]
        public void CanGenerateCarConfigurations()
        {
            CarGenerator carGenerator = new CarGenerator();
            List<CarConfiguration> carConfigurations = carGenerator.GenerateCarConfigurations(10000);

            RaceTrack raceTrack = new RaceTrack
            {
                LapDistance = 3, // kilometers
                NoOfLapsToComplete = 100,
                PitstopTimespan = 30 // Seconds
            };     
            
            CarEvaluatorService carEvaluatorService = new CarEvaluatorService();
            carConfigurations.ForEach(cf =>
                {
                    carEvaluatorService.DetermineCompletionTime(raceTrack, cf);
                });

            CarConfiguration bestCarConfiguration = carConfigurations.OrderBy(cf => cf.TimeToCompleteRace).First();
            Assert.IsTrue(bestCarConfiguration != null);
        }
    }
}
