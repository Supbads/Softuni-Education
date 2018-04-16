using System;

namespace Problem_5.BPM_Counter
{
    class BPMCounter
    {
        static void Main()
        {
            decimal beatsPerMinute = decimal.Parse(Console.ReadLine());
            decimal numberofBeats = decimal.Parse(Console.ReadLine());

            decimal bars = numberofBeats / 4.0m;

            decimal lengthInSeconds = numberofBeats / beatsPerMinute * 60;

            int minutes = (int)lengthInSeconds / 60;
            lengthInSeconds -= minutes * 60;
           
            Console.WriteLine("{0} bars - {1}m {2}s", Math.Round(bars, 1) , minutes, Math.Floor(lengthInSeconds));
        }
    }
}
