using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_1
{
    class Race
    {
        public double Distance { get; set; }
        public int AmountOfLap { get; set; }
        public List<Driver> drivers;

        public Race(double distance, int amountOfLap, int amountOfDriver)
        {
            Distance = distance;
            AmountOfLap = amountOfLap;
            drivers = new List<Driver>(amountOfDriver);
        }

        /// <summary>
        /// Prepare to RACE
        /// </summary>
        /// <param name="driver">ADd driver to race</param>
        /// <returns></returns>
        public List<Driver> ToStart(Driver driver)
        {
            //foreach (var item in driver)
            //{
            //    drivers.Add(item);
            //}
            drivers.Add(driver);
            return drivers;
        }

        public void LetStartRace()
        {
            
        }
    }
}
