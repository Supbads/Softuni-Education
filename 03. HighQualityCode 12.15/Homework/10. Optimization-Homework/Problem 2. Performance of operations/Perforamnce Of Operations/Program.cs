namespace Peformance_Of_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

   class Program
    {
       private const int NumberOfOperations = 10000;

        static void Main()
        {
            SumPerformance();
            Console.WriteLine();

            SubtractPerformance();
            Console.WriteLine();

            PrefixPerformance();
            Console.WriteLine();

            PostfixPerformance();
            Console.WriteLine();

            PlusOnePerformance();
            Console.WriteLine();

            MultiplyPerformance();
            Console.WriteLine();

            DividePerformance();
            Console.WriteLine();

            SqrtPerformance();
            Console.WriteLine();

            LogPerformance();
            Console.WriteLine();

            SinPerformance();
            //Console.WriteLine();
        }

        static void SumPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);

            for (int j = 0; j < NumberOfOperations; j++)
            {
                int numInt = 1000;

                sw.Restart();
                for (int i = 0; i < 500; i++)
                {
                    numInt += i;
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                long numLong = 1000;

                sw.Restart();
                for (long i = 0; i < 500; i++)
                {
                    numLong += i;
                }

                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;

                //

                double numDouble = 1000;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble += i;
                }

                sw.Stop();
                list[2] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1000;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal += i;
                }
                sw.Stop();
                list[3] += sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("int     sum 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("long    sum 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
            Console.WriteLine("double  sum 500 times - {0:f6} miliseconds", list[2] / NumberOfOperations);
            Console.WriteLine("decimal sum 500 times - {0:f6} miliseconds", list[3] / NumberOfOperations);
        }

        static void SubtractPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                int numInt = 1000000;

                sw.Restart();
                for (int i = 0; i < 500; i++)
                {
                    numInt -= i;
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                long numLong = 1000000;

                sw.Restart();
                for (long i = 0; i < 500; i++)
                {
                    numLong -= i;
                }

                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;

                //

                double numDouble = 1000000;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble -= i;
                }

                sw.Stop();
                list[2] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1000000;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal -= i;
                }
                sw.Stop();
                list[3] += sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("int     subtract 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("long    subtract 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
            Console.WriteLine("double  subtract 500 times - {0:f6} miliseconds", list[2] / NumberOfOperations);
            Console.WriteLine("decimal subtract 500 times - {0:f6} miliseconds", list[3] / NumberOfOperations);
        }

        static void PrefixPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                int numInt = 1;

                sw.Restart();
                for (int i = 0; i < 500; i++)
                {
                    ++numInt;
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                long numLong = 1;

                sw.Restart();
                for (long i = 0; i < 500; i++)
                {
                    ++numLong;
                }

                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;

                //

                double numDouble = 1;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    ++numDouble;
                }

                sw.Stop();
                list[2] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    ++numDecimal;
                }
                sw.Stop();
                list[3] += sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("int     prefix 500 times - {0:f6} miliseconds", list[0] / 10000);
            Console.WriteLine("long    prefix 500 times - {0:f6} miliseconds", list[1] / 10000);
            Console.WriteLine("double  prefix 500 times - {0:f6} miliseconds", list[2] / 10000);
            Console.WriteLine("decimal prefix 500 times - {0:f6} miliseconds", list[3] / 10000);
        }

        static void PostfixPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                int numInt = 1;

                sw.Restart();
                for (int i = 0; i < 500; i++)
                {
                    numInt++;
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                long numLong = 1;

                sw.Restart();
                for (long i = 0; i < 500; i++)
                {
                    numLong++;
                }

                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;

                //

                double numDouble = 1;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble++;
                }

                sw.Stop();
                list[2] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal++;
                }
                sw.Stop();
                list[3] += sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("int     postfix 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("long    postfix 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
            Console.WriteLine("double  postfix 500 times - {0:f6} miliseconds", list[2] / NumberOfOperations);
            Console.WriteLine("decimal postfix 500 times - {0:f6} miliseconds", list[3] / NumberOfOperations);
        }

        static void PlusOnePerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                int numInt = 1000;

                sw.Restart();
                for (int i = 0; i < 500; i++)
                {
                    numInt += 1;
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                long numLong = 1000;

                sw.Restart();
                for (long i = 0; i < 500; i++)
                {
                    numLong += 1;
                }

                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;

                //

                double numDouble = 1000;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble += 1;
                }

                sw.Stop();
                list[2] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1000;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal += 1;
                }
                sw.Stop();
                list[3] += sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("int     plus 1 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("long    plus 1 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
            Console.WriteLine("double  plus 1 500 times - {0:f6} miliseconds", list[2] / NumberOfOperations);
            Console.WriteLine("decimal plus 1 500 times - {0:f6} miliseconds", list[3] / NumberOfOperations);
        }

        static void MultiplyPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                int numInt = 1;

                sw.Restart();
                for (int i = 0; i < 500; i++)
                {
                    numInt *= 1;
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                long numLong = 1;

                sw.Restart();
                for (long i = 0; i < 500; i++)
                {
                    numLong *= 1;
                }

                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;

                //

                double numDouble = 1;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble *= 1;
                }

                sw.Stop();
                list[2] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal *= 1;
                }
                sw.Stop();
                list[3] += sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("int     multiply 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("long    multiply 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
            Console.WriteLine("double  multiply 500 times - {0:f6} miliseconds", list[2] / NumberOfOperations);
            Console.WriteLine("decimal multiply 500 times - {0:f6} miliseconds", list[3] / NumberOfOperations);
        }

        static void DividePerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                int numInt = 1;

                sw.Restart();
                for (int i = 0; i < 500; i++)
                {
                    numInt /= 1;
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                long numLong = 1;

                sw.Restart();
                for (long i = 0; i < 500; i++)
                {
                    numLong /= 1;
                }

                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;

                //

                double numDouble = 1;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble /= 1;
                }

                sw.Stop();
                list[2] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal /= 1;
                }
                sw.Stop();
                list[3] += sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("int     divide 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("long    divide 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
            Console.WriteLine("double  divide 500 times - {0:f6} miliseconds", list[2] / NumberOfOperations);
            Console.WriteLine("decimal divide 500 times - {0:f6} miliseconds", list[3] / NumberOfOperations);
        }

        static void SqrtPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(2);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                double numDouble = 1000;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble = Math.Sqrt(i);
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1000;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal = (decimal)Math.Sqrt((double)i);
                }
                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;
            }

            Console.WriteLine("double  sqrt 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("decimal sqrt 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
        }

        static void LogPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(2);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                double numDouble = 1000;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    Math.Log(i);
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1000;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    Math.Log((double)i);
                }
                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;
            }

            Console.WriteLine("double  log 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("decimal log 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
        }

        static void SinPerformance()
        {
            var sw = new Stopwatch();
            var list = new List<double>(2);
            list.Add(0);
            list.Add(0);

            //
            for (int j = 0; j < NumberOfOperations; j++)
            {
                double numDouble = 1000;

                sw.Restart();
                for (double i = 0; i < 500; i++)
                {
                    numDouble = Math.Sin(1);
                }

                sw.Stop();
                list[0] += sw.Elapsed.TotalMilliseconds;

                //

                decimal numDecimal = 1000;

                sw.Restart();
                for (decimal i = 0; i < 500; i++)
                {
                    numDecimal = (decimal)Math.Sin(1);
                }
                sw.Stop();
                list[1] += sw.Elapsed.TotalMilliseconds;
            }

            Console.WriteLine("double  sin 500 times - {0:f6} miliseconds", list[0] / NumberOfOperations);
            Console.WriteLine("decimal sin 500 times - {0:f6} miliseconds", list[1] / NumberOfOperations);
        }
    }
}
