using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event : BaseEntity
    {
        enum EnumEventType
        {
            Event=1,
            Task
        }
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
        //protected EnumEventType eventType;
        //public EnumEventType EventType
        //{
        //    get { return EventType; }
        //    set { eventType = value; }
        //}
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
}
