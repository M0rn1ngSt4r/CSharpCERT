using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class DigitalClock : IClock
    {
        public DigitalClock() { }

        public void SoundAlarm()
        {
            Console.WriteLine("Tictictictic");
        }

        public string GetTime()
        {
            return $"{DateTime.Now:yyyy/MM/dd - HH:mm:ss}";
        }
    }
}
