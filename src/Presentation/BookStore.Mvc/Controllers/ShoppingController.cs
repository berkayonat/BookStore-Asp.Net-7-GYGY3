using BookStore.Application.CQRS.Queries.Book.GetBookById;
using BookStore.Application.DTOs.Book;
using BookStore.Mvc.Extensions;
using BookStore.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;

namespace BookStore.Mvc.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IMediator _mediator;

        public ShoppingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            var bookCollection = getBookCollectionFromSession();
            return View(bookCollection);
        }

        public async Task<IActionResult> AddBook(int id)
        {
            GetBookDto selectedBook = await _mediator.Send(new GetBookByIdQuery(id));
            var bookItem = new BookItem { Book = selectedBook, Quantity = 1 }; 
            BookCollection bookCollection = getBookCollectionFromSession();
            bookCollection.AddNewBook(bookItem);
            saveToSession(bookCollection);

            return Json(new { message = $"{selectedBook.Title} Sepete eklendi" });
        }

        private BookCollection getBookCollectionFromSession()
        {
            return HttpContext.Session.GetJson<BookCollection>("basket") ?? new BookCollection();

        }

        private void saveToSession(BookCollection bookCollection)
        {

            HttpContext.Session.SetJson("basket", bookCollection);

        }
    }
}
