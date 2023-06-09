using AutoMapper;
using BookStore.Application.DTOs.Genre;
using BookStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Queries.Genre.GetAllGenres
{
    public class GetAllGenresQueryHandler :IRequestHandler<GetAllGenresQuery, IEnumerable<GetAllGenresDto>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetAllGenresQueryHandler(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<GetAllGenresDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllGenresDto>>(genres);
        }
    }
}

