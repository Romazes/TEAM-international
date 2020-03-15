using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorialAndFibonacci factorialAndFibonacci = new FactorialAndFibonacci();
            factorialAndFibonacci.Notify += DisplayMessage;
            try
            {
                factorialAndFibonacci.Fibonacci(10);
                factorialAndFibonacci.Factorial(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(new String('-', 50));
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
            DisplayCollection(cars);
            int userInput;
            string userString;
            userString = Console.ReadLine();
            int.TryParse(userString, out userInput);

            while(userInput != 0)
            {

                switch (userInput)
                {
                    case 1:
                        car.SortingBySpeed(cars);
                        break;
                    case 2:
                        car.GroupByAlphabet(cars);
                        break;
                    case 3:
                        car.GroupByTestDrive(cars);
                        break;
                    case 4:
                        car.GroupByTestDriveScoreAndNameCar(cars);
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                userString = Console.ReadLine();
                int.TryParse(userString, out userInput);
            }

            Console.WriteLine(new String('-', 50));
            /****************************************************************************************/
            Random rnd = new Random();
            List<int> numb = Enumerable.Repeat(0, 50).Select(i => rnd.Next(0, 20)).ToList();

            var oo = SplittingArray.Split(numb);

            foreach (var carGroup in oo)
            {
                Console.WriteLine($"Even numbers ? - {carGroup.Key}");
                foreach (var item in carGroup)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        private static void DisplayCollection(List<Car> templist)
        {
            foreach (var item in templist)
                Console.WriteLine(item);
        }
    }

}
