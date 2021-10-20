using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class ParallelTest
    {
        static void Main()
        {
            Console.WriteLine("Main(), Thread={0}", Thread.CurrentThread.ManagedThreadId);

            Worker w = new Worker();

            try
            {
                Task.Factory.StartNew(
                    () => w.DoWork()
                    );
                //try it instead of Task.Factory.StartNew
                //Parallel.Invoke(
                //   () => w.DoWork()
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
                    case ConsoleKey.P: w.Pause(); Console.WriteLine("|| pause"); break;
                    case ConsoleKey.R: w.Resume(); Console.WriteLine(" > resume"); break;

                    case ConsoleKey.OemPlus: w.PauseInterval += 250; Console.WriteLine(w.PauseInterval); break;
                    case ConsoleKey.OemMinus: w.PauseInterval -= 250; Console.WriteLine(w.PauseInterval); break;
                }
            }
            while (info.Key != ConsoleKey.S);
            w.Stop();

            Console.WriteLine("Main here");

            Console.ReadKey();

        }
    }
}
