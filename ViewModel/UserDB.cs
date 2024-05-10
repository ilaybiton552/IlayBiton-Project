using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
            user.Calendars = new CalendarList();
            user.Events = new EventList();

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

        public UserList SelectByCalendarId(int id)
        {
            command.CommandText = $"SELECT * FROM (tableUsers INNER JOIN tableUserCalendars ON tableUsers.id = tableUserCalendars.userId) WHERE calendarId = {id}";
            return new UserList(ExecuteCommand());
        }

        public UserList SelectByEventId(int id)
        {
            command.CommandText = $"SELECT * FROM (tableUsers INNER JOIN tableUserCalendars ON tableUsers.id = tableUserCalendars.userId) WHERE eventId = {id}";
            return new UserList(ExecuteCommand());
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
            command.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
            command.Parameters.AddWithValue("@id", user.ID);
        }

        public int Insert(User user)
        {
            command.CommandText = $"INSERT INTO tableUsers (firstName, lastName, username, [password], email, isAdmin, birthday, phoneNumber) VALUES (@firstName, @lastName, @username, @password, @email, @isAdmin, '{user.Birthday.ToString("d")}', @phoneNumber)";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public int Update(User user)
        {
            command.CommandText = $"UPDATE tableUsers SET firstName = @firstName, lastName = @lastName, username = @username, [password] = @password, email = @email, birthday = '{user.Birthday.ToString("d")}', isAdmin = @isAdmin, phoneNumber = @phoneNumber WHERE id = @id";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public int Delete(User user)
        {
            command.CommandText = $"DELETE FROM tableUserCalendars WHERE userId = {user.ID}; DELETE FROM tableUsers WHERE id = {user.ID}";
            return ExecuteCRUD();
        }

        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM tableUsers WHERE username = '{user.Username}' AND [password] = '{user.Password}'";
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1) return list[0];
            return null;
        }

        public bool IsUsernameTaken(User user)
        {
            command.CommandText = $"SELECT * FROM tableUsers WHERE username = '{user.Username}'";
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0) return false;
            return true;
        }

        public bool IsEmailTaken(User user)
        {
            command.CommandText = $"SELECT * FROM tableUsers WHERE email = '{user.Email}'";
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0) return false;
            return true;
        }

    }
}
