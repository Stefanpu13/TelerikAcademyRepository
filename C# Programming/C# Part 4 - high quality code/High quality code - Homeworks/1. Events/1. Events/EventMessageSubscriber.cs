using System.Text;

namespace _1.Events
{
    static class EventMessageSubscriber
    {
        private static StringBuilder output = new StringBuilder();

        public static StringBuilder Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
            }
        }

        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        // TODO: 
        // If " eventsToRemoveCount" remains consider negative values.
        public static void EventDeleted(int removedEventsCount)
        {
            if (removedEventsCount == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", removedEventsCount);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }
}
