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

                if (authorsAndBooks.Any(x => x.Value.Exists(y => y.Title == title)))
                {
                    var selectedList = authorsAndBooks[author];

                    selectedList.RemoveAll(x => x.Title == title);
                }
                //same book -> overwrite year
                authorsAndBooks[author].Add(book);
            }
            var targetDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Dictionary<string, DateTime> titlesAndDates = new Dictionary<string, DateTime>();

            foreach (var authorAndBookPair in authorsAndBooks)
            {
                foreach (var book in authorAndBookPair.Value)
                {
                    titlesAndDates.Add(book.Title, book.ReleaseDate);

                }
            }

            foreach (var titleAndDatePair in titlesAndDates.Where(y => y.Value > targetDate).OrderBy(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine("{0} -> {1:dd.MM.yyyy}", titleAndDatePair.Key, titleAndDatePair.Value);
            }

        }
    }
}