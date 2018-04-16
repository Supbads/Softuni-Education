using System;

namespace Problem_1.Galactic_GPS
{
    public struct Location
    {
        private double latitude;
        private double longtitude;
        private Planet planet;

        public Location(double latitude, double longtitude, Planet planet) : this()
        {
            Latitude = latitude;
            this.Longtitude = longtitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get { return this.latitude; }
            private set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be between -90 and 90 degrees inclusive.");
                }
                this.latitude = value;
            }
        }

        //0° to (+/–)180°.
        public double Longtitude {
            get { return this.longtitude ; }
            private set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between -180 and 180 degrees inclusive.");
                }
                this.longtitude = value;
            }
        }
        public Planet Planet { get; private set; }

        public override string ToString()
        {
            return string.Format("{0:F6} ,{1:F6} -{2}", this.latitude, this.longtitude, this.planet);
        }
    }
}
