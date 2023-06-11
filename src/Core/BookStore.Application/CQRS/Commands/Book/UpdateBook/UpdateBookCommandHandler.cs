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
                var book = _mapper.Map<BookStore.Domain.Book>(request);
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
