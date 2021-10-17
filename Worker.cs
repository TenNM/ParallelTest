using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Worker
    {
        private bool justDoIt = true;
        private bool isPause = false;
        private int pauseInterval = 1000;
        internal int PauseInterval
        {
            get { return pauseInterval; }
            set
            {
                if (pauseInterval + value > 0) pauseInterval = value;
                else pauseInterval = 0;
            }
        }
        internal async void DoWork()
        {
            Console.WriteLine("DoWork(), Thread={0}", Thread.CurrentThread.ManagedThreadId);
            while (justDoIt)
            {
                if (isPause)
                {
                    await Task.Delay(100);//try to comment it and check u cpu load on Pause();
                    continue;
                }
                Console.WriteLine(DateTime.Now);
                await Task.Delay(pauseInterval);
            }
            Console.WriteLine("Work finished");
        }
        internal void Pause() => isPause = true;
        internal void Resume() => isPause = false;
        internal void Stop() => justDoIt = false;
    }
}
