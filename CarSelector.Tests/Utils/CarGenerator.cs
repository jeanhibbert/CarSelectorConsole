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
                carConfiguration.FuelCapacity = random.Next(60,100); // Total Litres of fuel that the car can hold
                carConfiguration.TimeToCompleteLap = random.Next(200, 500); ; // Seconds to complete lap
                carConfiguration.AverageFuelConsumptionPerLap = random.Next(2, 5); // Average fuel consumption per lap in Litres
                carConfigurations[i] = carConfiguration;
            }
            return carConfigurations;
        }
    }
}
