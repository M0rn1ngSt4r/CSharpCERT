using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class SolarClock : IClock
    {
        // Constructor
        public SolarClock() { }

        // Sound?
        public void SoundAlarm()
        {
            Console.WriteLine("...");
        }

        // Only hour
        public string GetTime()
        {
            return $"{DateTime.Now:HH}";
        }
    }
}
