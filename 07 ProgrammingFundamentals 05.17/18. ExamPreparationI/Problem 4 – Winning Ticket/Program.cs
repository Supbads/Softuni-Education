using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4___Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            var tickets = Console.ReadLine().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToList();

            Regex WinningTicketPattern = new Regex(@"\@{6,10}|\#{6,10}|\^{6,10}|\${6,10}");
            Regex jackpotPattern = new Regex(@"\^{20}|\@{20}|\#{20}|\${20}");
            //[@#$\^] won't work in case of  $$$$$$$^$$$$$^$$$$$$ or ^$$$$$$$$$$$$$$$$$$^

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                if (jackpotPattern.IsMatch(ticket))
                {
                    Console.WriteLine(@"ticket ""{0}"" - 10{1} Jackpot!", ticket, ticket.FirstOrDefault());
                    continue;
                }

                var firstPart = ticket.Substring(0, 10);
                var secondPart = ticket.Substring(10, 10);

                var firstMatch = WinningTicketPattern.Match(firstPart);
                var secondMatch = WinningTicketPattern.Match(secondPart);
                if ((firstMatch.Success && secondMatch.Success) && (firstMatch.Value.FirstOrDefault() == secondMatch.Value.FirstOrDefault()))
                {
                    var firstLenght = firstMatch.Value.Length;
                    var secondLength = secondMatch.Value.Length;

                    

                    Console.WriteLine(@"ticket ""{0}"" - {1}{2}",ticket, Math.Min(firstLenght, secondLength), firstMatch.Value.FirstOrDefault());

                }
                else
                {
                    Console.WriteLine(@"ticket ""{0}"" - no match", ticket);
                }


            }
        }
    }
}
