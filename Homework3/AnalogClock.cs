using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class AnalogClock : IClock
    {
        public AnalogClock() { }

        public void SoundAlarm()
        {
            Console.WriteLine("Brrrrrrrrrr");
        }

        public string GetTime()
        {
            return $"{DateTime.Now:HH:mm}";
        }
    }
}
