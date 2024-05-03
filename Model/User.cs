using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract(IsReference = true)]
    public class User : BaseEntity
    {
        protected string firstName;
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        protected string lastName;
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        protected string email;
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        protected string username;
        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        protected string password;
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        protected string phoneNumber;
        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        protected bool isAdmin;
        [DataMember]
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        protected DateTime birthday;
        [DataMember]
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        protected CalendarList calendars;
        [DataMember]
        public CalendarList Calendars
        {
            get { return calendars; }
            set { calendars = value; }
        }

        protected EventList events;
        [DataMember]
        public EventList Events
        {
            get { return events; }
            set { events = value; }
        }
    }

    [CollectionDataContract]
    public class UserList : List<User>
    {
        public UserList() { }
        public UserList(IEnumerable<User> list) : base(list) { }
        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { }
    }

}
