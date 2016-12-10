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
        Database db;

        public Users()
        {
            db = Database.Instance();
        }

        public bool Register(User user)
        {
            return db.AddUser(user);
        }

        public User Exist(User user)
        {
            return db.FindUser(user);
        }

        public User Update(User user)
        {
            return user;
        }

        public bool Delete(User user)
        {
            return true;
        }
    }
}
