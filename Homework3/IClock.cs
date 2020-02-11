using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    interface IClock
    {
        // Alarm
        public void SoundAlarm();

        // Available time
        public string GetTime();
    }
}
