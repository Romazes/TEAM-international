using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_1
{
    class RequirementsForRace
    {
        public int MinYearForCar { get; set; } = 1980;
        public int MinSpeedForCar { get; set; } = 50;

        /// <summary>
        /// Construct for requirment for car which need for race 
        /// </summary>
        /// <param name="minYearForCar">min year for car</param>
        /// <param name="minSpeedForCar">min speed for start</param>
        public RequirementsForRace(int minYearForCar, int minSpeedForCar)
        {
            MinYearForCar = minYearForCar;
            MinSpeedForCar = minSpeedForCar;
        }
    }
}
