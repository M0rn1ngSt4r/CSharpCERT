using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class SolarClock : IClock
    {
        public SolarClock() { }

        public void SoundAlarm()
        {
            Console.WriteLine("...");
        }

        public string GetTime()
        {
            return $"{DateTime.Now:HH}";
        }
    }
}
