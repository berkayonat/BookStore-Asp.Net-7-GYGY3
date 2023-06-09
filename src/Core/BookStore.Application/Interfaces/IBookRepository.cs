﻿using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksWithInclude();
        Task<IEnumerable<Book>> GetAllBooksByGenreWithInclude(int? id);
        Task<Book?> GetBookByIdWithInclude(int id);
    }
}
