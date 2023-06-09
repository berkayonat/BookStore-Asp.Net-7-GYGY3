﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Commands.Book.CreateBook
{
    public class CreateBookCommand : IRequest
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; } = false;
        public IList<int>? AuthorIds { get; set; }
    }
}
