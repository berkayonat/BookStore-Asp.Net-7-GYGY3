using AutoMapper;
using BookStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;   
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (await _bookRepository.IsExistsAsync(request.Id))
            {
                var book = await _bookRepository.GetBookByIdWithInclude(request.Id);

                //book.Title = request.Title;
                //book.Description = request.Description;
                //book.GenreId = request.GenreId;
                //book.PublisherId = request.PublisherId;
                //book.PublicationDate = request.PublicationDate;
                //book.ImageUrl = request.ImageUrl;
                //book.Price = request.Price;
                //book.Quantity = request.Quantity;
                //book.Status = request.Status;

                _mapper.Map(request, book);

                book.Authors?.Clear();
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
                await _bookRepository.UpdateAsync(book);
            }
        }
    }
}
