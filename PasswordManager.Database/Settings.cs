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
    /// Allows to access User Settings
    /// </summary>
    public class Settings
    {
        private string ConnectionString;

        public Settings()
        {
            //ConnectionString = ConfigurationManager.ConnectionStrings["PasswordManagerDBConnection"].ConnectionString;
            ConnectionString = Properties.Settings.Default["PasswordManagerDBConnection"].ToString();
        }
        
        public bool Insert(PasswordManager.Entities.Settings settings, User user)
        {
            int AffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Insert into Settings (UserID, DateTimeFormat, PasswordOptionsID, ShowEmailColumn, ShowUsernameColumn, ShowPasswordColumn) values (@UserID, @DateTimeFormat, @PasswordOptionsID, @ShowEmailColumn, @ShowUsernameColumn, @ShowPasswordColumn)", connection))
                {
                    command.Parameters.Add(new SqlParameter("UserID", user.ID));
                    command.Parameters.Add(new SqlParameter("DateTimeFormat", settings.DateTimeFormat));
                    command.Parameters.Add(new SqlParameter("PasswordOptionsID", settings.PasswordOptionsID));
                    command.Parameters.Add(new SqlParameter("ShowEmailColumn", settings.ShowEmailColumn));
                    command.Parameters.Add(new SqlParameter("ShowUsernameColumn", settings.ShowUsernameColumn));
                    command.Parameters.Add(new SqlParameter("ShowPasswordColumn", settings.ShowPasswordColumn));

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
        public PasswordManager.Entities.Settings Select(int userID)
        {
            PasswordManager.Entities.Settings settings = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Select * from Settings where UserID = @UserID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", userID));

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        settings = new PasswordManager.Entities.Settings();

                        settings.ID = Convert.ToInt32(reader["ID"]);
                        settings.UserID = userID;
                        settings.ShowEmailColumn = Convert.ToBoolean(reader["ShowEmailColumn"]);
                        settings.ShowUsernameColumn = Convert.ToBoolean(reader["ShowUsernameColumn"]);
                        settings.ShowPasswordColumn = Convert.ToBoolean(reader["ShowPasswordColumn"]);
                    }
                }
            }

            return settings;
        }

        /// <summary>
        /// Selects User from Database.
        /// </summary>
        /// <param name="userID">User ID to look for.</param>
        /// <returns>User Entity matching the given ID.</returns>
        public PasswordManager.Entities.Settings Select(User user)
        {
            PasswordManager.Entities.Settings settings = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Select * from Settings where UserID = @UserID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", user.ID));

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        settings = new PasswordManager.Entities.Settings();

                        settings.ID = Convert.ToInt32(reader["ID"]);
                        settings.UserID = user.ID;

                        //get passwordoptionsID related stuff here

                        settings.ShowEmailColumn = Convert.ToBoolean(reader["ShowEmailColumn"]);
                        settings.ShowUsernameColumn = Convert.ToBoolean(reader["ShowUsernameColumn"]);
                        settings.ShowPasswordColumn = Convert.ToBoolean(reader["ShowPasswordColumn"]);
                    }
                }
            }

            return settings;
        }

        /// <summary>
        /// Updates Selected User in Database.
        /// </summary>
        /// <param name="user">User Entity to be updated.</param>
        /// <returns>True if User is updated otherwise False.</returns>
        public bool Update(PasswordManager.Entities.Settings settings)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Update Settings set DateTimeFormat= @DateTimeFormat, ShowEmailColumn=@ShowEmailColumn, ShowUsernameColumn= @ShowUsernameColumn, ShowPasswordColumn = @ShowPasswordColumn where ID = @ID", connection))
                {
                    command.Parameters.Add(new SqlParameter("DateTimeFormat", settings.DateTimeFormat));
                    command.Parameters.Add(new SqlParameter("ShowEmailColumn", settings.ShowEmailColumn));
                    command.Parameters.Add(new SqlParameter("ShowUsernameColumn", settings.ShowUsernameColumn));
                    command.Parameters.Add(new SqlParameter("ShowPasswordColumn", settings.ShowPasswordColumn));

                    connection.Open();

                    AffectedRows = command.ExecuteNonQuery();
                }
            }
            if (AffectedRows > 0) return true;
            else return false;
        }
    }
}
