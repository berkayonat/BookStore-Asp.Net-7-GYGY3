using AutoMapper;
using BookStore.Application.CQRS.Commands.Book.CreateBook;
using BookStore.Application.CQRS.Commands.Book.DeleteBook;
using BookStore.Application.CQRS.Commands.Book.UpdateBook;
using BookStore.Application.CQRS.Queries.Author.GetAllAuthors;
using BookStore.Application.CQRS.Queries.Book.GetAllBooks;
using BookStore.Application.CQRS.Queries.Book.GetBookById;
using BookStore.Application.CQRS.Queries.Genre.GetAllGenres;
using BookStore.Application.CQRS.Queries.Publisher.GetAllPublishers;
using BookStore.Application.DTOs.Book;
using BookStore.Application.DTOs.Genre;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Data;

namespace BookStore.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: BookController
        public async Task<ActionResult> Index()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Genres = await GetGenresForSelectList();
            ViewBag.Publishers = await GetPublishersForSelectList();
            ViewBag.Authors = await GetAuthorsForSelectList();

            return View();
        }


        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookCommand request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Genres = await GetGenresForSelectList();
            ViewBag.Publishers = await GetPublishersForSelectList();
            ViewBag.Authors = await GetAuthorsForSelectList();
            return View(request);
        }

        // GET: BookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Genres = await GetGenresForSelectList();
            ViewBag.Publishers = await GetPublishersForSelectList();
            ViewBag.Authors = await GetAuthorsForSelectList();
            var book = _mapper.Map<UpdateBookCommand>(await _mediator.Send(new GetBookByIdQuery(id)));
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateBookCommand request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Genres = await GetGenresForSelectList();
            ViewBag.Publishers = await GetPublishersForSelectList();
            ViewBag.Authors = await GetAuthorsForSelectList();
            return View(request);
        }

        // GET: BookController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>> GetGenresForSelectList()
        {
            var genres = await _mediator.Send(new GetAllGenresQuery());
            return genres.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

        }
        private async Task<IEnumerable<SelectListItem>> GetPublishersForSelectList()
        {
            var publishers = await _mediator.Send(new GetAllPublishersQuery());
            return publishers.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

        }
        private async Task<IEnumerable<SelectListItem>> GetAuthorsForSelectList()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

        }
    }
}
