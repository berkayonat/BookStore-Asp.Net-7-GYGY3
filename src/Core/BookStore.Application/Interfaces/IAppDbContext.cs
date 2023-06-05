using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Author> Authors { get; }
        DbSet<Book> Books { get; }
        DbSet<Genre> Genres { get; }
        DbSet<Publisher> Publishers { get; }
    }
}
