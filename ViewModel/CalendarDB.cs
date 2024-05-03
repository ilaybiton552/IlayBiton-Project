using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

            BrushConverter brushConverter = new BrushConverter();
            calendar.BaseColor = ((SolidColorBrush)brushConverter.ConvertFrom(reader["baseColor"].ToString())).Color;

            UserDB userDB = new UserDB();
            calendar.Creator = userDB.SelectById(int.Parse(reader["creator"].ToString()));

            calendar.Users = new UserList();
            calendar.Events = new EventList();

            return calendar;
        }

        public CalendarList SelectAll()
        {
            command.CommandText = "SELECT * FROM tableCalendars";
            return new CalendarList(ExecuteCommand());
        }

        public Calendar SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tableCalendars WHERE id=" + id.ToString();
            CalendarList list = new CalendarList(ExecuteCommand());
            if (list.Count == 0) return null;
            return list[0];
        }

        public Calendar SelectByName(string name)
        {
            command.CommandText = $"SELECT * FROM tableCalendars WHERE calednarName = '{name}'";
            CalendarList list = new CalendarList(ExecuteCommand());
            if (list.Count == 0) return null;
            return list[0];
        }

        public CalendarList SelectByUserId(int id)
        {
            command.CommandText = $"SELECT * FROM (tableCalendars INNER JOIN tableUserCalendars ON tableCalendars.id = tableUserCalendars.calendarId) WHERE userId = {id}";
            return new CalendarList(ExecuteCommand());
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Calendar calendar = entity as Calendar;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@calendarName", calendar.CalendarName);
            command.Parameters.AddWithValue("@creator", calendar.Creator.ID);
            command.Parameters.AddWithValue("@data", calendar.Data);
            command.Parameters.AddWithValue("@baseColor", calendar.BaseColor.ToString());
            command.Parameters.AddWithValue("@id", calendar.ID);
        }


        public int Insert(Calendar calendar)
        {
            command.CommandText = "INSERT INTO tableCalendars (calendarName, creator, data, baseColor) VALUES (@calendarName, @creator, @data, @baseColor)";
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
            command.CommandText = "UPDATE tableCalendars SET calendarName = @calendarName, creator = @creator, data = @data, baseColor = @baseColor WHERE id = @id";
            LoadParameters(calendar);
            return ExecuteCRUD();
        }

        public int Delete(Calendar calendar)
        {
            command.CommandText = $"DELETE FROM tableCalendars WHERE id = {calendar.ID}";
            return ExecuteCRUD();
        }

        public int DeleteUser(Calendar calendar, User user)
        {
            command.CommandText = $"DELETE FROM tableUserCalendars WHERE calendarId = {calendar.ID} AND userId = {user.ID}";
            return ExecuteCRUD();
        }

        public bool IsNameTaken(Calendar calendar) 
        {
            command.CommandText = $"SELECT * FROM tableCalendars WHERE calendarName = '{calendar.CalendarName}'";
            CalendarList list = new CalendarList(ExecuteCommand());
            return list.Count != 0;
        }
    }
}
