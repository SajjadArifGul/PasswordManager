using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Database
{
    /// <summary>
    /// Allows Access to Users Table Data
    /// </summary>
    public class Users
    {
        private string ConnectionString;

        public Users()
        {
            ConnectionString = Properties.Settings.Default["PasswordManagerDBConnection"].ToString();
        }

        /// <summary>
        /// Store New User into Database.
        /// </summary>
        /// <param name="user">User Entity to be saved.</param>
        /// <returns>True if User is stored otherwise False.</returns>
        public bool Insert(User user)
        {
            int AffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Insert into Users (Name, Username, Email, Master) values (@Name, @Username, @Email, @Master)", connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", user.Name));
                    command.Parameters.Add(new SqlParameter("Username", user.Username));
                    command.Parameters.Add(new SqlParameter("Email", user.Email));
                    command.Parameters.Add(new SqlParameter("Master", user.Master));

                    connection.Open();

                    AffectedRows = command.ExecuteNonQuery();
                }
            }

            if (AffectedRows > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// Selects User from Database.
        /// </summary>
        /// <param name="userID">User ID to look for.</param>
        /// <returns>User Entity matching the given ID.</returns>
        public User Select(int userID)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Select * from Users where ID = @ID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID", userID));

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    user = new User();

                    while (reader.Read())
                    {
                        user.ID = Convert.ToInt32(reader["ID"]);
                        user.Name = reader["Name"].ToString();
                        user.Username = reader["Username"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Master = reader["Master"].ToString();
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// Selects User from Database.
        /// </summary>
        /// <param name="user">User Entity to look for.</param>
        /// <returns>User Entity matching the given User's email.</returns>
        public User Select(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Select * from Users where Email = @Email", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Email", user.Email));

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    user = new User();

                    while (reader.Read())
                    {
                        user.ID = Convert.ToInt32(reader["ID"]);
                        user.Name = reader["Name"].ToString();
                        user.Username = reader["Username"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Master = reader["Master"].ToString();
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// Updates Selected User in Database.
        /// </summary>
        /// <param name="user">User Entity to be updated.</param>
        /// <returns>True if User is updated otherwise False.</returns>
        public bool Update(User user)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Update Users set Name= @Name, Username= @Username, @Email=@Email, Master= @Master where ID = @ID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID", user.ID));
                    command.Parameters.Add(new SqlParameter("@Name", user.Name));
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));
                    command.Parameters.Add(new SqlParameter("@Email", user.Email));
                    command.Parameters.Add(new SqlParameter("@Master", user.Master));

                    connection.Open();

                    AffectedRows = command.ExecuteNonQuery();
                }
            }
            if (AffectedRows > 0) return true;
            else return false;
        }
    }
}
