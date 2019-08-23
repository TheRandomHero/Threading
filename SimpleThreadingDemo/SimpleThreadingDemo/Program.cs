using System;
using System.Threading;
namespace SimpleThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(Counting);

            Thread firstThread = new Thread(starter);
            Thread secondThread = new Thread(starter);

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();

            Console.Read();
        }

        public static void Counting()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Count;{i}, thread: {Thread.CurrentThread.ManagedThreadId}");


                Thread.Sleep(10000);
                
            }
        }
    }
}
