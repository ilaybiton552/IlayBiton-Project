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
    }
}
