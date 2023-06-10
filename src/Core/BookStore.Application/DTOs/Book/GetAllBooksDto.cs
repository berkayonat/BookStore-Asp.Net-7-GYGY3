using BookStore.Domain;

namespace BookStore.Application.DTOs.Book
{
    public class GetAllBooksDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<BookStore.Domain.Author>? Authors { get; set; }
        public BookStore.Domain.Publisher? Publisher { get; set; }
    }
}