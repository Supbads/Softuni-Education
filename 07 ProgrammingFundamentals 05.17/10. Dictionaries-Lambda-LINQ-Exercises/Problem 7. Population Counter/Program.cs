using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> countriesAndCities = new Dictionary<string, Dictionary<string, long>>();

        string input = Console.ReadLine();
        while (input!="report")
        {
            var tokens = input.Split(new[] {'|'});
            var city = tokens[0];
            var country = tokens[1];
            var population = long.Parse(tokens[2]);

            if (!countriesAndCities.ContainsKey(country))
            {
                countriesAndCities.Add(country, new Dictionary<string, long>());
            }

            if(!countriesAndCities[country].ContainsKey(city))
            {
                countriesAndCities[country].Add(city, 0);
            }

            countriesAndCities[country][city] += population;

            input = Console.ReadLine();
        }

        foreach (var countryAndCityPair in countriesAndCities.OrderByDescending(x => x.Value.Sum(y => y.Value)))
        {
            var currentPopulationSum = countryAndCityPair.Value.Sum(y => y.Value);

            Console.WriteLine("{0} (total population: {1})",countryAndCityPair.Key, currentPopulationSum);

            foreach (var cityAndPopulation in countryAndCityPair.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("=>{0}: {1}", cityAndPopulation.Key, cityAndPopulation.Value);

            }

        }

    }
}