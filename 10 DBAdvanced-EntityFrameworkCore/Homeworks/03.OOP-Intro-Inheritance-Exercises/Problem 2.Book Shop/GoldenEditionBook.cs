namespace Problem_2.Book_Shop
{
    class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
        {
            this.Price *= 1.3m;
        }
    }
}