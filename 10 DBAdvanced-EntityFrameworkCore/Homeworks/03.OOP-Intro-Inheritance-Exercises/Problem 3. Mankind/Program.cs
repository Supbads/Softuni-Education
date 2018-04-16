using System;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentArgs = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var workerArgs = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Student student = new Student(studentArgs[0], studentArgs[1], studentArgs[2]);
                Worker worker = new Worker(workerArgs[0], workerArgs[1], double.Parse(workerArgs[2]),
                    double.Parse(workerArgs[3]));
                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(worker.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}