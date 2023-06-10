using BookStore.Application.CQRS.Queries.Book.GetAllBooks;
using BookStore.Application.CQRS.Queries.Book.GetAllBooksByCategory;
using BookStore.Application.DTOs.Book;
using BookStore.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace BookStore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, IMemoryCache memoryCache)
        {
            _logger = logger;
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<ActionResult> Index(int pageNo = 1, int? id = null)
        {
            IEnumerable<GetAllBooksDto> books = await GetBooksMemCacheOrDb(id);

            var bookPerPage = 8;
            var bookCount = books.Count();

            var pagingInfo = new PagingInfo
            {
                CurrentPage = pageNo,
                ItemsPerPage = bookPerPage,
                TotalItems = bookCount
            };

            var paginatedBooks = books.OrderBy(c => c.Id)
                                          .Skip((pageNo - 1) * bookPerPage)
                                          .Take(bookPerPage)
                                          .ToList();

            var model = new PaginationBookVM
            {
                Books = paginatedBooks,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        private async Task<IEnumerable<GetAllBooksDto>> GetBooksMemCacheOrDb(int? id)
        {
            IEnumerable<GetAllBooksDto> books;
            if (id == null)
            {
                if (!_memoryCache.TryGetValue("allBooks", out books))
                {
                    books = await _mediator.Send(new GetAllBooksQuery());
                    var options = new MemoryCacheEntryOptions()
                                      .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                                      .SetPriority(CacheItemPriority.Normal);

                    _memoryCache.Set("allBooks", books, options);
                }
            }
            else
            {
                books = await _mediator.Send(new GetAllBooksByGenreQuery(id));
            }
            return books;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}