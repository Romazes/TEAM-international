using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice_1
{
    class Race
    {
        public delegate void RaceRezult(string message);
        public event RaceRezult Notify;

        public double Distance { get; set; }
        public int AmountOfLap { get; set; }
        public List<Driver> drivers;

        public Race()
        {
            drivers = new List<Driver>();
        }

        //public Race(double distance, int amountOfLap, int amountOfDriver)
        //{
        //    Distance = distance;
        //    AmountOfLap = amountOfLap;
        //    drivers = new List<Driver>(amountOfDriver);
        //}

        /// <summary>
        /// Prepare to RACE
        /// </summary>
        /// <param name="driver">Add driver to race</param>
        /// <returns></returns>
        public List<Driver> ToStart(Driver driver)
        {
            drivers.Add(driver);
            Console.ForegroundColor = ConsoleColor.Blue;
            Notify($"New driver was add {driver.Name} with SkillLeverl = {driver.SkillLevel}");
            Console.ForegroundColor = ConsoleColor.White;
            return drivers;
        }

        public Race LetStartRace(RaceCar raceCar1, RaceCar raceCar2, RequirementsForRace raceClass)
        {
            var result = new Race();
            if (this.ValidateCarsForRace(requirements: raceClass, raceCars: new List<RaceCar>
        {
        raceCar1, raceCar2
        }))
            {
                result = this.DetermineWinner(raceCar1: raceCar1, raceCar2: raceCar2);
            }
            else
            {
                Console.WriteLine("Not all race cars met the criteria for the chosen race class for this race. No race occurred.");
            }

            return result;
        }

        private Race DetermineWinner(RaceCar raceCar1, RaceCar raceCar2)
        {
            var result = new Race();
            if (raceCar1 != null && raceCar2 != null)
            {
                var racingCars = new List<RaceCar>
            {
            raceCar1, raceCar2
            };
                var winningCar = racingCars.OrderByDescending(c => c.MaxSpeed).ToList()[0];
                var sameSpeedCars = racingCars.Where(c => c.MaxSpeed == winningCar.MaxSpeed && c.Driver.Name != winningCar.Driver.Name).ToList();

                return result;
            }
            return result;
        }



        private bool ValidateCarsForRace(RequirementsForRace requirements, List<RaceCar> raceCars)
        {
            var result = true;
            //
            var inValidCars = raceCars.Where(c => c.MaxSpeed < requirements.MinSpeedForCar |
                                                  c.Year < requirements.MinYearForCar).ToList();
            result = inValidCars.Any() == false;
            return result;
        }


    }
}
