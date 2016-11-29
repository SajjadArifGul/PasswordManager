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
        Database db = new Database();

        public bool Register(User user)
        {
            return db.AddUser(user);
        }
    }
}
