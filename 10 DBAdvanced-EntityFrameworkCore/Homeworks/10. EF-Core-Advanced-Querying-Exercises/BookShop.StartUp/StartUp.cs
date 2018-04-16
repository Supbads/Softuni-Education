using System.Text.RegularExpressions;

namespace BookShop
{
    using System.Globalization;
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using BookShop.Models;
    using BookShop.Data;
    using BookShop.Initializer;
    
    public class StartUp
    {
        static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                //var input = Console.ReadLine().ToLower();
                //var output = GetBooksByAgeRestriction(db, input);
                //Console.WriteLine(output);
                //output = GetGoldenBooks(db);

                //var output = GetBooksByAuthor(db, "R");
                //Console.WriteLine(output);


                //GetMostRecentBooks(db);
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200);
            var count = books.Count();

            foreach (var book in books)
            {
                context.Remove(book);
            }

            context.SaveChanges();

            return count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList().ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    //CategoryBookCount = c.CategoryBooks.Count(),
                    Books = c.CategoryBooks
                        .OrderByDescending(x => x.Book.ReleaseDate.Value)
                        .Take(3)
                        .Select(y => new
                            {
                                y.Book.Title,
                                y.Book.ReleaseDate.Value.Year
                            }
                        )
                        .OrderByDescending(x => x.Year)
                })
                .OrderBy(x => x.CategoryName) //The categories should be ordered by total book count. Problem is incorrect
                .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine("--"+category.CategoryName);

                foreach (var book in category.Books)
                {
                    sb.AppendLine(book.Title + $" ({book.Year})");
                }
            }

            return sb.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .Select(c => $"{c.Name} ${c.Profit}")
                .ToArray();

            return string.Join(Environment.NewLine, profitByCategory);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsAndCopies = context.Books
                .GroupBy(b => b.Author)
                .Select(gb => new
                    {
                        Name = $"{gb.Key.FirstName} {gb.Key.LastName}",
                        CopiesCount = gb.Sum(b => b.Copies)
                    })
                .OrderByDescending(ac => ac.CopiesCount)
                .Select(a => $"{a.Name} - {a.CopiesCount}")
                .ToArray();

            return string.Join(Environment.NewLine, authorsAndCopies);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCount = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return bookCount;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => Regex.IsMatch(b.Title, $"^.*{input}.*$", RegexOptions.IgnoreCase))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a);

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {              
            string format = "dd-MM-yyyy";

            var parsedDate = DateTime.ParseExact(date, format, DateTimeFormatInfo.InvariantInfo);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}");

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => s.ToLower());

            var booksByCategories = context.Books
                .Where(b => b.BookCategories
                    .Select(bc => bc.Category.Name.ToLower())
                    .Intersect(categories)
                    .Any())
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, booksByCategories);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var booksNotReleased = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            return string.Join(Environment.NewLine, booksNotReleased);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}");

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            var titlesByAgeRestriction = context.Books
                .Where(b => b.AgeRestriction
                    .ToString()
                    .ToLower()
                    .Equals(command, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            var result = String.Join(Environment.NewLine, titlesByAgeRestriction);

            return result;
        }
    }
}