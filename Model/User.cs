using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        protected string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }
        protected string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }
        protected string email;
        public string Email { get { return email; } set { email = value; } }
        protected string username;
        public string Username { get { return username; } set { username = value; } }
        protected string password;
        public string Password { get { return password; } set { password = value; } }
        protected string phoneNumber;
        public string PhoneNumber { get {  return phoneNumber; } set {  phoneNumber = value; } }
        protected bool isAdmin;
        public bool IsAdmin { get {  return isAdmin; } set { IsAdmin = value; } }
        protected DateTime birthday;
        public DateTime Birthday { get {  return birthday; } set {  birthday = value; } }

    }

    public class UserList : List<User>
    {
        public UserList() { }
        public UserList(IEnumerable<User> list) : base(list) { }
        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { }
    }

}
