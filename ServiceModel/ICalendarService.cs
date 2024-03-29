﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ServiceModel
{
    [ServiceContract]
    public interface ICalendarService
    {
        // UserDB
        [OperationContract] UserList GetAllUsers();
        [OperationContract] User Login(User user);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] bool IsUsenameTaken(User user);
        [OperationContract] bool IsEmailTaken(User user);
        [OperationContract] User GetUser(User user);
        [OperationContract] UserList GetCalendarUsers(Calendar calendar);
        [OperationContract] UserList GetEventUsers(Event _event);

        // EventTypeDB
        [OperationContract] EventTypeList GetAllEventTypes();
        [OperationContract] int InsertEventType(EventType eventType);
        [OperationContract] int UpdateEventType(EventType eventType);
        [OperationContract] int DeleteEventType(EventType eventType);

        // EventDB
        [OperationContract] EventList GetAllEvents();
        [OperationContract] int InsertEvent(Event _event);
        [OperationContract] int UpdateEvent(Event _event);
        [OperationContract] int DeleteEvent(Event _event);
        [OperationContract] EventList GetUserEvents(User user);
        [OperationContract] EventList GetCalendarEvents(Calendar calendar);

        // CalendarDB
        [OperationContract] CalendarList GetAllCalendars();
        [OperationContract] int InsertCalendar(Calendar calendar);
        [OperationContract] int UpdateCalendar(Calendar calendar);
        [OperationContract] int DeleteCalendar(Calendar calendar);
        [OperationContract] CalendarList GetUserCalendars(User user);

    }
}
