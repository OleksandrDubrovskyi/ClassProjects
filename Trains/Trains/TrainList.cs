using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    class TrainList
    {
        struct MaximumNumber { public int maximumPassengers; public int trainNumber; }

        const int DAYS = 5;
        const int TRAINS_PER_DAY = 3;
        const int CARS = 10;
        const int SEATS = 80;

        

        public static void Start()
        {
            var WeekSchedule = new List<List<List<List<bool>>>>(DAYS);
            WeekSchedule = WeekScheduleInit();


            CarInit();


        }

        static MaximumNumber DayWithMaximumPassengers(List<List<List<List<bool>>>> passengers)
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
                            if (passengers[day] [train] [car] [seat] == true)
                            {
                                counter++;

                                Console.WriteLine("{0} {1} {2} {3} -- {4}",day,train,car,seat,counter);
                            }
                        }
                    }
                }
                Console.WriteLine("{0} - {1}",day, counter);
                passengersPerDay[day] = counter;
                counter = 0;
                max = FindMaxNumber(passengersPerDay);
                dayWithMostPassengers = max.trainNumber;
                maxNumOfPass = max.maximumPassengers;
            }

            return max;
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
            max.trainNumber = itemWithMaximumPass;

            return max;
        }

        static List<List<List<List<bool>>>> WeekScheduleInit()
        {
            var Week = new List<List<List<List<bool>>>>(DAYS);

            for (int i = 0; i < DAYS; i++)
            {
                Week.Add(DayScheduleInit());
            }

            return Week;

        }

        static List<List<List<bool>>> DayScheduleInit()
        {
            List<List<List<bool>>> Day = new List<List<List<bool>>>(TRAINS_PER_DAY);

            for (int i = 0; i < TRAINS_PER_DAY; i++)
            {
                Day.Add(TrainInit());
            }

            return Day;
        }

        static List<List<bool>> TrainInit()
        {
            List<List<bool>> Train = new List<List<bool>>(CARS);

            for (int i = 0; i < CARS; i++)
            {
                Train.Add(CarInit());
            }

            return Train;
        }

        static List<bool> CarInit()
        {
            List<bool> Car = new List<bool>(SEATS);
            Random rand = new Random();

            int count=0;

            for (int i = 0; i < SEATS; i++)
            {
                int r = rand.Next(0, 4);
                if (r == 1)
                {
                    Car.Add(true);
                    count++;
                }
                else
                {
                    Car.Add(false);
                }
            }
            Console.WriteLine(count);
            return Car;
        }


    }
}
