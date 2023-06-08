using BookStore.Application.DTOs.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Author.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<GetAllAuthorsDto>>
    {
    }
}
