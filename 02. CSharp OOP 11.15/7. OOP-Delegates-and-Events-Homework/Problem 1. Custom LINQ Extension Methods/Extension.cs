using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Custom_LINQ_Extension_Methods
{
    public static class Extension
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            //return collection.Where(item => !predicate(item)).ToList();  works as well 
            List<T> newList = new List<T>();
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

    }
}
