using CarSelector.Model;
namespace CarSelector.Services
{
    using System;
    using System.Collections.Generic;

    public class CarGenerator
    {
        public List<CarConfiguration> GenerateCarConfigurations(int totalCarsToGenerate)
        {
            Random random = new Random();
            List<CarConfiguration> carConfigurations = new List<CarConfiguration>();
            for (int i = 0; i < totalCarsToGenerate; i++)
            {
                CarConfiguration carConfiguration = new CarConfiguration();
                carConfiguration.FuelCapacity = random.Next(60,100); // Total Litres of fuel that the car can hold
                carConfiguration.TimeToCompleteLap = random.Next(200, 500); ; // Seconds to complete lap
                carConfiguration.AverageFuelConsumptionPerLap = random.Next(2, 5); // Average fuel consumption per lap in Litres
                carConfigurations.Add((carConfiguration));
            }
            return carConfigurations;
        }
    }
}
