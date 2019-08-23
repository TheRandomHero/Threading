using System;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = null;
            const string mutexName = "RUNMEONLYONCE";

            while(true){
                try
                {
                    mutex = Mutex.OpenExisting(mutexName);

                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    if (mutex == null)
                    {
                        mutex = new Mutex(true, mutexName);
                    }
                    else
                    {
                        mutex.Close();
                        return;
                    }

                    Console.Read();
                }
            }
        }
    }
}
