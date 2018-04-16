using System;

namespace Problem_1.Human__Student_and_Worker
{
    class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, int workHoursPerDay, decimal weekSalary) : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Worker's weekly salary cannot be negative");
                }
                weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("Worker's work hours per day cannot be negative or more than 24");
                }
                workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = weekSalary/(workHoursPerDay*7);
            moneyPerHour /= 24;
            return moneyPerHour;
        }
    }
}
