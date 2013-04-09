using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _8.InIntervalUsingEvent
{
    //This is the "publisher" class. It determines when the event is raised.
    class TimerPublisher
    {
        
        public event EventHandler<IntervalEventArgs> TimeIntervalElapsedEvent;

        //Raiser method. It is made virtual so it can be overrided in derived classes.
        //This method will be called on every "t" seconds.
        protected virtual void OnTimeIntervalElapsed(IntervalEventArgs iea) 
        {
            //Create a copy of the event object to avoid race condition.
            //See: http://msdn.microsoft.com/en-us/library/w369ty8x.aspx
            EventHandler<IntervalEventArgs> timerHandler = TimeIntervalElapsedEvent;

            if (TimeIntervalElapsedEvent != null)
            {
                //raise the event
                TimeIntervalElapsedEvent(this, iea);
            }
        }

        //The method whose execution will raise the event.
        public void ExecuteAtInterval(int intervalInSeconds, int eventRaisedCount)
        {           
                
            //create an object of the class that holds the event custom data
            IntervalEventArgs iea = new IntervalEventArgs(intervalInSeconds, eventRaisedCount);
            int intervalInMiliseconds = 1000 * intervalInSeconds;
            iea.EventRaiseCounter = 1;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (iea.EventRaiseCounter <= iea.EventRaiseTotalCount)
            {
                if (timer.ElapsedMilliseconds == intervalInMiliseconds)
                {
                    OnTimeIntervalElapsed(iea);
                    timer.Restart();
                }
            }
        }
    }
}
