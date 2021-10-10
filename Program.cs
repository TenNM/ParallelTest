using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class ParallelInvoke
    {
        static void Main()
        {
            Console.WriteLine("Method=Main, Thread={0}", Thread.CurrentThread.ManagedThreadId);

            Worker w = new Worker();

            try
            {
                var v = Task.Factory.StartNew(
                    () => w.DoWork()
                    );
                //try it instead of Task.Factory.StartNew
                //Parallel.Invoke(
                //   () => w.DoWork(continueWork)
                //);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.ToString());
            }

            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.P: w.Pause(); break;
                    case ConsoleKey.R: w.Resume(); break;
                }
            }
            while (info.Key != ConsoleKey.S);
            w.Stop();

            Console.WriteLine("Main there");

            Console.ReadKey();

        }
    }
}
