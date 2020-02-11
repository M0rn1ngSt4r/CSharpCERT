using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class DigitalClock : IClock
    {
        // Constructor
        public DigitalClock() { }

        // Own sound
        public void SoundAlarm()
        {
            Console.WriteLine("Tictictictic");
        }

        // All info possible
        public string GetTime()
        {
            return $"{DateTime.Now:yyyy/MM/dd - HH:mm:ss}";
        }
    }
}
