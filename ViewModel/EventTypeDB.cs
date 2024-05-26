using Model;
using System.Windows.Media;
using static Model.EventType;
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
            BrushConverter brushConverter = new BrushConverter();
            eventType.ColorShade = ((SolidColorBrush)brushConverter.ConvertFrom(reader["colorShade"].ToString())).Color;
            char act = reader["arithmeticAct"].ToString()[0];
            switch (act)
            {
                case 'A':
                    eventType.Act = ArithmeticAct.ADD; break;
                case 'S':
                    eventType.Act = ArithmeticAct.SUBTRACT; break;
                case 'N':
                    eventType.Act = ArithmeticAct.NONE; break;
            }
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
        protected override void LoadParameters(BaseEntity entity)
        {
            EventType eventType = entity as EventType;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@type", eventType.Type);
            command.Parameters.AddWithValue("@id", eventType.ID);
        }
        public int Insert(EventType eventType)
        {
            command.CommandText = "INSERT INTO tableEventType (type) VALUES (@type)";
            LoadParameters(eventType);
            return ExecuteCRUD();
        }
        public int Update(EventType eventType)
        {
            command.CommandText = "UPDATE tableEventType SET type = @type WHERE id = @id";
            LoadParameters(eventType);
            return ExecuteCRUD();
        }
        public int Delete(EventType eventType)
        {
            command.CommandText = $"DELETE FROM tableEventType WHERE id = {eventType.ID}";
            return ExecuteCRUD();
        }
    }
}
