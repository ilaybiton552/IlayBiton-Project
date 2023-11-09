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

        protected int creator;
        public int Creator
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

    public class UserEvent : List<Event>
    {
        public UserEvent() { }
        public UserEvent(IEnumerable<Event> list) : base(list) { }
        public UserEvent(IEnumerable<BaseEntity> list) : base(list.Cast<Event>().ToList()) { }
    }

}
