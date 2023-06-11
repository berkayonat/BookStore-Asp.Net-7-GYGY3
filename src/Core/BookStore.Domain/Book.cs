using BookStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Book : BaseEntity
    {
        public Book() 
        {
            this.Authors = new HashSet<Author>();
        }   
        public string Title { get; set; } 
        public string? Description { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? ImageUrl { get; set; } = "https://picsum.photos/200/300";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; } = false;

        public Publisher? Publisher { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<Author>? Authors { get; set; }
    }
}
