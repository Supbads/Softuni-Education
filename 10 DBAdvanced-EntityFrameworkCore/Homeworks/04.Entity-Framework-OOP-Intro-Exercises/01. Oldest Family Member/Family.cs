using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Oldest_Family_Member
{
    class Family
    {
        public Family()
        {
            this.Members = new List<Person>();
        }

        public List<Person> Members { get; set; }

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.Members.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}