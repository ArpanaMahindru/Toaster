using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Oven
{
    /// <summary>
    /// This class allows to set the timer for slot group to cook Item.
    /// </summary>
    public class Dialer
    {
        internal System.Timers.Timer CookTimer;

        public Dialer(TimeSpan? timeSpan)
        {
            SetTimer(timeSpan);
        }
        public void SetTimer(TimeSpan? timer)
        {
            if (timer.HasValue)
            {
                // Create a timer with a two second interval.
                CookTimer = new System.Timers.Timer(timer.Value.TotalMilliseconds);
                // Hook up the Elapsed event for the timer. 
                CookTimer.AutoReset = true;
                CookTimer.Enabled = true;
            }
        }


    }
}
