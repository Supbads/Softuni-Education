using System;
using System.Linq;

namespace Problem_2.Book_Shop
{
    class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get { return this.author; }
            set
            {
                if (value.Substring(value.IndexOf(" ") + 1).ToCharArray().Any(c => c >= '0' && c <= '9'))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }


        public string Title
        {
            get { return this.title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}{Environment.NewLine}Title: {this.Title}{Environment.NewLine}Author: {this.Author}{Environment.NewLine}Price: {this.Price:F2}";
        }
    }
}