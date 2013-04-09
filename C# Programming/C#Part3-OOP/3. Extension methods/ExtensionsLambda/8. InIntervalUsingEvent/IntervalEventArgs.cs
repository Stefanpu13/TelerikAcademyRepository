using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.InIntervalUsingEvent
{
    //This class is used to hold and pass the event data that might be required by the handler.
    class IntervalEventArgs:EventArgs
    {
        //Both fields are encapsulated through public readonly properties, so
        //no external code can change them.
        // Why? TODO: Find where you read that making these properties accessible is not a good practice.
        private int interval;
        private int eventRaiseCount;

        public IntervalEventArgs(int atInterval, int raiseCount) 
        {
            this.interval = atInterval;
            this.eventRaiseCount = raiseCount;
        }

        //Iterval determines the interval in seconds at which the event is raised
        public int Interval { get { return interval; } }

        //Execution counter determines the number of times the event is raised.
        public int EventRaiseTotalCount { get { return eventRaiseCount; } }
        
        //This property is used in to show the current number of raised events
        public int EventRaiseCounter { get; set; }

        
    }
}
