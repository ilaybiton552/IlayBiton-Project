using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    [DataContract]
    public class EventType : BaseEntity
    {
        public enum ArithmeticAct { ADD, SUBTRACT, NONE }
        protected string type;
        [DataMember]
        public string Type 
        { 
            get { return type; } 
            set { type = value; } 
        }

        protected Color colorShade;
        [DataMember]
        public Color ColorShade
        {
            get { return colorShade; }
            set { colorShade = value; }
        }

        protected ArithmeticAct act;
        [DataMember]
        public ArithmeticAct Act
        {
            get { return act; }
            set { act = value; }
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
