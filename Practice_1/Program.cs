using System;

namespace Practice_1
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Crazy-Race-Game!");

            var car1 = new RaceCar(ModelOfCar.Ford ,maxSpeed: random.Next(1, 200));
            car1.Driver = new Driver()
            {
                Name = "Player_1",
                SkillLevel = 80.0
            };

            var car2 = new RaceCar(ModelOfCar.Lexus, maxSpeed: random.Next(1, 200));
            car2.Driver = new Driver()
            {
                Name = "Player_2",
                SkillLevel = 75.0
            };

            Driver d1 = new Driver();

            Race rc = new Race();

            RequirementsForRace rq = new RequirementsForRace(1900, 50);

            rc.Notify += DisplayMessage;
            rc.ToStart(car1.Driver);
            rc.ToStart(car2.Driver);

            rc.LetStartRace(car1, car2, rq);

            Console.WriteLine(car1.MaxSpeed.ToString());
            Console.WriteLine(car2.MaxSpeed.ToString());

            //if(car2.MaxSpeed < car1.MaxSpeed)
            //    Console.WriteLine("car1 win !");
            //else
            //    Console.WriteLine("car 2 win!");
           
            



        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
