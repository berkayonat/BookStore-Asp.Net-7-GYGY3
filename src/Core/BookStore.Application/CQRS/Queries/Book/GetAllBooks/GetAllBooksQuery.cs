using BookStore.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Book.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksDto>>
    {
    }
}
