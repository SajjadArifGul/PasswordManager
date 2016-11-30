using PasswordManager.DAL;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BLL
{
    public class Users
    {
        Database db = Database.Instance();

        public bool Register(User user)
        {
            return db.AddUser(user);
        }

        public User Exist(User user)
        {
            return db.FindUser(user);
        }
    }
}
