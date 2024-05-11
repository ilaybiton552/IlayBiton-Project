using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static Model.User;

namespace Model
{
    [DataContract(IsReference = true)]
    public class Event : BaseEntity
    {
        protected string eventName;
        [DataMember]
        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }

        protected User creator;
        [DataMember]
        public User Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        protected EventType eventType;
        [DataMember]
        public EventType EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        protected bool isDone;
        [DataMember]
        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }

        protected DateTime startDate;
        [DataMember]
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        protected DateTime dueDate;
        [DataMember]
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        protected string data;
        [DataMember]
        public string Data
        {
            get { return data; }
            set {  data = value; }
        }

        protected Calendar calendar;
        [DataMember]
        public Calendar Calendar
        {
            get { return calendar; }
            set { calendar = value; }
        }

        protected Color eventBackground;
        [DataMember]
        public Color EventBackground
        {
            get { return eventBackground; }
            set { eventBackground = value; }
        }
    }

    [CollectionDataContract]
    public class EventList : List<Event>
    {
        public EventList() { }
        public EventList(IEnumerable<Event> list) : base(list) { }
        public EventList(IEnumerable<BaseEntity> list) : base(list.Cast<Event>().ToList()) { }
    }

}
