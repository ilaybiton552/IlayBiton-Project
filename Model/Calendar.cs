using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static Model.User;

namespace Model
{
    [DataContract]
    public class Calendar : BaseEntity
    {
        protected string calendarName;
        [DataMember]
        public string CalendarName 
        { 
            get { return calendarName; } 
            set { calendarName = value; } 
        }

        protected User creator;
        [DataMember]
        public User Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        protected string data;
        [DataMember]
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        protected Color baseColor;
        [DataMember]
        public Color BaseColor
        {
            get { return baseColor; }
            set { baseColor = value; }
        }

        protected EventList events;
        [DataMember]
        public EventList Events
        {
            get { return events; }
            set { events = value; }
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
    public class CalendarList : List<Calendar>
    {
        public CalendarList() { }
        public CalendarList(IEnumerable<Calendar> list) : base(list) { }
        public CalendarList(IEnumerable<BaseEntity> list) : base(list.Cast<Calendar>().ToList()) { }
    }

}
