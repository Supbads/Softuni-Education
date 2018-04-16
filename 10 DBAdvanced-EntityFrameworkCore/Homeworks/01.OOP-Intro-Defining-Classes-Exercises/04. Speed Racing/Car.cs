namespace _04.Speed_Racing
{
    class Car
    {
        public float FuelAmount { get; set; }

        public string Model { get; set; }

        public float FuelConsumption { get; set; }

        public int Kilometers { get; set; }

        public Car(float fuelAmount, string model, float fuelConsumption, int kilometers = 0)
        {
            FuelAmount = fuelAmount;
            Model = model;
            FuelConsumption = fuelConsumption;
            Kilometers = kilometers;
        }

        public bool Drive(int driveDistance)
        {
            float fuelConsumed = driveDistance * FuelConsumption;

            if (fuelConsumed > FuelAmount)
            {
                return false;
            }

            this.FuelAmount -= fuelConsumed;
            this.Kilometers += driveDistance;

            return true;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:F2} {2}", this.Model, this.FuelAmount, this.Kilometers);
        }
    }
}