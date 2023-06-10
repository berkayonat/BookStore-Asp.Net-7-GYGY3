using BookStore.Application.DTOs.Book;
using NuGet.Configuration;

namespace BookStore.Mvc.Models
{
    public class BookCollection
    {
        public List<BookItem> BookItems { get; set; } = new List<BookItem>();

        public void ClearAll() => BookItems.Clear();
        public decimal TotalBookPrice() => BookItems.Sum(item => (decimal)item.Book.Price * item.Quantity);

        public int TotalBookCount() => BookItems.Sum(p => p.Quantity);

        public void AddNewBook(BookItem bookItem)
        {
            var exists = BookItems.FirstOrDefault(c => c.Book.Id == bookItem.Book.Id);
            if (exists != null)
            {
                exists.Quantity += bookItem.Quantity;
            }
            else
            {
                BookItems.Add(bookItem);
            }

        }
    }
    public class BookItem
    {
        public GetBookDto Book { get; set; }
        public int Quantity { get; set; }

    }
}
