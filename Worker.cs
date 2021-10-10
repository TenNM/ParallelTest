using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ParallelTest
{
    class Worker
    {
        static volatile bool justDoIt = true;
        static volatile bool pause = false;
        internal void DoWork()
        {
            Console.WriteLine("Method=DoWork, Thread={0}", Thread.CurrentThread.ManagedThreadId);
            while (justDoIt)
            {
                if (pause)
                {
                    Thread.Sleep(100);//try to comment it and check u cpu load on Pause();
                    continue;
                }
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Work finished");
        }
        internal void Pause() => pause = true;
        internal void Resume() => pause = false;
        internal void Stop() => justDoIt = false;
    }
}
