using System;
using System.Threading;

namespace ParallelTest
{
    class Worker
    {
        private bool justDoIt = true;
        private bool isPause = false;
        private volatile uint pauseInterval = 1000;
        internal uint PauseInterval
        {
            get { return pauseInterval; }
            set
            {
                if (value > 100) pauseInterval = value;
            }
        }
        internal void DoWork()
        {
            Console.WriteLine("Method=DoWork, Thread={0}", Thread.CurrentThread.ManagedThreadId);
            while (justDoIt)
            {
                if (isPause)
                {
                    Thread.Sleep(100);//try to comment it and check u cpu load on Pause();
                    continue;
                }
                Console.WriteLine(DateTime.Now);
                Thread.Sleep((int)pauseInterval);
            }
            Console.WriteLine("Work finished");
        }
        internal void Pause() => isPause = true;
        internal void Resume() => isPause = false;
        internal void Stop() => justDoIt = false;
    }
}
