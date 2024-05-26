using System.Runtime.Serialization;
namespace Model
{
    [DataContract(IsReference = true)]
    public class BaseEntity
    {
        private int id;
        [DataMember]
        public int ID { get { return id; } set { id = value; } }
    }
}
