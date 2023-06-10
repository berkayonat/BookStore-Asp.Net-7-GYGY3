using AutoMapper;
using BookStore.Application.CQRS.Queries.Book.GetAllBooks;
using BookStore.Application.DTOs.Book;
using BookStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Book.GetAllBooksByCategory
{
    public class GetAllBooksByGenreQueryHandler : IRequestHandler<GetAllBooksByGenreQuery, IEnumerable<GetAllBooksDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksByGenreQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllBooksDto>> Handle(GetAllBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooksByGenreWithInclude(request.Id);
            return _mapper.Map<IEnumerable<GetAllBooksDto>>(books);
        }
    }
}
