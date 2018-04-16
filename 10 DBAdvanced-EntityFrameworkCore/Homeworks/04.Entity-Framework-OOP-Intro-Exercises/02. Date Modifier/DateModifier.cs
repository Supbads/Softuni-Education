using System;

namespace _02.Date_Modifier
{
    class DateModifier
    {
        public DateModifier(DateTime firstDate, DateTime secondDate)
        {
            FirstDate = firstDate;
            SecondDate = secondDate;
        }

        public DateTime FirstDate { get; set; }

        public DateTime SecondDate { get; set; }

        public string Difference()
        {
            var timeSpan = Math.Ceiling(Math.Abs((FirstDate - SecondDate).TotalDays));

            return timeSpan.ToString();
        }

    }
}