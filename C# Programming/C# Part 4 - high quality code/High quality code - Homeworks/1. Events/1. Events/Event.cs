using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Events
{
    class Event : IComparable
    {
        public Event(DateTime date, String title, String location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public String Title { get; set; }

        public String Location { get; set; }

        /// <summary>
        /// Compares two events. The first comparison criteria is event date. If the dates are 
        /// equal event title is used and if the titles are equal the event location is used. 
        /// </summary>
        /// <param name="other">The event object to compare with this event.</param>
        /// <returns>A value equal to 1 if this event is bigger than the other,
        /// 0 if two events are equal and -1 if other event is bigger than this. </returns>
        public int CompareTo(object other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                if (other is Event)
                {
                    Event otherEvent = other as Event;

                    int comparisonResultByDate = this.Date.CompareTo(otherEvent.Date);
                    int comparisonResultByTitle = this.Title.CompareTo(otherEvent.Title);
                    int comparisonResultByLocation = this.Location.CompareTo(otherEvent.Location);

                    if (comparisonResultByDate == 0)
                    {
                        if (comparisonResultByTitle == 0)
                        {
                            return comparisonResultByLocation;
                        }
                        else
                        {
                            return comparisonResultByTitle;
                        }
                    }
                    else
                    {
                        return comparisonResultByDate;
                    }
                }
                else
                {
                    string message = "Object passed for comparison is not of type " +
                       this.GetType().Name;
                    throw new ArgumentException(message);
                }
            }
        }

        public override string ToString()
        {            
            StringBuilder eventInformation = new StringBuilder();

            eventInformation.Append(Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            eventInformation.Append(" | " + Title);
            if (Location != null && Location != string.Empty)
            {
                eventInformation.Append(" | " + Location);
            }

            return eventInformation.ToString();
        }
    }
}
