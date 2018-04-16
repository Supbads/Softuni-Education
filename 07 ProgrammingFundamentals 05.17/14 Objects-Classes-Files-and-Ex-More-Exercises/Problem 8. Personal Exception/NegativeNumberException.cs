using System;

namespace Problem_8.Personal_Exception
{
    class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message = "My first exception is awesome!!!") : base(message)
        {

        }
    }
}
