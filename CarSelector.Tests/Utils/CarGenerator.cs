namespace CarSelector.Tests.Utils
{
    using CarSelector.Model;

    using System;

    public class CarGenerator
    {
        public CarConfiguration[] GenerateCarConfigurations(int totalCarsToGenerate)
        {
            Random random = new Random();
            CarConfiguration[] carConfigurations = new CarConfiguration[totalCarsToGenerate];
            for (int i = 0; i < totalCarsToGenerate; i++)
            {
                CarConfiguration carConfiguration = new CarConfiguration();
                carConfiguration.FuelCapacity = random.NextDouble() * 40 + 60; // Total Litres of fuel that the car can hold, range [60 - 100]
                carConfiguration.TimeToCompleteLap = random.NextDouble() * 300 + 200; ; // Seconds to complete lap [200 - 500]
                carConfiguration.AverageFuelConsumptionPerLap = random.NextDouble() * 3 + 2; // Average fuel consumption per lap in Litres [2 - 5]
                carConfigurations[i] = carConfiguration;
            }
            return carConfigurations;
        }
    }
}
