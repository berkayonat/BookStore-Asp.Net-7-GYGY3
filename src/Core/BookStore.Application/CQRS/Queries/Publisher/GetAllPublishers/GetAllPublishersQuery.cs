using BookStore.Application.DTOs.Publisher;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Publisher.GetAllPublishers
{
    public class GetAllPublishersQuery : IRequest<IEnumerable<GetAllPublishersDto>>
    {
    }
}
