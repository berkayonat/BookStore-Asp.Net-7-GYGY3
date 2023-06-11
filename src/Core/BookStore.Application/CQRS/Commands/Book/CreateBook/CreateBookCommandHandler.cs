using AutoMapper;
using BookStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<BookStore.Domain.Book>(request);
            if (book.ImageUrl == null)
            {
                book.ImageUrl = "https://picsum.photos/200/300";
            }
            if (request.AuthorIds != null)
            {
                foreach (var authorId in request.AuthorIds)
                {
                    var author = await _authorRepository.GetByIdAsync(authorId);
                    if (author != null)
                    {
                        book.Authors?.Add(author);
                    }
                }
            }
            await _bookRepository.CreateAsync(book);
        }
    }
}
