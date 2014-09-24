using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSelector.Model
{
    public class CarConfiguration
    {
        public double FuelCapacity { get; set; }

        public double TimeToCompleteLap { get; set; }

        public double AverageFuelConsumptionPerLap { get; set; }

        public RaceTrack RaceTrack { get; set; }

        public double TimeToCompleteRace { get; set; }
    }
}
