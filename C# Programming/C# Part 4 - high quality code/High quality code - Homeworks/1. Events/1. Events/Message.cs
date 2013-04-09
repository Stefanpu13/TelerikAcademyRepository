using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Events
{
    static class Message
    {
        private static StringBuilder output = new StringBuilder();

        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        // TODO: What is "x"? Rename and if more convenient - replace with other type.
        // If " x" remains consider negative values.
        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", x);
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
