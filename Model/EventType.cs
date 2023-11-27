using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class EventType : BaseEntity
    {
        protected string type;
        [DataMember]
        public string Type 
        { 
            get { return type; } 
            set { type = value; } 
        }
    }

    [CollectionDataContract]
    public class EventTypeList : List<EventType>
    {
        public EventTypeList() { }
        public EventTypeList(IEnumerable<EventType> list) : base(list) { }
        public EventTypeList(IEnumerable<BaseEntity> list) : base(list.Cast<EventType>().ToList()) { }
    }

}
