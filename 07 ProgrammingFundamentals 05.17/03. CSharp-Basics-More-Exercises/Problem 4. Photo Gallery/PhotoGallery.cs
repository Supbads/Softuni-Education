using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Photo_Gallery
{
    
    class PhotoGallery
    {
        static void Main(string[] args)
        {
            string photoNumber = Console.ReadLine();

            string day = Console.ReadLine();
            string month = Console.ReadLine();
            string year = Console.ReadLine();

            string hours = Console.ReadLine();
            string minutes = Console.ReadLine();

            double fileSize = double.Parse(Console.ReadLine());

            string[] dataSizes = new[] { "B", "KB", "MB", "GB", "TB" };
            int dataSizeCounter = 0;

            int photoWidth = int.Parse(Console.ReadLine());
            int photoHeight = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: DSC_{0}.jpg", photoNumber.PadLeft(4, '0'));
            Console.WriteLine("Date Taken: {0}/{1}/{2} {3}:{4}", day.PadLeft(2, '0'), month.PadLeft(2, '0'), year, hours.PadLeft(2,'0'), minutes.PadLeft(2,'0'));

            while (fileSize / 1000 >= 1)
            {
                fileSize /= 1000;

                dataSizeCounter++;
            }

            Console.WriteLine("Size: {0:#.#}{1}", fileSize , dataSizes[dataSizeCounter]);

            string photoOrentation;
            if (photoWidth > photoHeight)
            {
                photoOrentation = "landscape";
            }
            else if (photoWidth < photoHeight)
            {
                photoOrentation = "portrait";
            }
            else
            {
                photoOrentation = "square";
            }

            Console.WriteLine("Resolution: {0}x{1} ({2})", photoWidth, photoHeight, photoOrentation);

        }
    }
}
