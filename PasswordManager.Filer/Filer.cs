using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PasswordManager.Filer
{
    public class Filer
    {
        public bool Save(List<User> Users)
        {
            string FilePath = Globals.Settings.DatabaseFilePath;

            foreach (User user in Users)
            {
                foreach (Password password in user.Passwords)
                {
                    //get all stuff & write xml
                }
            }

            return false;
        }

        public List<User> Read()
        {
            //return type should be a list of users with their password details
            string FilePath = Globals.Settings.DatabaseFilePath;

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
                        // Get element name and switch on it.
                        switch (xReader.Name)
                        {
                            case "User":
                                if (newUser == null)
                                    newUser = new User();
                                else
                                {
                                    Users.Add(newUser);
                                    newUser = new User();
                                }
                                break;

                            case "Name":
                                newUser.Name = xReader.ReadSubtree
                            case "Password":

                            case "Password":

                            case "Password":
                                // Detect this article element.
                                Console.WriteLine("Start <article> element.");
                                // Search for the attribute name on this current node.
                                string attribute = reader["name"];
                                if (attribute != null)
                                {
                                    Console.WriteLine("  Has attribute name: " + attribute);
                                }
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }




            // Loading from a file, you can also load from a stream
            var xml = XDocument.Load(FilePath);
            
            // Query the data and write out a subset of contacts
            var query = from User in xml.Root.Descendants("User")
                        where (int)User.Attribute("Password") < 4
                        select User.Element("firstName").Value + " " +
                               User.Element("lastName").Value;


            XmlTextReader reader = new XmlTextReader(FilePath);

            while (reader.Read())
            {
                User user;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.LocalName == "User")
                    {
                        user = new User();


                    }

                    if (reader.LocalName == "Name")
                    {
                        contact.Name = reader.ReadString();
                    }

                    if (reader.LocalName == "Email")
                    {
                        contact.Email = reader.ReadString();
                    }

                    if (reader.LocalName == "Phone")
                    {
                        contact.Phone = reader.ReadString();
                    }

                    if (reader.LocalName == "FacebookID")
                    {
                        contact.FacebookID = reader.ReadString();
                    }

                    if (reader.LocalName == "Address")
                    {
                        contact.Address = reader.ReadString();
                    }

                }

                myContactsList.Add(contact);

            }
            reader.Close();

            return new List<User>();
        }
    }
}
