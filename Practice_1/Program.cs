using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Practice_1
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Crazy-Race-Game!");
            List<RaceCar> rc = new List<RaceCar>();

            var car1 = new RaceCar(ModelOfCar.Ford, maxSpeed: random.Next(0, 200));
            car1.Driver = new Driver()
            {
                Name = "Player_1",
                SkillLevel = 80.0
            };

            var car2 = new RaceCar(ModelOfCar.Lexus, maxSpeed: random.Next(0, 200));
            car2.Driver = new Driver()
            {
                Name = "Player_2",
                SkillLevel = 75.0
            };

            var car3 = new RaceCar(ModelOfCar.Lamborghini, maxSpeed: random.Next(0, 200));
            car3.Driver = new Driver()
            {
                Name = "Player_3",
                SkillLevel = 60.0
            };

            var car4 = new RaceCar(ModelOfCar.Mitsubishi, maxSpeed: random.Next(0, 200));
            car4.Driver = new Driver()
            {
                Name = "Player_4",
                SkillLevel = 50.0
            };

            rc.Add(car1);
            rc.Add(car2);
            rc.Add(car3);
            rc.Add(car4);
            rc.ForEach(c => Console.WriteLine(c.ToString()));
            RequirementsForRace rq = new RequirementsForRace(1890, 20);

            RaceGamePlay rgp = new RaceGamePlay();
            rgp.Notify += new RaceGamePlay.OutputInfo(DisplayBlueMessage);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var raceResultsList = rgp.LetStartRace(rc, rq);

            if (raceResultsList.IsSuccess)
            {

                if (raceResultsList.IsTie)
                {
                    DisplayBlueMessage("There was a tie between the Following drivers.");
                    raceResultsList.raceCarsList.ForEach(c => Console.Write(String.Format(" {0} ", c.Driver.Name)));
                    Console.WriteLine();
                }
                else
                {
                    DisplayBlueMessage($"Congratulations to {raceResultsList.WinningRaceCar.Driver.Name}, the winner of this race.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The race was not successful.");
                Console.WriteLine(raceResultsList.FailedRaceInformation);
                Console.WriteLine();
            }
            Thread.Sleep(1000);
            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine(String.Format("This race took {0} milliseconds.", stopWatch.ElapsedMilliseconds));
            Console.WriteLine();

            

        }

        private static void DisplayBlueMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
