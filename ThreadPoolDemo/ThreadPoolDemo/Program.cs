using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);

            ThreadPool.QueueUserWorkItem(callback, "Hi");
            ThreadPool.QueueUserWorkItem(callback, "Ohh My G");
            ThreadPool.QueueUserWorkItem(callback, "Geeeezuss");
            ThreadPool.QueueUserWorkItem(callback, "wow");

            Console.Read();

        }

        public static void ShowMyText(object state)
        {
            string myText = (string)state;

            Console.WriteLine($"thread: {Thread.CurrentThread.ManagedThreadId}, text: {myText}");
        }
    }
}
