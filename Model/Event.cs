using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Model.User;

namespace Model
{
    [DataContract]
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
            get { return EventType; }
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

        protected DateTime startTime;
        [DataMember]
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        protected DateTime endTime;
        [DataMember]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        protected string displayColor;
        [DataMember]
        public string DisplayColor
        {
            get { return displayColor; }
            set { displayColor = value; }
        }

        protected UserList users;
        [DataMember]
        public UserList Users
        {
            get { return users; }
            set { users = value; }
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
