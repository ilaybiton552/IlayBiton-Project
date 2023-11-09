using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EventType : BaseEntity
    {
        protected string type;
        public string Type 
        { 
            get { return type; } 
            set { type = value; } 
        }
    }

    public class UserEventType : List<EventType>
    {
        public UserEventType() { }
        public UserEventType(IEnumerable<EventType> list) : base(list) { }
        public UserEventType(IEnumerable<BaseEntity> list) : base(list.Cast<EventType>().ToList()) { }
    }

}
