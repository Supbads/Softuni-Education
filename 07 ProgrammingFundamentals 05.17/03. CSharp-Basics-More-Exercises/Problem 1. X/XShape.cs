using System;

namespace Problem_1.X
{
    class XShape
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            DrawFirstPartOfShape(n);

            DrawMiddlePartOfShape(n);
            
            DrawBottomPartOfShape(n);


        }

        private static void DrawBottomPartOfShape(int n)
        {
            for (int i = n / 2 - 1; i >= 0 / 2; i--)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string(' ', i), 'x', new string(' ', n - 2 - i * 2));
            }
        }

        private static void DrawMiddlePartOfShape(int n)
        {
            Console.WriteLine("{0}{1}", new string(' ', n / 2), 'x');
        }

        private static void DrawFirstPartOfShape(int n)
        {
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string(' ', i), 'x', new string(' ', n - 2 - i * 2));
            }
        }
    }
}
