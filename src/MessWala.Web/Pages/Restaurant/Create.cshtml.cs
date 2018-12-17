using MediatR;
using MessWala.Application.Restaurant.Commands;
using MessWala.Application.Restaurant.Queries;
using MessWala.Application.Restaurant.Queries.GetRestaurantsList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
namespace MessWala.Web.Pages.Restaurant
{
    public class CreateModel : PageModel
    {
        private readonly IMediator mediatr;
        private readonly ILoggerFactory loggerFactory;

        [BindProperty]
        public CreateRestaurantCommand CreateRestaurant
        {
            get;
            set;
        }

        public CreateModel(IMediator mediatr, ILoggerFactory loggerFactory)
        {
            this.mediatr = mediatr;
            this.loggerFactory = loggerFactory;
        }

        public async Task OnGet([FromQuery(Name = "Query")]string query = "", [FromQuery(Name = "PageNumber")]int pageNumber = 1)
        {
            RestaurantsListViewModel vm = new RestaurantsListViewModel();

            var allRestsWithSearchFilter = await mediatr.Send(new GetRestaurantListQuery() { SearchFilter = query });
            var ar = allRestsWithSearchFilter;
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await mediatr.Send(CreateRestaurant);

            if (response.Errors.Any())
            {
                response.Errors.ToList().ForEach(a => ModelState.AddModelError(a.PropName, a.ErrorMessage));
                return Page();
            }
            return Page();
        }
    }
}