using System;

namespace Practice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter amount of Lap: ");
            //string input = String.Empty;
            //try
            //{
            //    int amountOfLap = Int32.Parse(input);
            //}
            //catch { }
            Random rnd = new Random();

            Driver dr = new Driver ("Player1", 0.6, ModelOfCar.Ford, 100);
            Driver dr2 = new Driver("Player2", 0.3, ModelOfCar.Lamborghini, 100);


            Race rc = new Race(1000, 10, 2);
            rc.ToStart(dr);
            rc.ToStart(dr2);


            
        }
    }
}
