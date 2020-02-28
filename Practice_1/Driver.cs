using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_1
{
    class Driver
    {
        public string Name { get; set; }
        //public int Power { get; set; } = 100;
        //public int Health { get; set; } = 100;
        public double Lucky { get; set; }
        public RaceCar Car { get; set; }

        /// <summary>
        /// Construct for creation Drivers
        /// </summary>
        /// <param name="name">Player Name</param>
        /// <param name="lucky">How is lucky?</param>
        /// <param name="model">Model of car</param>
        /// <param name="speed">Max speed of car</param>
        public Driver(string name, double lucky, ModelOfCar model, int speed)
        {
            Name = name;
            Lucky = lucky;
            Car = new RaceCar(model, speed);
        }


    }
}
