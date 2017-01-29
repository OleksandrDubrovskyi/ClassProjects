using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    class TrainList
    {
        const int DAYS = 5;
        const int TRAINS_PER_DAY = 3;
        const int CARS = 10;
        const int SEATS = 80;

        static List<List<List<List<bool>>>> WeekSchedule = new List<List<List<List<bool>>>>(DAYS);

        public static void Start()
        {
            
            WeekSchedule = WeekScheduleInit();


            for (int i = 0; i < WeekSchedule.Count; i++)
            {
                Console.WriteLine(i);
            }



        }

        static List<List<List<List<bool>>>> WeekScheduleInit()
        {
            var Week = new List<List<List<List<bool>>>>(DAYS);

            for (int i = 0; i < Week.Count; i++)
            {
                Week.Add(DayScheduleInit());
            }

            return Week;

        }

        static List<List<List<bool>>> DayScheduleInit()
        {
            List<List<List<bool>>> Day = new List<List<List<bool>>>(TRAINS_PER_DAY);

            for (int i = 0; i < Day.Count; i++)
            {
                Day.Add(TrainInit());
            }

            return Day;
        }

        static List<List<bool>> TrainInit()
        {
            List<List<bool>> Train = new List<List<bool>>(CARS);

            for (int i = 0; i < Train.Count; i++)
            {
                Train.Add(CarInit());
            }

            return Train;
        }

        static List<bool> CarInit()
        {
            List<bool> Car = new List<bool>(SEATS);
            Random rand = new Random();

            for (int i = 0; i < Car.Count; i++)
            {
                int r = rand.Next(0, 3);
                if (r == 1)
                {
                    Car.Add(true);
                }
                else
                {
                    Car.Add(false);
                }
            }

            return Car;
        }


    }
}
