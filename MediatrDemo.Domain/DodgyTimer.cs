namespace MediatrDemo.Domain
{
    using System;
    using System.Diagnostics;

    public class DodgyTimer : IDisposable
    {
        private readonly string message;

        private readonly Stopwatch watch;

        public DodgyTimer(string message)
        {
            this.message = message;

            watch = new Stopwatch();
            watch.Start();
        }

        public void Dispose()
        {
            watch.Stop();
            DodgyLogger.LogAsync($"{watch.ElapsedMilliseconds}ms - {message}", "c:/code/performanceOutput.txt").Wait();
        }
    }
}