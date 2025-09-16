using EF_CodeFrist.Models;

namespace EF_CodeFrist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new S2Context();
            #region Add Author
            // db.Authors.Add(new Author
            //{
            //    Name = "Mohamed Yaser",
            //    Age = 22,
            //    Username = "mhmd123",
            //    Password = "1234",
            //    JoinDate = DateTime.Now
            //});

            // db.Authors.Add(new Author
            // {
            //     Name = "Malak Ibrahim",
            //     Age = 20,
            //     Username = "malak123",
            //     Password = "12345",
            //     JoinDate = DateTime.Now
            // });
            // db.SaveChanges();
            #endregion

            #region Add Category
            //db.Categorys.Add(new Category
            //    {
            //    Name = "Sports",
            //    Desc = "Football"
            //});
            //db.Categorys.Add(new Category
            //{
            //    Name = "Politics",
            //    Desc = "Elections"
            //});
            //db.SaveChanges();

            #endregion

            #region Add News
            //db.News.Add(new News
            //{
            //    Title = "Real Madrid Win Champions League",
            //    Bref = "Real Madrid beat Liverpool 1-0 in the 2022 final in Paris.",
            //    Desc = "Vinícius Júnior scored the winning goal",
            //    Time = new TimeSpan(21, 0, 0),
            //    Date = new DateTime(2022, 5, 28),
            //    CategoryId = 1,
            //    AuthorId = 1
            //});

            //db.News.Add(new News
            //{
            //    Title = "Elections 2024: Key Dates to Remember",
            //    Bref = "The general elections are scheduled for November 5, 2024.",
            //    Desc = "Voters will elect representatives for the next four years.",
            //    Time = new TimeSpan(8, 0, 0),
            //    Date = new DateTime(2024, 11, 5),
            //    CategoryId = 2,
            //    AuthorId = 2
            //});
            //db.SaveChanges();
            #endregion

            #region Login
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            var author = db.Authors.SingleOrDefault(a => a.Username == username && a.Password == password);
            if (author != null)
            {
                Console.WriteLine($"Welcome, {author.Name}!");
                Console.WriteLine("----- Profile Info ------");
                Console.WriteLine($"ID: {author.Id}");
                Console.WriteLine($"Age: {author.Age}");
                Console.WriteLine($"Join Date: {author.JoinDate}\n");

                Console.WriteLine("==========================================================================/n");


                #region Menu
                while (true)
                {
                    Console.WriteLine("<<<<<<<<Menu>>>>>>>>");
                    Console.WriteLine("1. View All News");
                    Console.WriteLine("2. Add News");
                    Console.WriteLine("3. Remove News");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option (1-4): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        //View All News
                        case "1":
                            var item = db.News.ToList();
                            foreach (var news in item)
                            {
                                Console.WriteLine($"ID: {news.Id}");
                                Console.WriteLine($"Title: {news.Title}");
                                Console.WriteLine($"Bref: {news.Bref}");
                                Console.WriteLine($"Desc: {news.Desc}");
                                Console.WriteLine($"Time: {news.Time}");
                                Console.WriteLine($"Date: {news.Date}");
                                Console.WriteLine($"Category ID: {news.CategoryId}");
                                Console.WriteLine($"Author ID: {news.AuthorId}");
                                Console.WriteLine("--------------------------------------------------");
                            }
                            break;

                        //Add News
                        case "2":
                            Console.Write("Enter Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Bref: ");
                            string bref = Console.ReadLine();
                            Console.Write("Enter Desc: ");
                            string desc = Console.ReadLine();
                            Console.Write("Enter CategoryID: ");
                            int categoryId = int.Parse(Console.ReadLine());
                            var category = db.Categorys.Find(categoryId);
                            if (category == null)
                            {
                                Console.WriteLine("Invalid Category ID.");
                                break;
                            }
                            var newNews = new News
                            {
                                Title = title,
                                Bref = bref,
                                Desc = desc,
                                Time = DateTime.Now.TimeOfDay,
                                Date = DateTime.Now.Date,
                                CategoryId = categoryId,
                                AuthorId = author.Id
                            };
                            db.News.Add(newNews);
                            db.SaveChanges();
                            Console.WriteLine("News added successfully.");
                            break;

                        //Remove News
                        case "3":
                            Console.Write("Enter News ID to remove: ");
                            int newsId = int.Parse(Console.ReadLine());
                            var newsToRemove = db.News.Find(newsId);
                            if (newsToRemove == null)
                            {
                                Console.WriteLine("News not found.");
                                break;
                            }
                            if (newsToRemove.AuthorId != author.Id)
                            {
                                Console.WriteLine("You can only remove your own news.");
                                break;
                            }
                            db.News.Remove(newsToRemove);
                            db.SaveChanges();
                            Console.WriteLine("News removed successfully.");
                            break;


                        // Exit
                        case "4":
                            Console.WriteLine("Exiting");
                            return;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }

                }
                #endregion
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
            #endregion

           

          




        }
    }
    }
