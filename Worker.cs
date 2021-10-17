using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Worker
    {
        private bool justDoIt = true;
        private bool isPause = false;
        private uint pauseInterval = 1000;
        internal uint PauseInterval
        {
            get { return pauseInterval; }
            set { if (value > 100) pauseInterval = value; }
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
                await Task.Delay((int)pauseInterval);
            }
            Console.WriteLine("Work finished");
        }
        internal void Pause() => isPause = true;
        internal void Resume() => isPause = false;
        internal void Stop() => justDoIt = false;
    }
}
