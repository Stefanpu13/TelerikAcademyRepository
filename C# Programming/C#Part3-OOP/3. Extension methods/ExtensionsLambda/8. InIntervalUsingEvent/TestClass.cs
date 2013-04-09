using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics    ;

namespace _8.InIntervalUsingEvent
{
    /** Read in MSDN about the keyword event in C# and how to publish events.
     * Re-implement the above using .NET events and following the best practices.
*/
    class TestClass
    {
        static void Main(string[] args)
        {
           

            TimerPublisher timerInstance
                = new TimerPublisher();
            //This object`s handler method is subscribed in the construcor
            TimerSubscriber firstTimerSubsrciber = new TimerSubscriber(timerInstance);

            Console.WriteLine("Subscriber object whose handler subscribes in the constructor.\n");
            timerInstance.ExecuteAtInterval(1, 5);
            //Unsublscribe first timer subscriber.
            timerInstance.TimeIntervalElapsedEvent -= firstTimerSubsrciber.HandleTimerEvent;

            TimerSubscriber secondTimerSubscriber = new TimerSubscriber();

            Console.WriteLine("Subscriber object whose handler subscribes in this class.\n");
            //Subscribe the seconf object method to the event
            timerInstance.TimeIntervalElapsedEvent += secondTimerSubscriber.HandleTimerEvent;
            timerInstance.ExecuteAtInterval(1, 5);
        }

       
    }
}
