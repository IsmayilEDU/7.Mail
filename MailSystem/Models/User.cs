using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem.Models
{
    internal class User
    {
        //  ID
        public Guid ID { get; init; }

        //  Name
        private string _name;
        public string Name 
        { 
            get { return _name; }
            set
            {
                //  If there are only letters in value
                if (MyString.CheckOnlyLettersInString(value))
                {
                    _name = value;
                }

                //  If the condition is not met
                else
                {
                    throw new Exception("Name should be contain only letters!");
                }
            }
        }

        //  Name
        private string _surname;
        public string Surname 
        { 
            get { return _surname; }
            set
            {
                //  If there are only letters in value
                if (MyString.CheckOnlyLettersInString(value))
                {
                    _surname = value;
                }

                //  If the condition is not met
                else
                {
                    throw new Exception("Surname should be contain only letters!");
                }
            }
        }

        //  Age
        private byte _age;


        public byte Age 
        { 
            get { return _age; }
            set
            {
                //  Age should be nly postive number
                if (value > 0)
                {
                    _age = value;
                }

                //  If the condition is not met
                else
                {
                    throw new Exception("Age should be nly postive number");
                }
            }
        }

        //  E-mail
        public string Email { get; set; }

        //  Password of E-mail
        public string PasswordEmail { get; set; }

        //  Constructor with parametres
        public User(Guid iD, string name,string surname,byte age,string email, string passwordEmail)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            PasswordEmail = passwordEmail;
        }



    }
}
