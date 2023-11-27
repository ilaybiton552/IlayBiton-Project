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
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Calendar calendar = entity as Calendar;
            calendar.ID = int.Parse(reader["id"].ToString());
            calendar.CalendarName = reader["calendarName"].ToString();

            UserDB userDB = new UserDB();
            calendar.Creator = userDB.SelectById(int.Parse(reader["creator"].ToString()));
            calendar.Users = userDB.SelectByCalendarId(calendar.ID);

            EventDB eventDB = new EventDB();
            calendar.Events = eventDB.SelectByCalendarId(calendar.ID);

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
            command.CommandText = $"SELECT * FROM (tableCalendar INNER JOIN tableUserCalendars ON tableCalendar.id = tableUserCalendars.calendarId) WHERE userID = {id}";
            return new CalendarList(ExecuteCommand());
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Calendar calendar = entity as Calendar;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", calendar.ID);
            command.Parameters.AddWithValue("@calendarName", calendar.CalendarName);
            command.Parameters.AddWithValue("@creator", calendar.Creator);
        }


        public int Insert(Calendar calendar)
        {
            command.CommandText = "INSERT INTO tableCalendar (calendarName, creator) VALUES (@calendarName, @creator)";
            LoadParameters(calendar);
            return ExecuteCRUD();
        }

        public int Update(Calendar calendar)
        {
            command.CommandText = "UPDATE tableCalendar SET calendarName = @calendarName, creator = @creator WHERE id = @id";
            LoadParameters(calendar);
            return ExecuteCRUD();
        }

        public int Delete(Calendar calendar)
        {
            command.CommandText = "DELETE FROM tableCalendar WHERE id = @id";
            LoadParameters(calendar);
            return ExecuteCRUD();
        }

    }
}
