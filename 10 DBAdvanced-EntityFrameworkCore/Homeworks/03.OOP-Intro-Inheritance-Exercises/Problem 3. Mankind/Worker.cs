namespace Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($"Week Salary: {this.WeekSalary:F2}");
            result.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");

            double totalWorktime = this.workHoursPerDay * 5;
            double salaryPerHour = this.WeekSalary / totalWorktime;

            result.Append($"Salary per hour: {salaryPerHour:F2}");

            return result.ToString();
        }
    }
}