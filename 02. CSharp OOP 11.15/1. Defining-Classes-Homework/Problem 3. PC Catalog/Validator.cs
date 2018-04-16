using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.PC_Catalog
{
    static class Validator
    {
        //found out that this should be a class that has messages in it rather than throw exceptions but way too lazy to rework ;=;
        public static void ValidateNameInfo(string value)
        {
            if (value == null)
            {
                throw new NullReferenceException("Name cannot be null");
            }
            if (value.Length < 1)
            {
                throw new ArgumentException("Name cannot be empty");

            }
        }

        public static void ValidateDoubleInfo(double value)
        {
            if (value == null)
            {
                throw new NullReferenceException(value + " cannot be null");
            }
            if (value < 0)
            {
                throw new ArgumentException(value + " cannot be negative");
            }
        }

    }
}
