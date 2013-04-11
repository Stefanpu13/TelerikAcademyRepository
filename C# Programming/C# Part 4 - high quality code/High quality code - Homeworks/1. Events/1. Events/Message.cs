﻿using System.Text;

namespace _1.Events
{
    static class Message
    {
        private static StringBuilder output = new StringBuilder();

        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        // TODO: 
        // If " eventsToRemoveCount" remains consider negative values.
        public static void EventDeleted(int eventsToRemoveCount)
        {
            if (eventsToRemoveCount == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", eventsToRemoveCount);
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
