using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Database
{
    /// <summary>
    /// Provides Access to Passwords Table.
    /// </summary>
    public class Passwords
    {
        private string ConnectionString;

        public Passwords()
        {
            //ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PasswordManagerDBConnection"].ConnectionString;
            ConnectionString = Properties.Settings.Default["PasswordManagerDBConnection"].ToString();
        }

        /// <summary>
        /// Inserts Password for given User. 
        /// </summary>
        /// <param name="password">Password entity to be saved.</param>
        /// <param name="user">User entity to save password for.</param>
        /// <returns></returns>
        public bool Insert(Password password, User user)
        {
            int AffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Insert into Passwords (UserID, Name, Email, Username, Website, Text, Notes, DateCreated, DateModified) values (@UserID, @Name, @Email, @Username, @Website, @Text, @Notes, @DateCreated, @DateModified)", connection))
                {
                    command.Parameters.Add(new SqlParameter("UserID", user.ID));
                    command.Parameters.Add(new SqlParameter("Name", password.Name));
                    command.Parameters.Add(new SqlParameter("Email", password.Email));
                    command.Parameters.Add(new SqlParameter("Username", password.Username));
                    command.Parameters.Add(new SqlParameter("Website", password.Website));
                    command.Parameters.Add(new SqlParameter("Text", password.Text));
                    command.Parameters.Add(new SqlParameter("Notes", password.Notes));
                    command.Parameters.Add(new SqlParameter("DateCreated", password.DateCreated));
                    command.Parameters.Add(new SqlParameter("DateModified", password.DateModified));

                    connection.Open();

                    AffectedRows = command.ExecuteNonQuery();
                }
            }

            if (AffectedRows > 0)
                return true;
            else return false;
        }
        
        /// <summary>
        /// Returns Passwords for given User.
        /// </summary>
        /// <param name="userID">User ID to look for.</param>
        /// <returns>List of Passwords for User.</returns>
        public List<Password> Select(int userID)
        {
            List<Password> passwords = new List<Password>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Select * from Passwords where UserID = @UserID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", userID));

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    Password password = new Password();

                    while (reader.Read())
                    {
                        password.ID = Convert.ToInt32(reader["ID"]);
                        password.UserID = userID;
                        password.Name = reader["Name"].ToString();
                        password.Email = reader["Email"].ToString();
                        password.Username = reader["Username"].ToString();
                        password.Website = reader["Website"].ToString();
                        password.Text = reader["Text"].ToString();
                        password.Notes = reader["Notes"].ToString();
                        password.DateCreated = Convert.ToDateTime(reader["DateCreated"].ToString());
                        password.DateModified = Convert.ToDateTime(reader["DateModified"].ToString());

                        passwords.Add(password);
                    }
                }
            }

            return passwords;
        }

        /// <summary>
        /// Returns Passwords for given User.
        /// </summary>
        /// <param name="user">User Entity to look for.</param>
        /// <returns>List of Passwords for User.</returns>
        public List<Password> Select(User user)
        {
            List<Password> passwords = new List<Password>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Select * from Passwords where UserID = @UserID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", user.ID));

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Password password = new Password();

                        password.ID = Convert.ToInt32(reader["ID"]);
                        password.UserID = user.ID;
                        password.Name = reader["Name"].ToString();
                        password.Email = reader["Email"].ToString();
                        password.Username = reader["Username"].ToString();
                        password.Website = reader["Website"].ToString();
                        password.Text = reader["Text"].ToString();
                        password.Notes = reader["Notes"].ToString();
                        password.DateCreated = Convert.ToDateTime(reader["DateCreated"].ToString());
                        password.DateModified = Convert.ToDateTime(reader["DateModified"].ToString());

                        passwords.Add(password);
                    }
                }
            }

            return passwords;
        }

        /// <summary>
        /// Updates the given password.
        /// </summary>
        /// <param name="password">Password Entity to be updated.</param>
        /// <returns>True if updated otherwise false.</returns>
        public bool Update(Password password)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Update Passwords set Name= @Name, @Email=@Email, Username= @Username, Website= @Website, Text= @Text, Notes= @Notes, DateCreated= @DateCreated, DateModified= @DateModified where ID = @ID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID", password.ID));
                    command.Parameters.Add(new SqlParameter("@Name", password.Name));
                    command.Parameters.Add(new SqlParameter("@Email", password.Email));
                    command.Parameters.Add(new SqlParameter("@Username", password.Username));
                    command.Parameters.Add(new SqlParameter("@Website", password.Website));
                    command.Parameters.Add(new SqlParameter("@Text", password.Text));
                    command.Parameters.Add(new SqlParameter("@Notes", password.Notes));
                    command.Parameters.Add(new SqlParameter("@DateCreated", password.DateCreated));
                    command.Parameters.Add(new SqlParameter("@DateModified", password.DateModified));

                    connection.Open();

                    AffectedRows = command.ExecuteNonQuery();
                }
            }
            if (AffectedRows > 0) return true;
            else return false;
        }
    }
}
