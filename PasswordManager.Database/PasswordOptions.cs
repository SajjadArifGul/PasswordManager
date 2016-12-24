using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Database
{
    /// <summary>
    /// Provides Access to Password Options Table.
    /// </summary>
    public class PasswordOptions
    {
        private string ConnectionString;

        public PasswordOptions()
        {
            //ConnectionString = ConfigurationManager.ConnectionStrings["PasswordManagerDBConnection"].ConnectionString;
            ConnectionString = Properties.Settings.Default["PasswordManagerDBConnection"].ToString();
        }

        /// <summary>
        /// Store New User into Database.
        /// </summary>
        /// <param name="user">User Entity to be saved.</param>
        /// <returns>True if User is stored otherwise False.</returns>
        public bool Insert(PasswordManager.Entities.PasswordOptions passwordOptions, PasswordManager.Entities.Settings settings)
        {
            int AffectedRows = 0;

            string commandQuery = string.Empty;

            if (passwordOptions.AllowOtherCharacters || passwordOptions.RequireOtherCharacters)
            {
                commandQuery = @"Insert into PasswordOptions
                    (
                    SettingsID,
                    AllowLowercaseCharacters,
                    AllowUppercaseCharacters,
                    AllowNumberCharacters,
                    AllowSpecialCharacters,
                    AllowUnderscoreCharacters,
                    AllowSpaceCharacters,
                    AllowOtherCharacters,
                    RequireLowercaseCharacters,
                    RequireUppercaseCharacters,
                    RequireNumberCharacters,
                    RequireSpecialCharacters,
                    RequireUnderscoreCharacters,
                    RequireSpaceCharacters,
                    RequireOtherCharacters,
                    MinimumCharacters,
                    MaximumCharacters,
                    OtherCharacters
                    )
                        values
                    (
                    @SettingsID,
                    @AllowLowercaseCharacters,
                    @AllowUppercaseCharacters,
                    @AllowNumberCharacters,
                    @AllowSpecialCharacters,
                    @AllowUnderscoreCharacters,
                    @AllowSpaceCharacters,
                    @AllowOtherCharacters,
                    @RequireLowercaseCharacters,
                    @RequireUppercaseCharacters,
                    @RequireNumberCharacters,
                    @RequireSpecialCharacters,
                    @RequireUnderscoreCharacters,
                    @RequireSpaceCharacters,
                    @RequireOtherCharacters,
                    @MinimumCharacters,
                    @MaximumCharacters,
                    @OtherCharacters
                    )";
            }
            else
            {
                commandQuery = @"Insert into PasswordOptions
                    (
                    SettingsID,
                    AllowLowercaseCharacters,
                    AllowUppercaseCharacters,
                    AllowNumberCharacters,
                    AllowSpecialCharacters,
                    AllowUnderscoreCharacters,
                    AllowSpaceCharacters,
                    AllowOtherCharacters,
                    RequireLowercaseCharacters,
                    RequireUppercaseCharacters,
                    RequireNumberCharacters,
                    RequireSpecialCharacters,
                    RequireUnderscoreCharacters,
                    RequireSpaceCharacters,
                    RequireOtherCharacters,
                    MinimumCharacters,
                    MaximumCharacters
                    )
                        values
                    (
                    @SettingsID,
                    @AllowLowercaseCharacters,
                    @AllowUppercaseCharacters,
                    @AllowNumberCharacters,
                    @AllowSpecialCharacters,
                    @AllowUnderscoreCharacters,
                    @AllowSpaceCharacters,
                    @AllowOtherCharacters,
                    @RequireLowercaseCharacters,
                    @RequireUppercaseCharacters,
                    @RequireNumberCharacters,
                    @RequireSpecialCharacters,
                    @RequireUnderscoreCharacters,
                    @RequireSpaceCharacters,
                    @RequireOtherCharacters,
                    @MinimumCharacters,
                    @MaximumCharacters
                    )";
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandQuery, connection))
                {
                    command.Parameters.Add(new SqlParameter("SettingsID", settings.ID));
                    command.Parameters.Add(new SqlParameter("AllowLowercaseCharacters",     passwordOptions.AllowLowercaseCharacters));   
                    command.Parameters.Add(new SqlParameter("AllowUppercaseCharacters",     passwordOptions.AllowUppercaseCharacters));
                    command.Parameters.Add(new SqlParameter("AllowNumberCharacters",        passwordOptions.AllowNumberCharacters));
                    command.Parameters.Add(new SqlParameter("AllowSpecialCharacters",       passwordOptions.AllowSpecialCharacters));
                    command.Parameters.Add(new SqlParameter("AllowUnderscoreCharacters",    passwordOptions.AllowUnderscoreCharacters));
                    command.Parameters.Add(new SqlParameter("AllowSpaceCharacters",         passwordOptions.AllowSpaceCharacters));
                    command.Parameters.Add(new SqlParameter("AllowOtherCharacters",         passwordOptions.AllowOtherCharacters));
                    command.Parameters.Add(new SqlParameter("RequireLowercaseCharacters",   passwordOptions.RequireLowercaseCharacters));
                    command.Parameters.Add(new SqlParameter("RequireUppercaseCharacters",   passwordOptions.RequireUppercaseCharacters));
                    command.Parameters.Add(new SqlParameter("RequireNumberCharacters",      passwordOptions.RequireNumberCharacters));
                    command.Parameters.Add(new SqlParameter("RequireSpecialCharacters",     passwordOptions.RequireSpecialCharacters));
                    command.Parameters.Add(new SqlParameter("RequireUnderscoreCharacters",  passwordOptions.RequireUnderscoreCharacters));
                    command.Parameters.Add(new SqlParameter("RequireSpaceCharacters",       passwordOptions.RequireSpaceCharacters));
                    command.Parameters.Add(new SqlParameter("RequireOtherCharacters",       passwordOptions.RequireOtherCharacters));
                    command.Parameters.Add(new SqlParameter("MinimumCharacters",            passwordOptions.MinimumCharacters));
                    command.Parameters.Add(new SqlParameter("MaximumCharacters",            passwordOptions.MaximumCharacters));

                    if (passwordOptions.AllowOtherCharacters || passwordOptions.RequireOtherCharacters)
                    {
                        command.Parameters.Add(new SqlParameter("OtherCharacters", passwordOptions.OtherCharacters));
                    }
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
        public PasswordManager.Entities.PasswordOptions Select(PasswordManager.Entities.Settings settings)
        {
            PasswordManager.Entities.PasswordOptions passwordOptions = new Entities.PasswordOptions()
            {
                AllowLowercaseCharacters     = Globals.Defaults.AllowLowercaseCharacters     ,
                AllowUppercaseCharacters     = Globals.Defaults.AllowUppercaseCharacters     ,
                AllowNumberCharacters        = Globals.Defaults.AllowNumberCharacters        ,
                AllowSpecialCharacters       = Globals.Defaults.AllowSpecialCharacters       ,
                AllowUnderscoreCharacters    = Globals.Defaults.AllowUnderscoreCharacters    ,
                AllowSpaceCharacters         = Globals.Defaults.AllowSpaceCharacters         ,
                AllowOtherCharacters         = Globals.Defaults.AllowOtherCharacters         ,
                RequireLowercaseCharacters   = Globals.Defaults.RequireLowercaseCharacters   ,
                RequireUppercaseCharacters   = Globals.Defaults.RequireUppercaseCharacters   ,
                RequireNumberCharacters      = Globals.Defaults.RequireNumberCharacters      ,
                RequireSpecialCharacters     = Globals.Defaults.RequireSpecialCharacters     ,
                RequireUnderscoreCharacters  = Globals.Defaults.RequireUnderscoreCharacters  ,
                RequireSpaceCharacters       = Globals.Defaults.RequireSpaceCharacters       ,
                RequireOtherCharacters       = Globals.Defaults.RequireOtherCharacters       ,
                MinimumCharacters            = Globals.Defaults.MinimumCharacters            ,
                MaximumCharacters            = Globals.Defaults.MaximumCharacters            
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                "Select * from PasswordOptions where SettingsID = @SettingsID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@SettingsID", settings.ID));

                    connection.Open();
                    
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        passwordOptions.AllowLowercaseCharacters=    Convert.ToBoolean(reader["AllowLowercaseCharacters"]);
                        passwordOptions.AllowUppercaseCharacters=    Convert.ToBoolean(reader["AllowUppercaseCharacters"]);
                        passwordOptions.AllowNumberCharacters=       Convert.ToBoolean(reader["AllowNumberCharacters"]);
                        passwordOptions.AllowSpecialCharacters=      Convert.ToBoolean(reader["AllowSpecialCharacters"]);
                        passwordOptions.AllowUnderscoreCharacters=   Convert.ToBoolean(reader["AllowUnderscoreCharacters"]);
                        passwordOptions.AllowSpaceCharacters=        Convert.ToBoolean(reader["AllowSpaceCharacters"]);
                        passwordOptions.AllowOtherCharacters=        Convert.ToBoolean(reader["AllowOtherCharacters"]);
                        passwordOptions.RequireLowercaseCharacters=  Convert.ToBoolean(reader["RequireLowercaseCharacters"]);
                        passwordOptions.RequireUppercaseCharacters=  Convert.ToBoolean(reader["RequireUppercaseCharacters"]);
                        passwordOptions.RequireNumberCharacters=     Convert.ToBoolean(reader["RequireNumberCharacters"]);
                        passwordOptions.RequireSpecialCharacters=    Convert.ToBoolean(reader["RequireSpecialCharacters"]);
                        passwordOptions.RequireUnderscoreCharacters= Convert.ToBoolean(reader["RequireUnderscoreCharacters"]);
                        passwordOptions.RequireSpaceCharacters=      Convert.ToBoolean(reader["RequireSpaceCharacters"]);
                        passwordOptions.RequireOtherCharacters=      Convert.ToBoolean(reader["RequireOtherCharacters"]);
                        passwordOptions.MinimumCharacters=           Convert.ToInt32(reader["MinimumCharacters"]);
                        passwordOptions.MaximumCharacters=           Convert.ToInt32(reader["MaximumCharacters"]);
                        passwordOptions.OtherCharacters =            Convert.ToString(reader["OtherCharacters"]);
                    }
                }
            }

            return passwordOptions;
        }
        
        /// <summary>
        /// Updates Selected User in Database.
        /// </summary>
        /// <param name="user">User Entity to be updated.</param>
        /// <returns>True if User is updated otherwise False.</returns>
        public bool Update(PasswordManager.Entities.Settings settings)
        {
            PasswordManager.Entities.PasswordOptions passwordOptions = settings.PasswordOptions;

            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(
                @"Update PasswordOptions set
                  AllowLowercaseCharacters     = @AllowLowercaseCharacters,
                  AllowUppercaseCharacters     = @AllowUppercaseCharacters,
                  AllowNumberCharacters        = @AllowNumberCharacters,
                  AllowSpecialCharacters       = @AllowSpecialCharacters,
                  AllowUnderscoreCharacters    = @AllowUnderscoreCharacters,
                  AllowSpaceCharacters         = @AllowSpaceCharacters,
                  AllowOtherCharacters         = @AllowOtherCharacters,
                  RequireLowercaseCharacters   = @RequireLowercaseCharacters,
                  RequireUppercaseCharacters   = @RequireUppercaseCharacters,
                  RequireNumberCharacters      = @RequireNumberCharacters,
                  RequireSpecialCharacters     = @RequireSpecialCharacters,
                  RequireUnderscoreCharacters  = @RequireUnderscoreCharacters,
                  RequireSpaceCharacters       = @RequireSpaceCharacters,
                  RequireOtherCharacters       = @RequireOtherCharacters,
                  MinimumCharacters            = @MinimumCharacters,
                  MaximumCharacters            = @MaximumCharacters,
                  OtherCharacters              = @OtherCharacters
                  where SettingsID = @SettingsID
                ", connection))
                {
                    command.Parameters.Add(new SqlParameter("SettingsID", settings.ID));
                    command.Parameters.Add(new SqlParameter("AllowLowercaseCharacters", passwordOptions.AllowLowercaseCharacters));
                    command.Parameters.Add(new SqlParameter("AllowUppercaseCharacters", passwordOptions.AllowUppercaseCharacters));
                    command.Parameters.Add(new SqlParameter("AllowNumberCharacters", passwordOptions.AllowNumberCharacters));
                    command.Parameters.Add(new SqlParameter("AllowSpecialCharacters", passwordOptions.AllowSpecialCharacters));
                    command.Parameters.Add(new SqlParameter("AllowUnderscoreCharacters", passwordOptions.AllowUnderscoreCharacters));
                    command.Parameters.Add(new SqlParameter("AllowSpaceCharacters", passwordOptions.AllowSpaceCharacters));
                    command.Parameters.Add(new SqlParameter("AllowOtherCharacters", passwordOptions.AllowOtherCharacters));
                    command.Parameters.Add(new SqlParameter("RequireLowercaseCharacters", passwordOptions.RequireLowercaseCharacters));
                    command.Parameters.Add(new SqlParameter("RequireUppercaseCharacters", passwordOptions.RequireUppercaseCharacters));
                    command.Parameters.Add(new SqlParameter("RequireNumberCharacters", passwordOptions.RequireNumberCharacters));
                    command.Parameters.Add(new SqlParameter("RequireSpecialCharacters", passwordOptions.RequireSpecialCharacters));
                    command.Parameters.Add(new SqlParameter("RequireUnderscoreCharacters", passwordOptions.RequireUnderscoreCharacters));
                    command.Parameters.Add(new SqlParameter("RequireSpaceCharacters", passwordOptions.RequireSpaceCharacters));
                    command.Parameters.Add(new SqlParameter("RequireOtherCharacters", passwordOptions.RequireOtherCharacters));
                    command.Parameters.Add(new SqlParameter("MinimumCharacters", passwordOptions.MinimumCharacters));
                    command.Parameters.Add(new SqlParameter("MaximumCharacters", passwordOptions.MaximumCharacters));
                    command.Parameters.Add(new SqlParameter("OtherCharacters", passwordOptions.OtherCharacters));

                    connection.Open();

                    AffectedRows = command.ExecuteNonQuery();
                }
            }
            if (AffectedRows > 0) return true;
            else return false;
        }
    }
}
