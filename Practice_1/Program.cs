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

            //Create Drivers and his car instances.
            #region
            List<RaceCar> raceCars = new List<RaceCar>();
            var car1 = new RaceCar(ModelOfCar.Ford, maxSpeed: random.Next(0, 200),
                                    new Driver { Name = "Player_1", SkillLevel = 80.0 }, 2008);

            var car2 = new RaceCar(ModelOfCar.Lexus, maxSpeed: random.Next(0, 200),
                                    new Driver { Name = "Player_2", SkillLevel = 75.0 }, 1998);

            var car3 = new RaceCar(ModelOfCar.Lamborghini, maxSpeed: random.Next(0, 200),
                                    new Driver { Name = "Player_3", SkillLevel = 60.0 });

            var car4 = new RaceCar(ModelOfCar.Mitsubishi, maxSpeed: random.Next(0, 200),
                                    new Driver { Name = "Player_4", SkillLevel = 50.0 });

            raceCars.Add(car1);
            raceCars.Add(car2);
            raceCars.Add(car3);
            raceCars.Add(car4);
            raceCars.ForEach(c => Console.WriteLine(c.ToString()));
            #endregion

            //Set min requirements for Cars 
            RequirementsForRace minimalRequirementForRace = new RequirementsForRace(1890, 20);
            RaceGamePlay playGame = new RaceGamePlay();

            //Invoke Event when can change color and output some info
            playGame.Notify += new RaceGamePlay.OutputInfo(DisplayBlueMessage);

            //Created instance "StopWatch" to calculate race time.
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            //Prepared Cars and check his min feature need for race
            var raceResultsList = playGame.LetStartRace(raceCars, minimalRequirementForRace);

            //If all cars pass requirement, we can start or Game can Finshed with failed
            if (raceResultsList.IsSuccess)
            {
                //If car have the same speed and chance win at Race
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The race was not successful.");
                Console.WriteLine(raceResultsList.FailedRaceInformation);
                Console.ResetColor();
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
