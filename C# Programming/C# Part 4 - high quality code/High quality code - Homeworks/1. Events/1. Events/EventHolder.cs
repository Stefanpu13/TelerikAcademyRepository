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
            EventMessageSubscriber.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removedEventsCount= 0;

            foreach (var eventToRemove in byTitle[title])
            {
                removedEventsCount++;
                byDate.Remove(eventToRemove);
            }
            byTitle.Remove(title);
            // TODO: Implement event subscribtion and alert of messages.
            EventMessageSubscriber.EventDeleted(removedEventsCount);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = 
                byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showedEventsCount = 0;

            // TODO: Change "foreach" with "for"?.
            foreach (var eventToShow in eventsToShow)
            {
                if (showedEventsCount == count)
                {
                    break;
                }
                // TODO: Implement event subscribtion and alert of messages.
                EventMessageSubscriber.PrintEvent(eventToShow);
                showedEventsCount++;
            }

            if (showedEventsCount == 0)
            {
                // TODO: Implement event subscribtion and alert of messages.
                EventMessageSubscriber.NoEventsFound();
            }
        }
    }
}
