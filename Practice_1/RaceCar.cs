namespace Practice_1
{
    class RaceCar : Car
    {
        public ModelOfCar ModelOfCar { get; set; }
        public int MaxSpeed { get; set; }
        public int Year { get; set; } = 1999;
        public Driver Driver { get; set; }

        /// <summary>
        /// Construct for creating new model of Car
        /// </summary>
        /// <param name="modelOfCar">Choose the model of car from enum "modelOfCar"</param>
        /// <param name="maxSpeed">Max speed for car to win the race</param>
        public RaceCar(ModelOfCar modelOfCar, int maxSpeed)
        {
            ModelOfCar = modelOfCar;
            MaxSpeed = maxSpeed;
        }
    }
}
