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

        int maxNumber = 0;

        static bool[,,,] passengers = new bool[DAYS,TRAINS_PER_DAY,CARS,SEATS];

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

                            int randomNum = rand.Next(0, 1);//Use random number generator
                            if (randomNum == 1)             //to populate trains
                            {
                                passengers[day, train, car, seat] = true;
                            }
                        }
                    }
                }
            }
        }

        static int DayWithMaximumPassengers(bool[,,,] passengers)
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
                max = FindMaxNumber(passengersPerDay);
                dayWithMostPassengers = max.number;
                maxNumOfPass = max.maximumPassengers;
            }

            Console.WriteLine("Maximum number of passengers is {0} in the day # {1}",
                              maxNumOfPass, dayWithMostPassengers);
            return dayWithMostPassengers;
        }

        static int DailyTrainWithMaximumPassengers(bool[,,,] passengers, int day)
        {
            int[] passengersPerTrain = new int[TRAINS_PER_DAY];
            int counter = 0;
            int trainWithMostPassengers = 0;
            int maxNumOfPass = 0;
            MaximumNumber max = new MaximumNumber();

            for ( int i = day; i < day+1; day++)
            {
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
                    max = FindMaxNumber(passengersPerTrain);
                    trainWithMostPassengers = max.number;
                    maxNumOfPass = max.maximumPassengers;
                }                
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

            for (int i = day; i < day + 1; day++)
            {
                for (int j = train; j < train+1; train++)
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
                        passengersPerCar[car] = counter;
                        max = FindMaxNumber(passengersPerCar);
                        carWithMostPassengers = max.number;
                        maxNumOfPass = max.maximumPassengers;
                    }                    
                }
            }

            Console.WriteLine("Maximum number of passengers is {0} in the car # {1}", 
                              maxNumOfPass, carWithMostPassengers);
            return carWithMostPassengers;
        }

        static MaximumNumber FindMaxNumber(int[] passengers)
        {
            throw new NotImplementedException();
        }
    }
}
