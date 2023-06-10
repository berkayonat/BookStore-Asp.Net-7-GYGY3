using BookStore.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Book.GetBookById
{
    public class GetBookByIdQuery : IRequest<GetBookDto>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
