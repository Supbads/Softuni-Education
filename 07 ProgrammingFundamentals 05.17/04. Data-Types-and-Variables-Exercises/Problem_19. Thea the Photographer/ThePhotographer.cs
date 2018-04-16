using System;

namespace Problem_19.Thea_the_Photographer
{
    class ThePhotographer
    {
        static void Main()
        {
            int numberOfPicturesTaken = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            double amountAfterFilter = Math.Ceiling((double)numberOfPicturesTaken * filterFactor / 100.0);
            double timeToFilter = (double)numberOfPicturesTaken * filterTime;
            double filteredUploadTime = amountAfterFilter * uploadTime;

            double totalTime = filteredUploadTime + timeToFilter;

            TimeSpan time = TimeSpan.FromSeconds(totalTime);
            string formattedTime = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(formattedTime);
        }
    }
}