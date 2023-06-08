﻿using AutoMapper;
using BookStore.Application.CQRS.Commands.Book.CreateBook;
using BookStore.Application.DTOs.Author;
using BookStore.Application.DTOs.Book;
using BookStore.Application.DTOs.Genre;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, GetAllBooksDto>().ReverseMap();
            CreateMap<Author, GetAllAuthorsDto>().ReverseMap();
            CreateMap<Genre, GetAllGenresDto>().ReverseMap();
            CreateMap<CreateBookCommand, Book>().ReverseMap();
        }
    }
}
