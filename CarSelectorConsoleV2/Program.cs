// Rough Implementation of Car Selector Console with NO "using" statements whatsoever.
// Code was just cut and pasted into CarSelectorConsoleV2
// The first 3 arguments are those of the Track configuration and all the rest of recuring Car Configurations that need
// to be evaluated
// NOTE:
// Command line arguments are used as input and the return value is an integer that represents the sequence id of the fastest car.
// i.e. where the fastest car existed in the list of parameter arguments provi
namespace CarSelectorConsoleV2
{
    class Program
    {
        static int Main(string[] args)
        {
            // verify that a valid number of arguments has been provided. 6 parameters, 3 for a car and 3 for a Track
            if (args.Length % 3 == 0 && args.Length >= 6)
            {
                RaceTrack raceTrack = new RaceTrack
                    {
                        PitstopTimespan = int.Parse(args[0]),
                        LapDistance = double.Parse(args[1]),
                        NoOfLapsToComplete = int.Parse(args[2])
                    };

                int sizeOfArrayRequired = (args.Length - 3) / 3;
                CarConfiguration[] carConfigurations = new CarConfiguration[sizeOfArrayRequired];

                for (int i = 0; i < sizeOfArrayRequired; i++)
                {
                    CarConfiguration carConfiguration = new CarConfiguration
                        {
                            CarConfigurationId = i,
                            AverageFuelConsumptionPerLap = double.Parse(args[(i * (i + 1) + 3)]),
                            TimeToCompleteLap = double.Parse(args[(i * (i + 1) + 4)]),
                            FuelCapacity = double.Parse(args[(i * (i + 1) + 5)])
                        };
                    carConfigurations[i] = carConfiguration;
                }

                ICarEvaluatorService evaluatorService = new CarEvaluatorService();
                return evaluatorService.EvaluateAndSort(raceTrack, carConfigurations)[0]
                    .CarConfiguration
                    .CarConfigurationId;
            }
            return 0;
        }
    }

    public interface ICarEvaluatorService
    {
        /// <summary>
        /// Determine completion time for a single Car configuration against a race track
        /// </summary>
        CarRaceTrackEvaluation Evaluate(RaceTrack raceTrack, CarConfiguration carConfiguration);

        /// <summary>
        /// Determine completion times for Car configurations and sort evaluations from fastest to slowest against a race track
        /// </summary>
        CarRaceTrackEvaluation[] EvaluateAndSort(RaceTrack raceTrack, CarConfiguration[] carConfigurations);
    }

    public class CarEvaluatorService : ICarEvaluatorService
    {
        public virtual CarRaceTrackEvaluation Evaluate(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            CarRaceTrackEvaluation carRaceTrackEvaluation = new CarRaceTrackEvaluation(raceTrack, carConfiguration);

            // Determine total pitstops and round down by casting to int
            int totalPitstopsRequired = (int)(raceTrack.NoOfLapsToComplete / (carConfiguration.FuelCapacity / carConfiguration.AverageFuelConsumptionPerLap));

            carRaceTrackEvaluation.CompletionTime = carConfiguration.TimeToCompleteLap * raceTrack.NoOfLapsToComplete + totalPitstopsRequired * raceTrack.PitstopTimespan;

            return carRaceTrackEvaluation;
        }

        public virtual CarRaceTrackEvaluation[] EvaluateAndSort(
            RaceTrack raceTrack, CarConfiguration[] carConfigurations)
        {
            CarRaceTrackEvaluation[] carRaceTrackEvaluations = new CarRaceTrackEvaluation[carConfigurations.Length];

            for (int i = 0; i < carConfigurations.Length; i++)
            {
                carRaceTrackEvaluations[i] = this.Evaluate(raceTrack, carConfigurations[i]);
            }

            QuickSort<CarRaceTrackEvaluation> evaluationSorter = new QuickSort<CarRaceTrackEvaluation>(carRaceTrackEvaluations);
            evaluationSorter.Sort();

            return evaluationSorter.Output;
        }
    }

    public class CarConfiguration
    {
        public int CarConfigurationId { get; set; }

        public double FuelCapacity { get; set; } // Measured in Litres

        public double TimeToCompleteLap { get; set; } // Measured in Seconds

        public double AverageFuelConsumptionPerLap { get; set; } // Measured in Litres
    }

    public class CarRaceTrackEvaluation : ICompletionTime
    {
        public RaceTrack RaceTrack { get; set; }

        public CarConfiguration CarConfiguration { get; set; }

        public double CompletionTime { get; set; } // Measured in seconds

        public CarRaceTrackEvaluation(RaceTrack raceTrack, CarConfiguration carConfiguration)
        {
            this.RaceTrack = raceTrack;
            this.CarConfiguration = carConfiguration;
        }

        public override string ToString()
        {
            return string.Format(
                "Completion Time {6} seconds. \n Car {0} Av. Fuel Consump. Per Lap, {1} Fuel Capacity, {2} Time to complete lap \n Track {3} Lap Distance, {4} no. of laps to complete, {5} Pitstop timespan",
                CarConfiguration.AverageFuelConsumptionPerLap,
                CarConfiguration.FuelCapacity,
                CarConfiguration.TimeToCompleteLap,
                RaceTrack.LapDistance,
                RaceTrack.NoOfLapsToComplete,
                RaceTrack.PitstopTimespan,
                CompletionTime);
        }
    }

    public class RaceTrack
    {
        public double LapDistance { get; set; } // Measured in Kilometers
        public int NoOfLapsToComplete { get; set; }
        public int PitstopTimespan { get; set; } // Measured in Seconds
    }

    public interface ICompletionTime
    {
        double CompletionTime { get; set; }
    }

    internal class QuickSort<T> where T : ICompletionTime
    {
        T[] input;

        public QuickSort(T[] values)
        {
            input = new T[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                input[i] = values[i];
            }

        }
        public T[] Output
        {
            get
            {
                return input;
            }
        }
        public void Sort()
        {
            Sorting(0, input.Length - 1);
        }
        public int getPivotPoint(int begPoint, int endPoint)
        {
            int pivot = begPoint;
            int m = begPoint + 1;
            int n = endPoint;
            while ((m < endPoint) &&
                   (input[pivot].CompletionTime >= input[m].CompletionTime))
            {
                m++;
            }

            while ((n > begPoint) &&
                   (input[pivot].CompletionTime <= input[n].CompletionTime))
            {
                n--;
            }
            while (m < n)
            {
                T temp = input[m];
                input[m] = input[n];
                input[n] = temp;

                while ((m < endPoint) &&
                       (input[pivot].CompletionTime >= input[m].CompletionTime))
                {
                    m++;
                }

                while ((n > begPoint) &&
                       (input[pivot].CompletionTime <= input[n].CompletionTime))
                {
                    n--;
                }

            }
            if (pivot != n)
            {
                T temp2 = input[n];
                input[n] = input[pivot];
                input[pivot] = temp2;

            }
            return n;

        }
        public void Sorting(int beg, int end)
        {
            if (end == beg)
            {
                return;
            }
            else
            {
                int pivot = getPivotPoint(beg, end);
                if (pivot > beg)
                    Sorting(beg, pivot - 1);
                if (pivot < end)
                    Sorting(pivot + 1, end);
            }
        }
    }
}
