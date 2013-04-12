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
        }

        public static void AppendEventAddedMessage()
        {
            output.Append("Event added\n");
        }
        
        public static void AppendEventDeletedMessage(int removedEventsCount)
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

        public static void AppendNoEventsFoundMessage()
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

        public static void AppendEventActionNotFoundMessage(string commandAction) 
        {
            output.Append("Action \"" + commandAction + "\" not found.\n");
        }
    }
}
