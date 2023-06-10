using BookStore.Application.Interfaces;
using BookStore.Domain;
using BookStore.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class EFBookRepository : EFGenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        public EFBookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksByGenreWithInclude(int? id)
        {
            return await _context.Books.Include(a => a.Authors).Include(a => a.Genre)
                .Include(a => a.Publisher).AsNoTracking().Where(b => b.GenreId == id).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksWithInclude()
        {
            return await _context.Books.Include(a => a.Authors).Include(a => a.Genre)
                .Include(a => a.Publisher).ToListAsync();
        }

        public async Task<Book?> GetBookByIdWithInclude(int id)
        {
            return await _context.Books.Include(a => a.Genre).Include(a => a.Authors)
                .Include(a => a.Publisher).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
