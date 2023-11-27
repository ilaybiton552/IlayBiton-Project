using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class CalendarService : ICalendarService
    {
        public int DeleteCalendar(Calendar calendar)
        {
            CalendarDB calendarDB = new CalendarDB();
            return calendarDB.Delete(calendar);
        }

        public int DeleteEvent(Event _event)
        {
            EventDB eventDB = new EventDB();
            return eventDB.Delete(_event);
        }

        public int DeleteEventType(EventType eventType)
        {
            EventTypeDB eventTypeDB = new EventTypeDB();
            return eventTypeDB.Delete(eventType);
        }

        public int DeleteUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Delete(user);
        }

        public CalendarList GetAllCalendars()
        {
            CalendarDB calendarDB = new CalendarDB();
            return calendarDB.SelectAll();
        }

        public EventList GetAllEvents()
        {
            EventDB eventDB = new EventDB();
            return eventDB.SelectAll();
        }

        public EventTypeList GetAllEventTypes()
        {
            EventTypeDB eventTypeDB = new EventTypeDB();
            return eventTypeDB.SelectAll();
        }

        public UserList GetAllUsers()
        {
            UserDB userDB = new UserDB();
            return userDB.SelectAll();
        }

        public int InsertCalendar(Calendar calendar)
        {
            CalendarDB calendarDB = new CalendarDB();
            return calendarDB.Insert(calendar);
        }

        public int InsertEvent(Event _event)
        {
            EventDB eventDB = new EventDB();
            return eventDB.Insert(_event);
        }

        public int InsertEventType(EventType eventType)
        {
            EventTypeDB eventTypeDB = new EventTypeDB();
            return eventTypeDB.Insert(eventType);
        }

        public int InsertUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Insert(user);
        }

        public User Login(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Login(user);
        }

        public int UpdateCalendar(Calendar calendar)
        {
            CalendarDB calendarDB = new CalendarDB();
            return calendarDB.Update(calendar);
        }

        public int UpdateEvent(Event _event)
        {
            EventDB eventDB = new EventDB();
            return eventDB.Update(_event);
        }

        public int UpdateEventType(EventType eventType)
        {
            EventTypeDB eventTypeDB = new EventTypeDB();
            return eventTypeDB.Update(eventType);
        }

        public int UpdateUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Update(user);
        }
    }
}
