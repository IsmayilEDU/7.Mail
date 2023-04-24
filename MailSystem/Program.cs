using MailSystem.Models;
using MyLibrary;
using notification;

namespace MailSystem
{
    internal class Program
    {
        public static void ShowPostsOneByOne(List<Post> posts, Admin admin, User user)
        {
            try
            {
                int index = 0;
                do
                {
                    Console.Clear();

                    Console.WriteLine(posts[index].ToString());
                    Console.WriteLine();
                    posts[index].IncreementViewCount();

                    Console.Write("For next post  -->\nFor previous post <--\nFor like ENTER\nFor back to menu ESC");

                    ConsoleKeyInfo button = Console.ReadKey(true);

                    switch (button.Key)
                    {
                        //  Next post
                        case ConsoleKey.RightArrow:
                            if (index >= 0 && index <= posts.Count - 2)
                            {
                                index++;
                            }
                            break;

                        //  Previous post
                        case ConsoleKey.LeftArrow:
                            if (index >= 1 && index <= posts.Count - 1)
                            {
                                index--;
                            }
                            break;

                        //  Like post
                        case ConsoleKey.Enter:
                            posts[index].IncreementLikeCount();
                            admin.Notifications.Add(new Notification(Guid.NewGuid(), $"{posts[index].ID} nomreli ID-ye malik post beyenildi", DateTime.Now, user.Name));
                            break;

                        //  Back to menu
                        case ConsoleKey.Escape:
                            throw new MyException("You logget out to menu");
                            break;
                    }

                } while (true);
            }
            catch (MyException ex)
            {
                MyConsole.ShowDescriptionInRed(ex.Message);
            }
        }
        
        static void Main(string[] args)
        {
            //  options of all menus
            List<string> optionsMainMenu = new List<string>() { "Admin", "User", "Exit" };
            List<string> optionsAdminMenu = new List<string>()
            {
                "Show all notifications",
                "Show all posts",
                "Add post",
                "Remove post by ID",
                "Exit"
            };

            //  Demo Posts
            List<Post> posts = new List<Post>()
            {
                new Post(Guid.NewGuid(), "Dini paylashim", DateTime.Now),
                new Post(Guid.NewGuid(), "Siyasi paylashim", DateTime.Now),
                new Post(Guid.NewGuid(), "Sosial paylashim", DateTime.Now),
            };

            //  Demo Admin
            Admin admin = new Admin(Guid.NewGuid(), "admin", "admin123", "kerimzzade@gmail.com", posts);

            //  Demo User
            User user = new User(Guid.NewGuid(), "Ismayil", "Kerimzade", 28, "isi.me@bk.ru", "ismayl177");

            do
            {
                try
                {
                    //  Main Menu
                    byte optionMainMenu = MyMenu.createMenu("Please select option from Main Menu:", optionsMainMenu);
                    switch (optionMainMenu)
                    {
                        // Admin Menu
                        case 0:
                            do
                            {
                                try
                                {
                                    //  input login and password
                                    string? login = MyConsole.GetInformationFromUser("Please enter your login: ");
                                    string? password = MyConsole.GetInformationFromUser("Please enter your password: ");

                                    //  Check login and password
                                    if (admin.Login == login && admin.Password == password)
                                    {
                                        do
                                        {
                                            try
                                            {
                                                byte optionAdminMenu = MyMenu.createMenu("Select option from Admin Menu:", optionsAdminMenu);
                                                Console.Clear();
                                                switch (optionAdminMenu)
                                                {
                                                    // Show all notifications
                                                    case 0:
                                                        admin.ShowAllNotifications();
                                                        Thread.Sleep(5000);
                                                        break;

                                                    //  Show all posts
                                                    case 1:
                                                        admin.ShowAllPosts();
                                                        Thread.Sleep(5000);
                                                        break;

                                                    //  Add post
                                                    case 2:
                                                        //  Input content of post
                                                        string? content = MyConsole.GetInformationFromUser("Please enter content of post");
                                                        admin.Posts.Add(new Post(Guid.NewGuid(), content!, DateTime.Now));
                                                        break;

                                                    //  Remove post by ID
                                                    case 3:
                                                        try
                                                        {
                                                            //  Input ID which admin wants delete
                                                            string? InputID = MyConsole.GetInformationFromUser("Please enter ID which you want delete");
                                                            admin.RemovePostByID(InputID!);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MyConsole.ShowDescriptionInRed(ex.Message);
                                                        }
                                                        break;

                                                    //  Exit
                                                    case 4:
                                                        throw new MyException("You logget out to back menu");
                                                }
                                            }
                                            catch (MyException ex)
                                            {
                                                throw new MyException("You logget out to back menu");
                                            }
                                        } while (true);
                                    }
                                    else
                                    {
                                        MyConsole.ShowDescriptionInRed("Login or password invalid!");
                                    }
                                }
                                catch (MyException ex)
                                {
                                    MyConsole.ShowDescriptionInRed(ex.Message);
                                    break;
                                }
                            } while (true);
                            break;
                        //  User Menu
                        case 1:
                            ShowPostsOneByOne(posts, admin, user);
                            break;

                        //  Exit
                        case 2:
                            throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    break;
                }
            } while (true);
        }
    }
}