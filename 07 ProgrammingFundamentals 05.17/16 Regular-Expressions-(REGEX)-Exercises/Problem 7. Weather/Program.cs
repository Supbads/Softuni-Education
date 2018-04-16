using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_7.Weather
{
    class Program
    {
        public struct WeatherDetails
        {
            public float Temperature { get; set; }

            public string Weather { get; set; }
        }

        static void Main(string[] args)
        {
            Dictionary<string,WeatherDetails> weather = new Dictionary<string, WeatherDetails>();

            string pattern = @"([A-Z]{2})([0-9]+\.[0-9]+)([a-zA-Z]+)(?=\|)";
            //([A-Z]{2})([0-9]+\.[0-9]+)([^\|\s\r\t\n]+)(?=\|)
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            
            while (input != "end")
            {
                var matches = regex.Matches(input);

                //validation can be extracted
                if (matches.Count == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                foreach (Match match in matches) // only one match per row
                {
                    var place = match.Groups[1].ToString();
                    var temperature = float.Parse(match.Groups[2].ToString());
                    var currentWeather = match.Groups[3].ToString();

                    if (!weather.ContainsKey(place))
                    {
                        weather.Add(place, new WeatherDetails
                        {
                            Temperature = temperature,
                            Weather = currentWeather
                        });
                    }
                    else
                    {
                        weather[place] = new WeatherDetails
                        {
                            Temperature = temperature,
                            Weather = currentWeather
                        };
                    }

                }


                input = Console.ReadLine();
            }


            foreach (var weatherAndDetails in weather.OrderBy(x => x.Value.Temperature))
            {
                var weatherDetails = weatherAndDetails.Value;

                Console.WriteLine("{0} => {1:F2} => {2}",weatherAndDetails.Key, weatherDetails.Temperature, weatherDetails.Weather);


            }

        }
    }
}