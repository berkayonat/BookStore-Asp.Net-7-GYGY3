﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.CQRS.Commands.Book.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteBookCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
