using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CalendarDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Calendar();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Calendar calendar = entity as Calendar;

            calendar.ID = int.Parse(reader["id"].ToString());
            calendar.CalendarName = reader["calendarName"].ToString();
            calendar.Data = reader["data"].ToString();
            calendar.Users = new UserList();
            calendar.Events = new EventList();

            return calendar;
        }

        public CalendarList SelectAll()
        {
            command.CommandText = "SELECT * FROM tableCalendar";
            return new CalendarList(ExecuteCommand());
        }

        public Calendar SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tableCalendar WHERE id=" + id.ToString();
            CalendarList list = new CalendarList(ExecuteCommand());
            if (list.Count == 0) return null;
            return list[0];
        }

        public CalendarList SelectByUserId(int id)
        {
            command.CommandText = $"SELECT * FROM (tableCalendar INNER JOIN tableUserCalendars ON tableCalendar.id = tableUserCalendars.calendarId) WHERE userId = {id}";
            return new CalendarList(ExecuteCommand());
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Calendar calendar = entity as Calendar;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@calendarName", calendar.CalendarName);
            command.Parameters.AddWithValue("@creator", calendar.Creator.ID);
            command.Parameters.AddWithValue("@data", calendar.Data);
            command.Parameters.AddWithValue("@id", calendar.ID);
        }


        public int Insert(Calendar calendar)
        {
            command.CommandText = "INSERT INTO tableCalendar (calendarName, creator, data) VALUES (@calendarName, @creator, @data)";
            LoadParameters(calendar);
            return ExecuteCRUD();
        }

        public int InsertUserToCalendar(Calendar calendar, User user) 
        {
            command.CommandText = $"INSERT INTO tableUserCalendars (userId, calendarId) VALUES ({user.ID}, {calendar.ID})";
            return ExecuteCRUD();
        }

        public int Update(Calendar calendar)
        {
            command.CommandText = "UPDATE tableCalendar SET calendarName = @calendarName, creator = @creator, data = @data WHERE id = @id";
            LoadParameters(calendar);
            return ExecuteCRUD();
        }

        public int Delete(Calendar calendar)
        {
            command.CommandText = $"DELETE FROM tableCalendar WHERE id = {calendar.ID}";
            return ExecuteCRUD();
        }

    }
}
