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

        public EventTypeList SelectAll()
        {
            command.CommandText = "SELECT * FROM tableEventType";
            return new EventTypeList(ExecuteCommand());
        }

        public EventType SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tableEventType WHERE id=" + id.ToString();
            EventTypeList list = new EventTypeList(ExecuteCommand());
            if (list.Count == 0) return null;
            return list[0];
        }
    }
}
