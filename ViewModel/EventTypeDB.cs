using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EventTypeDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new EventType();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            EventType eventType = entity as EventType;
            eventType.ID = int.Parse(reader["id"].ToString());
            eventType.Type = reader["type"].ToString();
            return eventType;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tableEventType";
            return new UserList(ExecuteCommand());
        }

        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tableEventType WHERE id=" + id.ToString();
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0) return null;
            return list[0];
        }
    }
}
