using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _1.Events
{
    class EventHolder
    {
        // TODO: Change collections names. 
        MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            byTitle.Add(title.ToLower(), newEvent);
            byDate.Add(newEvent);
            // TODO: Implement event subscribtion and alert of messages.
            Message.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int eventsToRemoveCount= 0;

            foreach (var eventToRemove in byTitle[title])
            {
                eventsToRemoveCount++;
                byDate.Remove(eventToRemove);
            }
            byTitle.Remove(title);
            // TODO: Implement event subscribtion and alert of messages.
            Message.EventDeleted(eventsToRemoveCount);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = 
                byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            // TODO: Change "foreach" with "for".
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }
                // TODO: Implement event subscribtion and alert of messages.
                Message.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                // TODO: Implement event subscribtion and alert of messages.
                Message.NoEventsFound();
            }
        }
    }
}
