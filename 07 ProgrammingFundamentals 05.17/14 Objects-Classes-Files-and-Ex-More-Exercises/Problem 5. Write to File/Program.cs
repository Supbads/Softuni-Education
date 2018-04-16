using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_5.Write_to_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[.,,!?:]+";

            Regex regex = new Regex(pattern);

            string inputDirectory = "../../sample_text.txt";
            string outputDirectory = "../../output_text.txt";

            var text = Regex.Replace(File.ReadAllText(inputDirectory), pattern, "");

            File.WriteAllText(outputDirectory, text);
        }
    }
}