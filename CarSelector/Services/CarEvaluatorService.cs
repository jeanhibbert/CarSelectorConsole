using CarSelector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSelector.Services
{
    public class CarEvaluatorService
    {
        public void DetermineCompletionTime(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            int totalPitstopsRequired = Convert.ToInt32(raceTrack.NoOfLapsToComplete / (carConfiguration.FuelCapacity / carConfiguration.AverageFuelConsumptionPerLap));

            var timeToCompleteRace = carConfiguration.TimeToCompleteLap * (raceTrack.NoOfLapsToComplete) + totalPitstopsRequired * raceTrack.PitstopTimespan;

            carConfiguration.RaceTrack = raceTrack;
            carConfiguration.TimeToCompleteRace = timeToCompleteRace;
        }
    }
}
