using System;
using System.ComponentModel;

namespace Problem_2.Laptop_Shop
{
    class Laptop
    {
        private string model;
        private string manufactorer;
        private string processor;
        private int Ram;   //GB
        private string graphicsCard;
        private int Hdd;  //GB
        private string monitor;
        private string _batteryName;
        private int _batteryLife;
        private Battery battery;
        private double price; // .00 lv.

        //defaults
        private static string defaultManufactor = "Lenovo";
        private static string defaultProcessor = "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)";
        private static int defaultRam = 8;
        private static string defaultGraphicsCard = "Intel HD Graphics 4400";
        private static int defaultHdd = 128;
        private static string defaultMonitor = "\"13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display";
        private static string defaultBatteryName = "Li-Ion, 4-cells, 2550 mAh";
        private static int defaultBatteryLife = 10;

        public Laptop(string model,string manufactorer,string processor,int RAM , string graphicsCard,int HDD,string monitor,string batteryName,int batteryLife,double price)
        {
            this.Model = model;
            this.Manufactorer = manufactorer;
            this.Processor = processor;
            this.RAM = RAM;
            this.GraphicsCard = graphicsCard;
            this.HDD = HDD;
            this.Monitor = monitor;
            this.Battery=new Battery(batteryName,batteryLife);
            this._batteryLife = batteryLife;
            this._batteryName = batteryName;
            this.Price = price;
        }

        public Laptop(string model, double price) :this(model, defaultManufactor, defaultProcessor, defaultRam, defaultGraphicsCard,
             defaultHdd, defaultMonitor, defaultBatteryName, defaultBatteryLife,price)
        {
        }

        public string Model
        {
            get { return model; }
            set
            {
                VallidateStringInfo(value);
                this.model = value;
            }
        }

        public string Manufactorer
        {
            get { return manufactorer; }
            set
            {
                VallidateStringInfo(value);
                manufactorer = value;
            }
        }

        public int RAM
        {
            get { return Ram; }
            set
            {
                VallidateIntInfo(value);
                Ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return graphicsCard; }
            set
            {
                VallidateStringInfo(value);
                graphicsCard = value;
            }
        }

        public string Processor
        {
            get { return processor; }
            set
            {
                VallidateStringInfo(value);
                processor = value;
            }
        }
        
        public int HDD
        {
            get { return Hdd; }
            set
            {
                VallidateIntInfo(value);
                Hdd = value;
            }
        }
        public string Monitor
        {
            get { return monitor; }
            set
            {
                VallidateStringInfo(value);
                monitor = value;
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("price cannot be null");
                }
                if (value < 0)
                {
                    throw new ArgumentException("price cannot be negative");
                }
                price = value;
            }
        }
        public Battery Battery
        {
            get { return battery; }
            set
            {
                this.battery = value;
                this._batteryLife = battery.Life;
                this._batteryName = battery.Name;
            }
        }

        public void VallidateStringInfo(string value)
        {
            if (value == null)
            {
                throw new NullReferenceException(value+" cannot be null");
            }
            if (value.Length < 1)
            {
                throw new ArgumentException(value+" name cannot be empty");

            }
        }

        public void VallidateIntInfo(int value)
        {
            if (value == null)
            {
                throw new NullReferenceException(value + " cannot be null");
            }
            if (value < 0)
            {
                throw new ArgumentException(value + " cannot be null");
            }
        }

        public override string ToString()
        {
            string laptopData = "";
            laptopData = String.Format("Model: {1}{0}Manufactorer: {2}{0}Processor: {3}{0}RAM: {4} GB{0}Graphics card: {5}{0}HDD: {6} GB{0}Monitor: {7}{0}Battery: {8}{0}Battery life: {9}h.{0}Price {10:F2} lv.{0}",
                Environment.NewLine,
                model,
                manufactorer,
                processor,
                Ram,
                graphicsCard,
                Hdd,
                monitor,
                _batteryName,
                _batteryLife,
                price); 

            return laptopData;
        }
    }
}
