using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Calendar = Model.Calendar;

namespace ViewModel
{
    public class EventDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Event();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Event _event = entity as Event;
            _event.ID = int.Parse(reader["id"].ToString());
            _event.EventName = reader["eventName"].ToString();

            EventTypeDB eventTypeDB = new EventTypeDB();
            _event.EventType = eventTypeDB.SelectById(int.Parse(reader["eventType"].ToString()));

            if (_event.EventType.Type == "Task") // if task - has special field
            {
                _event.IsDone = bool.Parse(reader["isDone"].ToString());
            }

            UserDB userDB = new UserDB();
            _event.Creator = userDB.SelectById(int.Parse(reader["creator"].ToString()));

            CalendarDB calendarDB = new CalendarDB();
            _event.Calendar = calendarDB.SelectById(int.Parse(reader["calendar"].ToString()));

            _event.EventBackground = GetEventBackground(_event);
            _event.StartDate = DateTime.Parse(reader["startDate"].ToString());
            _event.DueDate = DateTime.Parse(reader["dueDate"].ToString());
            _event.Data = reader["data"].ToString();

            return _event;
        }

        private Color GetEventBackground(Event _event)
        {
            Color first = _event.Calendar.BaseColor;
            Color second = _event.EventType.ColorShade;
            switch (_event.EventType.Act)
            {
                case EventType.ArithmeticAct.ADD:
                    return Color.FromRgb((byte)Math.Min(255, first.R + second.R),
                                                             (byte)Math.Min(255, first.G + second.G),
                                                             (byte)Math.Min(255, first.B + second.B));
                case EventType.ArithmeticAct.SUBTRACT:
                    return Color.FromRgb((byte)Math.Max(0, first.R - second.R),
                                                             (byte)Math.Max(0, first.G - second.G),
                                                             (byte)Math.Max(0, first.B - second.B));
            }
            return first;
        }

        public EventList SelectAll()
        {
            command.CommandText = "SELECT * FROM tableEvents";
            return new EventList(ExecuteCommand());
        }

        public Event SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tableEvents WHERE id=" + id.ToString();
            EventList list = new EventList(ExecuteCommand());
            if (list.Count == 0) return null;
            return list[0];
        }

        public EventList SelectByCalendarId(int id)
        {
            command.CommandText = $"SELECT * FROM tableEvents WHERE calendar = {id}";
            return new EventList(ExecuteCommand());
        }

        public EventList SelectByUserId(int id)
        {
            command.CommandText = $"SELECT tableEvents.* FROM ((tableEvents INNER JOIN tableCalendars ON tableEvents.calendar = tableCalendars.id) INNER JOIN tableUserCalendars ON tableCalendars.id = tableUserCalendars.calendarId) WHERE userId = {id}";
            return new EventList(ExecuteCommand());
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Event _event = entity as Event;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@eventName", _event.EventName);
            command.Parameters.AddWithValue("@creator", _event.Creator.ID);
            command.Parameters.AddWithValue("@eventType", _event.EventType.ID);
            if (_event.EventType.Type == "Task")
            {
                command.Parameters.AddWithValue("@isDone", _event.IsDone);
            }
            else
            {
                command.Parameters.AddWithValue("@isDone", false);
            }
            command.Parameters.AddWithValue("@data", _event.Data);
            command.Parameters.AddWithValue("@calendar", _event.Calendar.ID);
            command.Parameters.AddWithValue("@id", _event.ID);
        }

        public int Insert(Event _event)
        {
            command.CommandText = $"INSERT INTO tableEvents (eventName, creator, eventType, isDone, startDate, dueDate, data, calendar) VALUES (@eventName, @creator, @eventType, @isDone, '{_event.StartDate}', '{_event.DueDate}', @data, @calendar)";
            LoadParameters(_event);
            return ExecuteCRUD();
        }

        public int Update(ref Event _event)
        {
            command.CommandText = $"UPDATE tableEvents SET eventName = @eventName, creator = @creator, eventType = @eventType, isDone = @isDone, startDate = '{_event.StartDate}', dueDate = '{_event.DueDate}', data = @data, calendar = @calendar WHERE id = @id";
            _event.EventBackground = GetEventBackground(_event);
            LoadParameters(_event);
            return ExecuteCRUD();
        }

        public int Delete(Event _event)
        {
            command.CommandText = $"DELETE FROM tableEvents WHERE id = {_event.ID}";
            return ExecuteCRUD();
        }

        public int DeleteByEventType(EventType eventType)
        {
            command.CommandText = $"DELETE FROM tableEvents WHERE eventType = {eventType.ID}";
            return ExecuteCRUD();
        }

        public int DeleteByCalendar(Calendar calendar)
        {
            command.CommandText = $"DELETE FROM tableEvents WHERE calendar = {calendar.ID}";
            return ExecuteCRUD();
        }

        public int DeleteByUser(User user) 
        {
            command.CommandText = $"DELETE FROM tableEvents WHERE creator = {user.ID}";
            return ExecuteCRUD();
        }

    }
}
