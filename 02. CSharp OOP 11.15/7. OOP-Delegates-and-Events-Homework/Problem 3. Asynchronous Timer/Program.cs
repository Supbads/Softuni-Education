using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Asynchronous_Timer
{
    class Program
    {
        static void Main()
        {

            Action action = TestMethod;
            AsyncTimer asyncTimer = new AsyncTimer(5, 1000, action);
            asyncTimer.Run();
            string testString = Console.ReadLine();

        }
        public static void TestMethod()
        {
            Console.WriteLine("test");
        }
    }
}
