namespace Practice_1
{
    enum ModelOfCar
    {
        Ford,
        Lexus,
        Mitsubishi,
        Lamborghini
    }

    interface Car
    {
        public ModelOfCar ModelOfCar { get; set; }
        public int MaxSpeed { get; set; }
        public int Year { get; set; }
    }
}
