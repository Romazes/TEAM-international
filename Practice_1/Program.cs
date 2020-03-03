using System;
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
            RequirementsForRace rq = new RequirementsForRace(1890, 20);

            RaceGamePlay rgp = new RaceGamePlay();
            rgp.Notify += new RaceGamePlay.OutputInfo(DisplayBlueMessage);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var raceResults = rgp.LetStartRace(car1, car2, rq);
            if (raceResults.IsSuccess)
            {

                if (raceResults.IsTie)
                {
                    DisplayBlueMessage("There was a tie between the Following drivers.");
                    raceResults.raceCarsList.ForEach(c => Console.Write(String.Format(" {0} ", c.Driver.Name)));
                    Console.WriteLine();
                }
                else
                {
                    DisplayBlueMessage($"Congratulations to {raceResults.WinningRaceCar.Driver.Name}, the winner of this race.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The race was not successful.");
                Console.WriteLine(raceResults.FailedRaceInformation);
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
