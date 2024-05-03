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

        public EventList GetCalendarEvents(Calendar calendar)
        {
            EventDB eventDB = new EventDB();
            return eventDB.SelectByCalendarId(calendar.ID);
        }

        public User GetUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.SelectById(user.ID);
        }

        public CalendarList GetUserCalendars(User user)
        {
            CalendarDB calendarDB = new CalendarDB();
            return calendarDB.SelectByUserId(user.ID);
        }

        public EventList GetUserEvents(User user)
        {
            EventDB eventDB = new EventDB();
            return eventDB.SelectByUserId(user.ID);
        }

        public UserList GetCalendarUsers(Calendar calendar)
        {
            UserDB userDB = new UserDB();
            return userDB.SelectByCalendarId(calendar.ID);
        }

        public UserList GetEventUsers(Event _event)
        {
            UserDB userDB = new UserDB();
            return userDB.SelectByEventId(_event.ID);
        }

        public int InsertCalendar(Calendar calendar)
        {
            int affectedRows = 0;
            CalendarDB calendarDB = new CalendarDB();
            UserList calUsers = calendar.Users;
            affectedRows += calendarDB.Insert(calendar);
            // last calendar is the now added calendar
            calendar = calendarDB.SelectByName(calendar.CalendarName);
            foreach (User user in calUsers)
            {
                affectedRows += calendarDB.InsertUserToCalendar(calendar, user);
            }
            return affectedRows;
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
            if (userDB.Insert(user) != 1) // error creating user
            {
                return -1;
            }
            return Login(user).ID;
        }

        public bool IsEmailTaken(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.IsEmailTaken(user);
        }

        public bool IsUsenameTaken(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.IsUsernameTaken(user);
        }

        public User Login(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Login(user);
        }

        public int UpdateCalendar(Calendar calendar)
        {
            CalendarDB calendarDB = new CalendarDB();
            UserList usersBeforeUpdate = GetCalendarUsers(calendarDB.SelectById(calendar.ID));
            foreach (User user in usersBeforeUpdate) 
            {
                // removed user from calendar
                if (calendar.Users.Where(usr=>usr.ID == user.ID).ToList().Count == 0)
                {
                    calendarDB.DeleteUser(calendar, user);
                }
            }
            foreach (User user in calendar.Users)
            {
                // added user to calendar
                if (usersBeforeUpdate.Where(usr=>usr.ID == user.ID).ToList().Count == 0)
                {
                    calendarDB.InsertUserToCalendar(calendar, user);
                }
            }
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

        public bool IsCalendarNameTaken(Calendar calendar)
        {
            CalendarDB calendarDB = new CalendarDB();
            return calendarDB.IsNameTaken(calendar);
        }
    }
}
