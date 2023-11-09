using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected int creator;
        public int Creator
        {
            get { return creator; }
            set { creator = value; }
        }
    }

    public class UserCalendar : List<Calendar>
    {
        public UserCalendar() { }
        public UserCalendar(IEnumerable<Calendar> list) : base(list) { }
        public UserCalendar(IEnumerable<BaseEntity> list) : base(list.Cast<Calendar>().ToList()) { }
    }

}
