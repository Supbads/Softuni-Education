using System;
namespace Problem_5.BitArray
{
    class BitArray
    {
        private byte[] array;
        private int length;
        public BitArray(int length)
        {
            this.Length = length;
            this.Array = new byte[length];
            for (int i = 0; i < length; i++)
            {
                this.Array[i] = 0;
            }
        }

        public byte[] Array
        {
            get { return array; }
            set { array = value; }
        }


        public int Length
        {
            get { return length; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                if (value > 100000 || value < 1)
                {
                    throw new ArgumentException();
                }
                length = value;
            }
        }
        public byte this[int i]
        {
            get { return this.array[i]; }
            set
            {
                if (!(value == 0 || value == 1))
                {
                    throw new ArgumentException("Bit Array could contain only Ones and Zeroes");
                }
                this.array[i] = value;
            }
        }

        public override string ToString()
        {
            ulong result = 0;
            for (int i = 0; i < length; i++)
            {
                if (array[i] == 1)
                {
                    result += (ulong)Math.Pow(2, i);
                }
            }
            return result.ToString();
        }
    }
}
