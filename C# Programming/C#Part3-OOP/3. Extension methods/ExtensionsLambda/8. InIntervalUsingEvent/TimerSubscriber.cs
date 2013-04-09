using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.InIntervalUsingEvent
{
    class TimerSubscriber
    {
        //This empty constructor is used to create a subscriber object that whose "HandleTimerEvent" method
        //will subscribe in the "TestClass".
        public TimerSubscriber() { }

        public TimerSubscriber(TimerPublisher timer) 
        {
            //This constructor overload makes subscription here.
            timer.TimeIntervalElapsedEvent += HandleTimerEvent;
        }

        //A handler - method that will handle the raised event. This means
        //that this method will execute when the event is raised. Of course, 
        //the method should first subscribe for the event - this happens in the constrcutor.
        public void HandleTimerEvent(object sender, IntervalEventArgs iea) 
        {
            Console.WriteLine("First method executed {0} times",iea.EventRaiseCounter++);
        }
    }
}
