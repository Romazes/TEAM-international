using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_1
{
    enum ModelOfCar
    {
        Ford,
        Lexus,
        Mitsubishi,
        Lamborghini
    }

    class RaceCar : Car
    {
        public ModelOfCar ModelOfCar { get; set; }
        public int Speed { get; set; }

        public RaceCar(ModelOfCar modelOfCar, int speed)
        {
            ModelOfCar = modelOfCar;
            Speed = speed;
        }
    }
}
