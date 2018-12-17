using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MessWala.Application.Restaurant.Queries;
using MessWala.Application.Restaurant.Queries.GetRestaurantsList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MessWala.Web.Pages.Restaurant
{
    public class ListModel : PageModel
    {

        private readonly IMediator mediatr;
        private readonly ILoggerFactory loggerFactory;

        [BindProperty]
        public RestaurantsListViewModel RestaurantsList
        {
            get;
            set;
        }

        public ListModel(IMediator mediatr, ILoggerFactory loggerFactory)
        {
            this.mediatr = mediatr;
            this.loggerFactory = loggerFactory;
        }
        public async Task<IActionResult> OnGet([FromQuery(Name = "Query")]string query = "", [FromQuery(Name = "PageNumber")]int pageNumber = 1)
        {
            RestaurantsListViewModel vm = new RestaurantsListViewModel();
            RestaurantsList = await mediatr.Send(new GetRestaurantListQuery() { SearchFilter = query });
            return Page();
        }
    }
}