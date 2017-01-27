using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    class Trains
    {
        struct MaximumNumber { public int maximumPassengers; public int number; }

        const int DAYS = 5;
        const int TRAINS_PER_DAY = 3;
        const int CARS = 10;
        const int SEATS = 80;

        static bool[,,,] passengers = new bool[DAYS, TRAINS_PER_DAY, CARS, SEATS];


        public static void Start()
        {
            Initialize(passengers);
            ShowDayWithMaxPass();
            ShowTrainsWithMaxPass();
            ShowCarsWithMaxPass();

        }

        static void ShowCarsWithMaxPass()
        {
            Console.WriteLine("\nCars with max num of pass:");
            for (int day = 0; day < DAYS; day++)
            {
                Console.WriteLine("Day" + day + ":");

                for (int train = 0; train < TRAINS_PER_DAY; train++)
                {
                    Console.WriteLine("Train" + train + ":");
                    CarWithMaximumPassengers(passengers, day, train);
                }
                Console.WriteLine();
            }
        }

        static void ShowTrainsWithMaxPass()
        {
            Console.WriteLine("\nTrains with max num of pass:");
            for (int day = 0; day < DAYS; day++)
            {
                Console.WriteLine("Day" + day + ":");
                DailyTrainWithMaximumPassengers(passengers, day);
                Console.WriteLine();
            }
        }

        static void ShowDayWithMaxPass()
        {
            Console.WriteLine("Day with maximum number of passengers:");
            MaximumNumber max = DayWithMaximumPassengers(passengers);
            Console.WriteLine(max.number + ": " + max.maximumPassengers);
        }

        static void Initialize(bool[,,,] passengers)
        {
            Random rand = new Random();

            for (int day = 0; day < DAYS; day++)
            {
                for (int train = 0; train < TRAINS_PER_DAY; train++)
                {
                    for (int car = 0; car < CARS; car++)
                    {
                        for (int seat = 0; seat < SEATS; seat++)
                        {
                            passengers[day, train, car, seat] = false;

                            int randomNum = rand.Next(0, 3);//Use random number generator
                            if (randomNum == 1)             //to populate trains
                            {
                                passengers[day, train, car, seat] = true;
                            }
                        }
                    }
                }
            }
        }

        static MaximumNumber DayWithMaximumPassengers(bool[,,,] passengers)
        {
            int[] passengersPerDay = new int[DAYS];
            int counter = 0;
            int dayWithMostPassengers = 0;
            int maxNumOfPass = 0;
            MaximumNumber max = new MaximumNumber();

            for (int day = 0; day < DAYS; day++)
            {
                for (int train = 0; train < TRAINS_PER_DAY; train++)
                {
                    for (int car = 0; car < CARS; car++)
                    {
                        for (int seat = 0; seat < SEATS; seat++)
                        {
                            if (passengers[day, train, car, seat] == true)
                            {
                                counter ++;
                            }
                        }
                    }
                }

                passengersPerDay[day] = counter;
                counter = 0;
                max = FindMaxNumber(passengersPerDay);
                dayWithMostPassengers = max.number;
                maxNumOfPass = max.maximumPassengers;
            }

            return max;
        }

        static int DailyTrainWithMaximumPassengers(bool[,,,] passengers, int day)
        {
            int[] passengersPerTrain = new int[TRAINS_PER_DAY];
            int counter = 0;
            int trainWithMostPassengers = 0;
            int maxNumOfPass = 0;
            MaximumNumber max = new MaximumNumber();
           
                for (int train = 0; train < TRAINS_PER_DAY; train++)
                {
                    for (int car = 0; car < CARS; car++)
                    {
                        for (int seat = 0; seat < SEATS; seat++)
                        {
                            if (passengers[day, train, car, seat] == true)
                            {
                                counter++;
                            }
                        }
                    }
                    passengersPerTrain[train] = counter;
                    counter = 0;
                    max = FindMaxNumber(passengersPerTrain);
                    trainWithMostPassengers = max.number;
                    maxNumOfPass = max.maximumPassengers;
                }                
            
            Console.WriteLine("Maximum number of passengers is {0} in the train # {1}",
                              maxNumOfPass, trainWithMostPassengers);
            return trainWithMostPassengers;
        }

        static int CarWithMaximumPassengers(bool[,,,] passengers, int day, int train)
        {
            int[] passengersPerCar = new int[CARS];
            int counter = 0;
            int carWithMostPassengers = 0;
            int maxNumOfPass = 0;
            MaximumNumber max = new MaximumNumber();

                for (int car = 0; car < CARS; car++)
                {
                    for (int seat = 0; seat < SEATS; seat++)
                    {
                        if (passengers[day, train, car, seat] == true)
                        {
                            counter++;
                        }
                    }
                    passengersPerCar[car] = counter;
                    counter = 0;
                    max = FindMaxNumber(passengersPerCar);
                    carWithMostPassengers = max.number;
                    maxNumOfPass = max.maximumPassengers;
                }

            Console.WriteLine("Maximum number of passengers is {0} in the car # {1}", 
                              maxNumOfPass, carWithMostPassengers);
            return carWithMostPassengers;
        }

        static MaximumNumber FindMaxNumber(int[] passengers)
        {
            MaximumNumber max = new MaximumNumber();
            int maxNumOfPass = 0;
            int currentMax = 0;
            int itemWithMaximumPass = 0;

            for (int i = 0; i < passengers.Length; i++)
            {
                currentMax = passengers[i];

                if (currentMax > maxNumOfPass)
                {
                    maxNumOfPass = currentMax;
                    itemWithMaximumPass = i;
                }               
            }

            max.maximumPassengers = maxNumOfPass;
            max.number = itemWithMaximumPass;

            return max;
        }
    }
}
