namespace _1.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private readonly MultiDictionary<string, Event> eventsMultiDictionary = 
            new MultiDictionary<string, Event>(true);
        private readonly OrderedBag<Event> eventsOrderedBag = new OrderedBag<Event>();

        public event EventHandler EventHolderChanged;

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.eventsMultiDictionary.Add(title.ToLower(), newEvent);
            this.eventsOrderedBag.Add(newEvent);

            this.OnEventHolderChanged(EventArgs.Empty);            
            EventMessageSubscriber.AppendEventAddedMessage();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removedEventsCount = 0;
            ICollection<Event> eventsWithSameTitle = this.eventsMultiDictionary[title];

            foreach (var eventToRemove in eventsWithSameTitle)
            {
                removedEventsCount++;
                this.eventsOrderedBag.Remove(eventToRemove);
            }

            this.eventsMultiDictionary.Remove(title);

            this.OnEventHolderChanged(EventArgs.Empty);            
            EventMessageSubscriber.AppendEventDeletedMessage(removedEventsCount);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow =
                this.eventsOrderedBag.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showedEventsCount = 0;
            
            foreach (var eventToShow in eventsToShow)
            {
                if (showedEventsCount == count)
                {
                    break;
                }

                this.OnEventHolderChanged(EventArgs.Empty);                
                EventMessageSubscriber.PrintEvent(eventToShow);
                showedEventsCount++;
            }

            if (showedEventsCount == 0)
            {
                this.OnEventHolderChanged(EventArgs.Empty);                
                EventMessageSubscriber.AppendNoEventsFoundMessage();
            }
        }

        protected virtual void OnEventHolderChanged(EventArgs e)
        {
            if (this.EventHolderChanged != null)
            {
                this.EventHolderChanged(this, e);
            }
        }
    }
}
