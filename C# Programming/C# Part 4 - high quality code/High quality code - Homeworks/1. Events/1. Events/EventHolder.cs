using System;
using System.Linq;
using Wintellect.PowerCollections;
using System.Collections.Generic;

namespace _1.Events
{
    class EventHolder
    {
        //public event EventHandler EventHolderChanged;

        private readonly MultiDictionary<string, Event> eventsMultiDictionary = 
            new MultiDictionary<string, Event>(true);
        private readonly OrderedBag<Event> eventsOrderedBag = new OrderedBag<Event>();

        //protected virtual void OnEventHolderChanged(EventArgs e)
        //{

        //}

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            eventsMultiDictionary.Add(title.ToLower(), newEvent);
            eventsOrderedBag.Add(newEvent);
            
            // TODO: Implement event subscribtion and alert of messages.
            EventMessageSubscriber.AppendEventAddedMessage();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removedEventsCount = 0;
            ICollection<Event> eventsWithSameTitle = eventsMultiDictionary[title];

            foreach (var eventToRemove in eventsWithSameTitle)
            {
                removedEventsCount++;
                eventsOrderedBag.Remove(eventToRemove);
            }
            eventsMultiDictionary.Remove(title);
            // TODO: Implement event subscribtion and alert of messages.
            EventMessageSubscriber.AppendEventDeletedMessage(removedEventsCount);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = 
                eventsOrderedBag.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showedEventsCount = 0;
            
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
                EventMessageSubscriber.AppendNoEventsFoundMessage();
            }
        }
    }
}
