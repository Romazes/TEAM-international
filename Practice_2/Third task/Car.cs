using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_2
{
    class Car
    {
        public string NameCar { get; set; }
        public Color ColorCar { get; set; } = 0;
        public int MaxSpeed { get; set; } = 50;
        public bool Autopilot { get; set; } = false;
        public List<double> TestDriveScore;

        public override string ToString()
        {
            return "Car: " + NameCar + " - " + ColorCar + ". MAX SPEED: " + MaxSpeed;
        }
    }
}
