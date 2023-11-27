using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            UserDB userDB = new UserDB();
            _event.Creator = userDB.SelectById(int.Parse(reader["creator"].ToString()));
            _event.Users = userDB.SelectByEventId(_event.ID);

            EventTypeDB eventTypeDB = new EventTypeDB();
            _event.EventType = eventTypeDB.SelectById(int.Parse(reader["eventType"].ToString()));

            if (_event.EventType.Type == "Task") // if task - has special field
            {
                _event.IsDone = bool.Parse(reader["isDone"].ToString());
            }
            
            _event.StartDate = DateTime.Parse(reader["startDate"].ToString());
            _event.DueDate = DateTime.Parse(reader["dueDate"].ToString());
            _event.StartTime = DateTime.Parse(reader["startTime"].ToString());
            _event.EndTime = DateTime.Parse(reader["endTime"].ToString());
            _event.DisplayColor = reader["displayColor"].ToString();

            return _event;
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
            command.CommandText = $"SELECT * FROM (tableEvents INNER JOIN tableCalendarEvents ON tableEvents.id = tableCalendarEvents.eventId) WHERE calendarId = {id}";
            return new EventList(ExecuteCommand());
        }

        public EventList SelectByUserId(int id)
        {
            command.CommandText = $"SELECT * FROM (tableEvents INNER JOIN tableUserEvents ON tableEvents.id = tableUserEvents.eventId) WHERE userId = {id}";
            return new EventList(ExecuteCommand());
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Event _event = entity as Event;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", _event.ID);
            command.Parameters.AddWithValue("@eventName", _event.EventName);
            command.Parameters.AddWithValue("@creator", _event.Creator.ID);
            command.Parameters.AddWithValue("@eventType", _event.EventType.ID);
            if (_event.EventType.Type == "Task")
            {
                command.Parameters.AddWithValue("@isDone", _event.IsDone);
            }
            command.Parameters.AddWithValue("@startDate", _event.StartDate);
            command.Parameters.AddWithValue("@dueDate", _event.DueDate);
            command.Parameters.AddWithValue("@startTime", _event.StartTime);
            command.Parameters.AddWithValue("@endTime", _event.EndTime);
            command.Parameters.AddWithValue("@displayColor", _event.DisplayColor);
        }

        public int Insert(Event _event)
        {
            if (_event.EventType.Type == "Task")
            {
                command.CommandText = "INSERT INTO tableEvents (eventName, creator, eventType, isDone, startDate, dueDate, startTime, endTime, displayColor) VALUES (@eventName, @creator, @eventType, @isDone, @startDate, @dueDate, @startTime, @endTime, @displayColor)";
            }
            else
            {
                command.CommandText = "INSERT INTO tableEvents (eventName, creator, eventType, startDate, dueDate, startTime, endTime, displayColor) VALUES (@eventName, @creator, @eventType, @startDate, @dueDate, @startTime, @endTime, @displayColor)";
            }
            LoadParameters(_event);
            return ExecuteCRUD();
        }

        public int Update(Event _event)
        {
            if (_event.EventType.Type == "Task")
            {
                command.CommandText = "UPDATE tableEvents SET eventName = @eventName, creator = @creator, eventType = @eventType, isDone = @isDone, startDate = @startDate, dueDate = @dueDate, startTime = @startTime, endTime = @endTime, displayColor = @displayColor WHERE id = @id";
            }
            else
            {
                command.CommandText = "UPDATE tableEvents SET eventName = @eventName, creator = @creator, eventType = @eventType, isDone = @isDone, startDate = @startDate, dueDate = @dueDate, startTime = @startTime, endTime = @endTime, displayColor = @displayColor WHERE id = @id";
            }
            LoadParameters(_event);
            return ExecuteCRUD();
        }

        public int Delete(Event _event)
        {
            command.CommandText = "DELETE FROM tableEvents WHERE id = @id";
            LoadParameters(_event);
            return ExecuteCRUD();
        }

    }
}
