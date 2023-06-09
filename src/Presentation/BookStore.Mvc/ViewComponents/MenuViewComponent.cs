using BookStore.Application.CQRS.Queries.Genre.GetAllGenres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Mvc.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public MenuViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = _mediator.Send(new GetAllGenresQuery());
            return View(await genres);
        }
    }
}
