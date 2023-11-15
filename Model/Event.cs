using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event : BaseEntity
    {
        protected string eventName;
        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }

        protected User creator;
        public User Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        protected EventType eventType;
        public EventType EventType
        {
            get { return EventType; }
            set { eventType = value; }
        }

        protected bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }

        protected DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        protected DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        protected DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        protected DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        protected string displayColor;
        public string DisplayColor
        {
            get { return displayColor; }
            set { displayColor = value; }
        }
    }

    public class EventList : List<Event>
    {
        public EventList() { }
        public EventList(IEnumerable<Event> list) : base(list) { }
        public EventList(IEnumerable<BaseEntity> list) : base(list.Cast<Event>().ToList()) { }
    }

}
