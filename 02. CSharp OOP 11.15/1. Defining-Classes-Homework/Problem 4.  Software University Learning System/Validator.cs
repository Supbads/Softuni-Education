using System;
namespace Problem_3.PC_Catalog
{
    static class Validator
    {
        public static void ValidateStringInfo(string value)
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

        public static void ValidateAgeInfo(int value)
        {
            if (value == null)
            {
                throw new NullReferenceException(" Age cannot be null");
            }
            if (value < 0)
            {
                throw new ArgumentException(" Age cannot be negative");

            }
        }
    }
}
