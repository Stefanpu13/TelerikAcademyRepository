namespace _1.Events
{
    using System;
    using System.Linq;
    using System.Text;

    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// Compares two events. The first comparison criteria is event date. If the dates are 
        /// equal event title is used and if the titles are equal the event location is used. 
        /// </summary>
        /// <param name="other">The event object to compare with this event.</param>
        /// <returns>A value <b>bigger than 0</b> if this event is bigger than the other,
        /// 0 if two events are equal and <b>smaller than 0</b> if other event is bigger than this. </returns>
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

            eventInformation.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            eventInformation.Append(" | " + this.Title);
            if (this.Location != null && this.Location != string.Empty)
            {
                eventInformation.Append(" | " + this.Location);
            }

            return eventInformation.ToString();
        }
    }
}
