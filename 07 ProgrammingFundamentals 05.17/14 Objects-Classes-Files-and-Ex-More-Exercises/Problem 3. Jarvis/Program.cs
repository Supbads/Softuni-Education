using System;

namespace Problem_3.Jarvis
{
    class Arm
    {
        private decimal energyConsumption;

        private int reach;

        private int fingers;


        public Arm(decimal energyConsumption, int reach, int fingers)
        {
            this.energyConsumption = energyConsumption;
            this.reach = reach;
            this.fingers = fingers;
        }

        public decimal EnergyConsumption
        {
            get { return energyConsumption; }
            set { energyConsumption = value; }
        }

        public int Reach
        {
            get { return reach; }
            set { reach = value; }
        }

        public int Fingers
        {
            get { return fingers; }
            set { fingers = value; }
        }

        public override string ToString()
        {
            string output = string.Empty;

            output = string.Format("#Arm:\n###Energy consumption: {0}\n###Reach: {1}\n###Fingers: {2}",
                this.energyConsumption, this.reach, this.fingers);

            return output;
        }
    }

    class Leg
    {
        private decimal energyConsumption;

        private int strength;

        private int speed;

        public Leg(decimal energyConsumption, int strength, int speed)
        {
            this.energyConsumption = energyConsumption;
            this.strength = strength;
            this.speed = speed;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public decimal EnergyConsumption
        {
            get { return energyConsumption; }
            set { energyConsumption = value; }
        }

        public override string ToString()
        {
            string output = string.Empty;

            output = string.Format("#Leg:\n###Energy consumption: {0}\n###Strength: {1}\n###Speed: {2}",
                this.energyConsumption, this.strength, this.speed);

            return output;
        }
    }

    class Torso
    {
        private decimal energyConsumption;

        private double processorSize;

        private string housingMaterial;

        public Torso(decimal energyConsumption, double processorSize, string housingMaterial)
        {
            this.energyConsumption = energyConsumption;
            this.processorSize = processorSize;
            this.housingMaterial = housingMaterial;
        }

        public string HousingMaterial
        {
            get { return housingMaterial; }
            set { housingMaterial = value; }
        }

        public double ProcessorSize
        {
            get { return processorSize; }
            set { processorSize = value; }
        }

        public decimal EnergyConsumption
        {
            get { return energyConsumption; }
            set { energyConsumption = value; }
        }

        public override string ToString()
        {
            string output = string.Empty;

            output = string.Format("#Torso:\n###Energy consumption: {0}\n###Processor size: {1:F1}\n###Corpus material: {2}",
                this.energyConsumption, this.processorSize, this.housingMaterial); //no idea to format the double or not

            return output;
        }
    }

    class Head
    {
        private decimal energyConsumption;

        private int iQ;

        private string skinMaterial;

        public Head(decimal energyConsumption, int iQ, string skinMaterial)
        {
            this.energyConsumption = energyConsumption;
            this.iQ = iQ;
            this.skinMaterial = skinMaterial;
        }

        public string SkinMaterial
        {
            get { return skinMaterial; }
            set { skinMaterial = value; }
        }

        public int IQ
        {
            get { return iQ; }
            set { iQ = value; }
        }

        public decimal EnergyConsumption
        {
            get { return energyConsumption; }
            set { energyConsumption = value; }
        }


        public override string ToString()
        {
            string output = string.Empty;

            output = string.Format("#Head:\n###Energy consumption: {0}\n###IQ: {1}\n###Skin material: {2}",
                this.energyConsumption, this.iQ, this.skinMaterial);

            return output;
        }
    }


    class Robot
    {
        private decimal energyCapacity;

        public Robot(decimal energyCapacity)
        {
            this.EnergyCapacity = energyCapacity;
        }

        public decimal EnergyCapacity
        {
            get { return energyCapacity; }
            private set { energyCapacity = value; }
        }

        public Head Head { get; set; }

        public Torso Torso { get; set; }

        public Arm LeftArm { get; set; }

        public Arm RightArm { get; set; }

        public Leg LeftLeg { get; set; }

        public Leg RightLeg { get; set; }


        //assume LeftArm is the more efficient one
        public void AttachArm(Arm other)
        {
            //toolazyTovalidate (already done outside)
            if (this.LeftArm.EnergyConsumption > other.EnergyConsumption)
            {
                this.RightArm = LeftArm;
                this.LeftArm = other;
            }
            else if (this.RightArm.EnergyConsumption > other.EnergyConsumption)
            {
                this.RightArm = other;
            }
        }

        //asume LeftLeg is the more efficient one
        public void AttachLeg(Leg other)
        {
            //toolazyTovalidate (already done outside)
            if (this.LeftLeg.EnergyConsumption > other.EnergyConsumption)
            {
                this.RightLeg = LeftLeg;
                this.LeftLeg = other;
            }
            else if (this.RightLeg.EnergyConsumption > other.EnergyConsumption)
            {
                this.RightLeg = other;
            }
        }

        public bool HasRequiredParts()
        {
            return this.Head != null && this.Torso != null && this.LeftArm != null && this.RightArm != null &&
                   this.LeftLeg != null && this.RightLeg != null;
        }

        public bool HasSufficientEnergy()
        {
            decimal sumComponentEnergy;

            sumComponentEnergy = Torso.EnergyConsumption + Head.EnergyConsumption + LeftLeg.EnergyConsumption +
                                 RightLeg.EnergyConsumption + LeftArm.EnergyConsumption + RightArm.EnergyConsumption;

            return energyCapacity >= (ulong)sumComponentEnergy;
        }

        public override string ToString()
        {
            string output = "Jarvis:\n";
            output += this.Head + "\n" + this.Torso + "\n" + this.LeftArm + "\n" + this.RightArm + "\n" + this.LeftLeg + "\n" + this.RightLeg + "\n";

            return output;
        }

        public void CheckArmOrder()
        {
            if (this.LeftArm.EnergyConsumption > this.RightArm.EnergyConsumption)
            {
                var temp = this.LeftArm;
                this.LeftArm = this.RightArm;
                this.RightArm = temp;
            }
        }

        public void CheckLegOrder()
        {
            if (this.LeftLeg.EnergyConsumption > this.RightLeg.EnergyConsumption)
            {
                var temp = this.LeftLeg;
                this.LeftLeg = this.RightLeg;
                this.RightLeg = temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ulong maximumEnergyCapacity = ulong.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            var robot = new Robot(maximumEnergyCapacity);

            while (input != "Assemble!")
            {
                var tokens = input.Split();

                var component = tokens[0];

                if (component == "Head")
                {
                    var energyConsumption = int.Parse(tokens[1]);
                    var iq = int.Parse(tokens[2]);
                    var skinMaterial = tokens[3];

                    if (robot.Head != null)
                    {
                        if (robot.Head.EnergyConsumption > energyConsumption)
                        {
                            var replacementHead = new Head(energyConsumption, iq, skinMaterial);

                            robot.Head = replacementHead;
                        }
                    }
                    else
                    {
                        var replacementHead = new Head(energyConsumption, iq, skinMaterial);

                        robot.Head = replacementHead;
                    }
                }
                else if (component == "Torso")
                {
                    var energyConsumption = int.Parse(tokens[1]);
                    var processorSize = double.Parse(tokens[2]);
                    var material = tokens[3];

                    if (robot.Torso != null)
                    {
                        if (robot.Torso.EnergyConsumption > energyConsumption)
                        {
                            Torso replacementTorso = new Torso(energyConsumption, processorSize, material);
                            robot.Torso = replacementTorso;
                        }
                    }
                    else
                    {
                        Torso replacementTorso = new Torso(energyConsumption, processorSize, material);
                        robot.Torso = replacementTorso;
                    }

                }
                else if (component == "Leg")
                {
                    var energyConsumption = int.Parse(tokens[1]);

                    if (robot.LeftLeg == null)
                    {
                        //could directly Add LeftLeg
                        var strength = int.Parse(tokens[2]);
                        var speed = int.Parse(tokens[3]);

                        var leg = new Leg(energyConsumption, strength, speed);

                        robot.LeftLeg = leg;
                    }
                    else if (robot.RightLeg == null)
                    {
                        var strength = int.Parse(tokens[2]);
                        var speed = int.Parse(tokens[3]);

                        var leg = new Leg(energyConsumption, strength, speed);

                        robot.RightLeg = leg;
                        robot.CheckLegOrder();
                    }
                    else if (robot.RightLeg.EnergyConsumption > energyConsumption)
                    {
                        var strength = int.Parse(tokens[2]);
                        var speed = int.Parse(tokens[3]);

                        var leg = new Leg(energyConsumption, strength, speed);

                        robot.AttachLeg(leg);
                    }
                }
                else // arm
                {
                    var energyConsumption = int.Parse(tokens[1]);

                    if (robot.LeftArm == null)
                    {
                        //can add directly
                        var reach = int.Parse(tokens[2]);
                        var fingers = int.Parse(tokens[3]);

                        var arm = new Arm(energyConsumption, reach, fingers);
                        robot.LeftArm = arm;

                    }
                    else if (robot.RightArm == null)
                    {
                        var reach = int.Parse(tokens[2]);
                        var fingers = int.Parse(tokens[3]);

                        var arm = new Arm(energyConsumption, reach, fingers);
                        robot.RightArm = arm;
                        robot.CheckArmOrder();

                    }
                    else if (robot.RightArm.EnergyConsumption > energyConsumption)
                    {
                        var reach = int.Parse(tokens[2]);
                        var fingers = int.Parse(tokens[3]);

                        var arm = new Arm(energyConsumption, reach, fingers);
                        robot.AttachArm(arm);
                    }
                }

                input = Console.ReadLine();
            }

            //end of input

            var robotCanBeAssembled = robot.HasRequiredParts();

            if (!robotCanBeAssembled)
            {
                Console.WriteLine("We need more parts!");
                return;
            }

            var hasSufficientEnergy = robot.HasSufficientEnergy();
            if (!hasSufficientEnergy)
            {
                Console.WriteLine("We need more power!");
                return;
            }

            Console.WriteLine(robot.ToString());

            //We need more parts!
            //We need more power!

        }
    }
}