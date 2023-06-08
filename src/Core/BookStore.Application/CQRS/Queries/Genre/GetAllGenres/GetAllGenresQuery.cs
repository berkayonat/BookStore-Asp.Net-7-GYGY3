using BookStore.Application.DTOs.Genre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Genre.GetAllGenres
{
    public class GetAllGenresQuery : IRequest<IEnumerable<GetAllGenresDto>>
    {
    }
}
