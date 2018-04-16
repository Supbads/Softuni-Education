using System;
using System.Collections;
using System.Linq;

namespace Problem_3.String_Disperser
{
    public class StringDisperser : ICloneable , IComparable, IEnumerable
    {
        private string[] strings;

        public StringDisperser(params string[] strings)
        {
            this.strings = strings;
        }

        public override string ToString()
        {
            return Concatenate(this.strings);
        }

        public IEnumerator GetEnumerator()
        {
            string str = this.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                yield return str[i];
            }
        }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }

        public object Clone()
        {
            StringDisperser clone = new StringDisperser((string[])strings.Clone());
            return clone;
        }

        private static string Concatenate(params string[] strings)
        {
            return strings.Aggregate("", (current, str) => current + str);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = strings.Aggregate(0, (current, str) => current ^ str.GetHashCode());
            return hashCode;
        }

        public static bool operator ==(StringDisperser str1, StringDisperser str2)
        {
            return str1.Equals(str2);
        }
        public static bool operator !=(StringDisperser str1, StringDisperser str2)
        {
            return !(str1.Equals(str2));
        }
    }
}
