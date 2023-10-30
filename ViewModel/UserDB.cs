using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = int.Parse(reader["id"].ToString());
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.Email = reader["email"].ToString();
            user.Username = reader["username"].ToString();
            user.Password = reader["password"].ToString();
            user.PhoneNumber = reader["phoneNumber"].ToString();
            user.IsAdmin = bool.Parse(reader["isAdmin"].ToString());
            user.Birthday = DateTime.Parse(reader["birthday"].ToString());
            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tableUsers";
            return new UserList(ExecuteCommand());
        }

        public User SelectById(int id) 
        {
            command.CommandText = "SELECT * FROM tableUsers WHERE id=" + id.ToString();
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0) return null;
            return list[0];
        }

    }
}
