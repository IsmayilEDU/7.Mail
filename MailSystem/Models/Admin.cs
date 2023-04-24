using notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem.Models
{
    internal class Admin
    {
        //  ID
        public Guid ID { get; init; }

        //  Login
        public string Login { get; set; }

        //  Password
        private string _password;
        public string Password 
        { 
            get { return _password; }
            set
            {
                //  Length password should be more than 7
                if (value.Length >= 8)
                {
                    _password = value;
                }

                //  If the condition is not met
                else 
                {
                    throw new Exception("Length password should be more than 7");
                }
            }
        }

        //  E-mail
        public string Email { get; set; }

        //  List of posts
        public List<Post> Posts { get; set; }

        //  List of notifications
        public List<Notification> Notifications { get; init; }

        //  Constructor with parametres
        public Admin(Guid iD, string login, string password, string email, List<Post> posts)
        {
            ID = iD;
            Login = login;
            Password = password;
            Email = email;
            Posts = posts;
            Notifications = new List<Notification>();
        }

        //  Show all posts
        public void ShowAllPosts()
        {
            foreach (var post in Posts)
            {
                Console.WriteLine(post.ToString());
                Console.WriteLine();
            }
        }

        //  Show all notifications
        public void ShowAllNotifications()
        {
            foreach (var notification in Notifications)
            {
                Console.WriteLine(notification.ToString());
            }
        }

        //  Remove post by ID
        public void RemovePostByID(string _ID) 
        {
            int indexRemovePost = 0;
            bool exist = false;

            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].ID.ToString() == _ID)
                {
                    indexRemovePost = i;
                    exist = true;
                    break;
                }
            }

            //  if the searched post is in the Posts
            if (exist) 
            {
                Posts.RemoveAt(indexRemovePost);
            }

            //  If the condition is not met
            else
            {
                throw new Exception("The requested post was not found in the Posts");
            }
        }
    }
}
