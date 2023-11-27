using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.User;

namespace Model
{
    public class Calendar : BaseEntity
    {
        protected string calendarName;
        public string CalendarName 
        { 
            get { return calendarName; } 
            set { calendarName = value; } 
        }

        protected User creator;
        public User Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        protected EventList events;
        public EventList Events
        {
            get { return events; }
            set { events = value; }
        }

        protected UserList users;
        public UserList Users
        {
            get { return users; }
            set { users = value; }
        }
    }

    public class CalendarList : List<Calendar>
    {
        public CalendarList() { }
        public CalendarList(IEnumerable<Calendar> list) : base(list) { }
        public CalendarList(IEnumerable<BaseEntity> list) : base(list.Cast<Calendar>().ToList()) { }
    }

}
