using BookStore.Application.Interfaces;
using BookStore.Domain;
using BookStore.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class EFBookRepository : EFGenericRepository<Book>, IBookRepository
    {
        public EFBookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
