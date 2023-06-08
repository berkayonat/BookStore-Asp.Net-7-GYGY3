using BookStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Genre : BaseEntity
    {
        public Genre() 
        {
            this.Books = new HashSet<Book>();
        }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; } = false;

        public ICollection<Book>? Books { get; set; }
    }
}
