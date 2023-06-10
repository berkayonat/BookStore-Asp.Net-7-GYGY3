using BookStore.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Book.GetAllBooksByCategory
{
    public class GetAllBooksByGenreQuery : IRequest<IEnumerable<GetAllBooksDto>>
    {
        public int? Id { get; set; }

        public GetAllBooksByGenreQuery(int? id)
        {
            Id = id;
        }
    }
}
