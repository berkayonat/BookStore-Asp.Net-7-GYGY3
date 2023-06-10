using BookStore.Application.DTOs.Book;

namespace BookStore.Mvc.Models
{
    public class PaginationBookVM
    {
        public IEnumerable<GetAllBooksDto> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
