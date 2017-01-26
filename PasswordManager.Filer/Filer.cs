using PasswordManager.Entities;
using PasswordManager.Globals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PasswordManager.Filer
{
    public static class Filer
    {
        //Deprecated
        public static bool Save(List<User> Users)
        {
            //string FilePath = Globals.Variables.DatabaseFilePath;

            foreach (User user in Users)
            {
                foreach (Password password in user.Passwords)
                {
                    //get all stuff & write xml
                }
            }

            return false;
        }

        //Deprecated
        public static List<User> Read()
        {
            //return type should be a list of users with their password details
            //string FilePath = Globals.Variables.DatabaseFilePath;
            string FilePath = null;

            List<User> Users = new List<User>();

            User newUser = null;

            // Create an XML reader for this file.
            using (XmlReader xReader = XmlReader.Create(FilePath))
            {
                while (xReader.Read())
                {
                    // Only detect start elements.
                    if (xReader.IsStartElement())
                    {
                        switch (xReader.Name)
                        {
                            case "User":
                                if (newUser == null)
                                    newUser = new User();

                                XmlReader userreader = xReader.ReadSubtree();

                                while (userreader.Read())
                                {
                                    switch (userreader.Name)
                                    {
                                        case "Name":
                                            if (userreader.Read())
                                            {
                                                string Name = userreader.Value.Trim();
                                                if (Verifier.Text(Name))
                                                    newUser.Name = Name;
                                            }
                                            break;
                                        case "Username":
                                            if (userreader.Read())
                                            {
                                                string Username = userreader.Value.Trim();
                                                if (Verifier.Text(Username))
                                                    newUser.Username = Username;
                                            }
                                            break;
                                        case "Email":
                                            if (userreader.Read())
                                            {
                                                string Email = userreader.Value.Trim();
                                                if (Verifier.Text(Email)) // well i am not validating email here for now. Although i can
                                                    newUser.Email = Email;
                                            }
                                            break;
                                        case "Login":
                                            if (userreader.Read())
                                            {
                                                string Master = userreader.Value.Trim();
                                                if (Verifier.Text(Master))
                                                    newUser.Master = Master;
                                            }
                                            break;
                                        case "Passwords":
                                            List<Password> PasswordsList = new List<Password>();

                                            XmlReader PasswordsReader = userreader.ReadSubtree();

                                            Password newPassword = null;

                                            while (PasswordsReader.Read())
                                            {
                                                switch (PasswordsReader.Name)
                                                {
                                                    case "Password":
                                                        if (newPassword == null)
                                                            newPassword = new Password();
                                                        else
                                                        {
                                                            PasswordsList.Add(newPassword);
                                                            newPassword = null;
                                                        }
                                                        break;

                                                    case "ID":
                                                        if (PasswordsReader.Read())
                                                        {
                                                            string ID = PasswordsReader.Value.Trim();
                                                            if (Verifier.Text(ID))
                                                                newPassword.ID = Convert.ToInt32(ID);
                                                        }
                                                        break;
                                                    case "Name":
                                                        if (PasswordsReader.Read())
                                                        {
                                                            string Name = PasswordsReader.Value.Trim();
                                                            if (Verifier.Text(Name))
                                                                newPassword.Name = Name;
                                                        }
                                                        break;
                                                    case "Email":
                                                        if (PasswordsReader.Read())
                                                        {
                                                            string Email = PasswordsReader.Value.Trim();
                                                            if (Verifier.Text(Email))
                                                                newPassword.Email = Email;
                                                        }
                                                        break;
                                                    case "Username":
                                                        if (PasswordsReader.Read())
                                                        {
                                                            string Username = PasswordsReader.Value.Trim();
                                                            if (Verifier.Text(Username))
                                                                newPassword.Username = Username;
                                                        }
                                                        break;
                                                    case "Text":
                                                        if (PasswordsReader.Read())
                                                        {
                                                            string Text = PasswordsReader.Value.Trim();
                                                            if (Verifier.Text(Text))
                                                                newPassword.Text = Text;
                                                        }
                                                        break;
                                                    case "DateCreated":
                                                        if (PasswordsReader.Read())
                                                        {
                                                            string DateCreated = PasswordsReader.Value.Trim();
                                                            if (Verifier.Text(DateCreated))
                                                                newPassword.DateCreated = Convert.ToDateTime(DateCreated);
                                                        }
                                                        break;
                                                    case "DateModified":
                                                        if (PasswordsReader.Read())
                                                        {
                                                            string DateModified = PasswordsReader.Value.Trim();
                                                            if (Verifier.Text(DateModified))
                                                                newPassword.DateModified = Convert.ToDateTime(DateModified);
                                                        }
                                                        break;
                                                }
                                            }
                                            newUser.Passwords = PasswordsList;
                                            break;
                                    }
                                }

                                //temporary - 10122016
                                newUser.Settings = new Settings()
                                {
                                    DateTimeFormat = "d",
                                    PasswordOptions = new PasswordOptions(),
                                    ShowEmailColumn = true,
                                    ShowUsernameColumn = true,
                                    ShowPasswordColumn = false
                                };

                                Users.Add(newUser);
                                newUser = null;
                                break;
                        }
                    }
                }
                return Users;
            }
        }

        public static List<Password> ImportFromFile(string FileName)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(List<Password>));

            FileStream ReadFileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            List<Password> importedPasswords = (List<Password>)SerializerObj.Deserialize(ReadFileStream);

            ReadFileStream.Flush();
            ReadFileStream.Close();

            return importedPasswords;
        }

        public static bool ExportToFile(List<Password> Passwords, string FileName)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(List<Password>));

            FileStream WriteFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

            TextWriter writer = new StreamWriter(WriteFileStream);

            SerializerObj.Serialize(writer, Passwords);

            writer.Flush();
            writer.Close();

            return true;
        }
    }
}
