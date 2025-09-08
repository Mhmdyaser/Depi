using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;

namespace LINQtoObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1-Display book title and its ISBN.
            var books= SampleData.Books
                .Select(b => new { b.Title, b.Isbn });

            foreach (var item in books)
            {
                Console.WriteLine($"Title: {item.Title}, ISBN: {item.Isbn}");
            }
            Console.WriteLine("--------------------------------------------------");

            //2-Display the first 3 books with price more than 25.
            var book = SampleData.Books.Where(b=> b.Price > 25).Take(3);

            foreach (var item in book)
            {
                Console.WriteLine($"Title: {item.Title}, Price: {item.Price}");
            }

            Console.WriteLine("--------------------------------------------------");

            //3-Display Book title along with its publisher name. (Using linq oprator)
            var bookWithPublisher = SampleData.Books
                .Select (b => new { b.Title, PublisherName=b.Publisher.Name });

            foreach (var item in bookWithPublisher)
                {
                Console.WriteLine($"Title: {item.Title}, Publisher: {item.PublisherName}");
                }
            Console.WriteLine("----------------------");

            //(Using linq  expression)
            var bookWithPublisher2 = from b in SampleData.Books
                                     select new { b.Title, PublisherName = b.Publisher.Name };


            foreach (var item in bookWithPublisher2)
            {
                Console.WriteLine($"Title: {item.Title}, Publisher: {item.PublisherName}");
            }

            Console.WriteLine("--------------------------------------------------");


            //4-Find the number of books which cost more than 20.
            var bookcount= SampleData.Books.Where(b => b.Price > 20).Count();
            Console.WriteLine($"Number of books: {bookcount}");
            var bookcount1= SampleData.Books.Count(b => b.Price > 20);
            Console.WriteLine($"Number of books: {bookcount1}");
            
            Console.WriteLine("--------------------------------------------------");


            //5-Display book title, price and subject name sorted by its subject name ascending and by its price descending.
            var query = SampleData.Books.OrderBy(b=> b.Subject.Name).ThenByDescending(b=> b.Price)
                .Select(b => new { b.Title, b.Price, SubjectName = b.Subject.Name });
            
             foreach (var item in query)
                {
                Console.WriteLine($"Title: {item.Title}, Price: {item.Price}, Subject: {item.SubjectName}");
                }


            Console.WriteLine("--------------------------------------------------");


            //6-Display All subjects with books related to this subject. (Using sub query).
            var subjects = SampleData.Subjects
                .Select(s => new
                {
                    SubjectName = s.Name,
                    Books = SampleData.Books.Where(b => b.Subject.Name == s.Name)
                });

            foreach (var item in subjects)
                {
                Console.WriteLine($"Subject: {item.SubjectName}");
                foreach (var title in item.Books)
                {
                    Console.WriteLine($"Book Title: {title}");
                }
                Console.WriteLine("----------------------");
            }

            //(Using group by)
            var subjects2 = from b in SampleData.Books
                            group b by b.Subject.Name into g
                            select new
                            {
                                SubjectName = g.Key,
                                Books = g
                            };
            foreach (var item in subjects2)
            {
                Console.WriteLine($"Subject: {item.SubjectName}");
                foreach (var title in item.Books)
                {
                    Console.WriteLine($"Book Title: {title}");
                }
                Console.WriteLine("----------------------");


            }
                       Console.WriteLine("--------------------------------------------------");


            //7-Try to display book title & price (from book objects) returned from GetBooks Function.
            var q2 = SampleData.GetBooks()
                .Cast<Book>()
                .Select(b => new { b.Title, b.Price });

            foreach (var item in q2)
            {
                Console.WriteLine($"Title: {item.Title}, Price: {item.Price}");
            }


            //8-Display books grouped by publisher & Subject.
            var bookGroup = from b in SampleData.Books
                            group b by new { b.Publisher.Name, Subject=b.Subject.Name } into g
                            select new
                            {
                                PublisherName = g.Key.Name,
                                SubjectName = g.Key.Subject,
                                Books = g
                            };

            foreach (var item in bookGroup)
                {
                Console.WriteLine($"Publisher: {item.PublisherName}, Subject: {item.SubjectName}");
                foreach (var title in item.Books)
                {
                    Console.WriteLine($"Book Title: {title}");
                }
                Console.WriteLine("----------------------");
            }

        }
    }
}
