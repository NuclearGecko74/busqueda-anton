using System;
using System.Diagnostics;

namespace busqueda_anton.src.Utils
{
    public class Timer
    {
        private readonly Stopwatch _sw = new Stopwatch();

        public bool IsRunning => _sw.IsRunning;
        public TimeSpan Elapsed => _sw.Elapsed;
        public double Milliseconds => _sw.Elapsed.TotalMilliseconds;

        public void Start() => _sw.Start();
        public TimeSpan Stop() { _sw.Stop(); return _sw.Elapsed; }
        public void Reset() => _sw.Reset();
        public void Restart() => _sw.Restart();
        public override string ToString() => _sw.Elapsed.ToString(@"hh\:mm\:ss\.fff");

        public static TimeSpan Measure(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
