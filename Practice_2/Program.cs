using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //FactorialAndFibonacci factorialAndFibonacci = new FactorialAndFibonacci();
            //factorialAndFibonacci.Notify += DisplayMessage;
            //try
            //{
            //    factorialAndFibonacci.Fibonacci(10);
            //    factorialAndFibonacci.Factorial(5);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            /****************************************************************************************/

            List<Car> cars = new List<Car>
            {
                new Car { NameCar = "Honda", ColorCar = Color.Black, MaxSpeed = 100, Autopilot = false,
                          TestDriveScore = new List<double>{2.0, 3.0, 3.3 } },
                new Car { NameCar = "Maclaren", ColorCar = Color.Red, MaxSpeed = 450, Autopilot = false,
                          TestDriveScore = new List<double>{4.0, 3.5, 2.3 }},
                new Car { NameCar = "Tesla", ColorCar = Color.Green, MaxSpeed = 248, Autopilot = true,
                          TestDriveScore = new List<double>{3.9, 2.0, 3.0 }},
                new Car { NameCar = "Tesla", ColorCar = Color.Red, MaxSpeed = 248, Autopilot = true,
                          TestDriveScore = new List<double>{3.9, 2.0, 3.0 }},
                new Car { NameCar = "Tesla", ColorCar = Color.Blue, MaxSpeed = 248, Autopilot = true,
                          TestDriveScore = new List<double>{3.9, 2.0, 3.0 }},
                new Car { NameCar = "Aston Martin", ColorCar = Color.Black, MaxSpeed = 300, Autopilot = false,
                          TestDriveScore = new List<double>{4.1, 2.4, 2.8 }},
                new Car { NameCar = "Aston Martin", ColorCar = Color.Red, MaxSpeed = 300, Autopilot = false,
                          TestDriveScore = new List<double>{4.1, 2.4, 2.8 }}
            };

            CarHandling car = new CarHandling();
            //Car.SortingBySpeed(cars);
            //car.GroupByAlphabet(cars);
            car.GroupByTestDrive(cars);
            //car.SortingBySpeed(cars);
            Console.WriteLine(new string('-',40));
            car.GroupByTestDriveScoreAndNameCar(cars);


        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
