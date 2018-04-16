using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Pizza_Calories
{
    class Dough
    {
        private const double flourTypeWhite = 1.5;
        private const double flourTypeWholegrain = 1.0;
        private const double bakingTechniqueCrispy = 0.9;
        private const double bakingTechniqueChewy = 1.1;
        private const double bakingTechniqueHomemade = 1.0;

        private const double defaultCalories = 2;

        private string flourType;

        private string brakingTechnique;

        private double weight;

        public Dough(string flourType, string brakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BrakingTechnique = brakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }

            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BrakingTechnique
        {
            get { return this.brakingTechnique; }

            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.brakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double Calories()
        {
            return (defaultCalories * weight) * FlourTypeCalories() * BakingTechniqueCalories();
        }


        private double FlourTypeCalories()
        {
            if (this.flourType == "white")
            {
                return flourTypeWhite;
            }
            return flourTypeWholegrain;
        }

        private double BakingTechniqueCalories()
        {
            if (this.brakingTechnique == "crispy")
            {
                return bakingTechniqueCrispy;
            }
            else if (this.brakingTechnique == "chewy")
            {
                return bakingTechniqueChewy;
            }
            else return bakingTechniqueHomemade;
        }

    }
}
