using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Problem_5.Book_Library
{
    public class Book
    {
        public Book(string title, string author, string publisher, DateTime releaseDate, string isbn, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this.Price = price;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Book>> authorsAndBooks = new Dictionary<string, List<Book>>();

            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                
                var title = tokens[0];
                var author = tokens[1];
                var publisher = tokens[2];
                var releaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                var isbn = tokens[4];
                decimal price = decimal.Parse(tokens[5]);

                var book = new Book(title, author, publisher, releaseDate, isbn, price);

                if (!authorsAndBooks.ContainsKey(author))
                {
                    authorsAndBooks.Add(author, new List<Book>());
                }

                authorsAndBooks[author].Add(book);
            }

            Dictionary<string, decimal> authorsAndPrice = new Dictionary<string, decimal>();

            foreach (var authorAndBookPair in authorsAndBooks)
            {
                var authorName = authorAndBookPair.Key;
                decimal currentSum = authorAndBookPair.Value.Sum(x => x.Price);

                authorsAndPrice.Add(authorName, currentSum);
            }

            foreach (var authorAndPricePair in authorsAndPrice.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine("{0} -> {1:F2}", authorAndPricePair.Key, authorAndPricePair.Value);
            }

            //honest to god no idea why the bellow code does not work and the above one does.

            //foreach (var authorAndBooksPair in authorsAndBooks.OrderByDescending(x => x.Value.Sum(y => y.Price)).ThenBy(x => x.Value.OrderBy(y => y.Author)))
            //{
            //    decimal currentAuthorSum = authorAndBooksPair.Value.Sum(x => x.Price);

            //    Console.WriteLine("{0} -> {1:F2}", authorAndBooksPair.Key, currentAuthorSum);
            //}

        }
    }
}