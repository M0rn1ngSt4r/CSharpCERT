using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class AnalogClock : IClock
    {
        // Constructor
        public AnalogClock() { }

        // Own sound
        public void SoundAlarm()
        {
            Console.WriteLine("Brrrrrrrrrr");
        }

        // Only Hours and minutes
        public string GetTime()
        {
            return $"{DateTime.Now:HH:mm}";
        }
    }
}
