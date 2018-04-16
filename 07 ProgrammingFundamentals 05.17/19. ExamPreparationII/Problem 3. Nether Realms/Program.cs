using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3.Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.ReadLine().Split(new[] {',', ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToArray();
            var demons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x)
                .ToArray();

            Regex healthCharactersExtractor = new Regex(@"[^0-9-+*\/\.]");
            Regex multiplicativeSymbolsExtractor = new Regex(@"[\/*]");
            Regex numbersExtractor = new Regex(@"(-?[0-9.]+)|(\+?[0-9.])");

            foreach (var demon in demons)
            {
                long healthSum = 0;
                double damage = 0;

                var healthMatches = healthCharactersExtractor.Matches(demon);
                foreach (Match healthMatch in healthMatches)
                {
                    var currentChar = healthMatch.Value.FirstOrDefault();
                    healthSum += currentChar;

                }

                var damageMatches = numbersExtractor.Matches(demon);
                foreach (Match damageMatch in damageMatches)
                {
                    var currentDamage = double.Parse(damageMatch.Value);

                    damage += currentDamage;
                }

                var multiplicatorsMatches = multiplicativeSymbolsExtractor.Matches(demon);
                foreach (Match multiplicator in multiplicatorsMatches)
                {
                    var currentSymbol = multiplicator.Value.FirstOrDefault();

                    if (currentSymbol == '*')
                    {
                        damage *= 2;
                    }
                    else// if (currentSymbol == '/')
                    {
                        damage/=2;
                    }
                }

                Console.WriteLine("{0} - {1} health, {2:F2} damage", demon,healthSum, damage);
            }
        }
    }
}
