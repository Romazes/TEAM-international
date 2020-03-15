using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_2
{
    class CarHandling : Car
    {
        /// <summary>
        /// Sorting Cars by speed
        /// </summary>
        /// <param name="cars"></param>
        public void SortingBySpeed(List<Car> cars)
        {
            var lowToUpeerSpeed = from temp in cars
                                  orderby temp.MaxSpeed descending
                                  select new { Name = temp.NameCar, Speed = temp.MaxSpeed };

            foreach (var item in lowToUpeerSpeed)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Grouping car Name by Alphabet
        /// </summary>
        /// <param name="cars"></param>
        public void GroupByAlphabet(List<Car> cars)
        {
            var queryFirstLetters = from car in cars
                                    group car by car.NameCar[0] into carFirstLetter
                                    orderby carFirstLetter.Key
                                    select carFirstLetter;

            foreach (var carGroup in queryFirstLetters)
            {
                Console.WriteLine($"Letter: '{carGroup.Key}'");
                // Nested foreach is required to access group items.
                foreach (var car in carGroup)
                {
                    Console.WriteLine($"\t{car.NameCar} - {car.ColorCar}");
                }
            }
        }

        /// <summary>
        /// Grouping car by Test Drive Score
        /// </summary>
        /// <param name="cars"></param>
        public void GroupByTestDrive(List<Car> cars)
        {
            var rangeNumber = from car in cars
                              let averageValue = GetAverageTestDrive(car)
                              group new { car.NameCar, car.ColorCar } by averageValue into averageGroup
                              orderby averageGroup.Key
                              select averageGroup;

            foreach (var carGroup in rangeNumber)
            {
                Console.WriteLine($"Test Drive score: {carGroup.Key:0.000}");
                foreach (var item in carGroup)
                {
                    Console.WriteLine($"\t{item.NameCar} - {item.ColorCar}");
                }
            }
        }

        /// <summary>
        /// Grouping car by Test Drive Score and Alphabet
        /// </summary>
        /// <param name="cars"></param>
        public void GroupByTestDriveScoreAndNameCar(List<Car> cars)
        {
            var queryTestDriveScore = from car in cars
                                      group car by new
                                      {
                                          FirstLetter = car.NameCar[0],
                                          TestDriveScore = GetAverageTestDrive(car) > 3.0
                                      } into carGroup
                                      orderby carGroup.Key.FirstLetter
                                      select carGroup;

            foreach (var scoreCar in queryTestDriveScore)
            {
                string s = scoreCar.Key.TestDriveScore == true ? "more than" : "less than";
                Console.WriteLine($"Name starts with {scoreCar.Key.FirstLetter} who scored {s} 3");
                foreach (var item in scoreCar)
                {
                    Console.WriteLine($"\t{item.NameCar} {item.ColorCar}");
                }
            }
        }

        protected static double GetAverageTestDrive(Car car)
        {
            double avg = car.TestDriveScore.Average();
            return avg > 0.0 ? avg : 0.0;
        }

    }
}
