using AutoMapper;
using BookStore.Application.DTOs.Book;
using BookStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Book.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;


        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetBookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdWithInclude(request.Id);
            var bookDto = _mapper.Map<GetBookDto>(book);
            bookDto.AuthorIds = book?.Authors?.Select(a => a.Id).ToList();
            return bookDto;
        }
    }
}
