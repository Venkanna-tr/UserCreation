using MediatR;
using MessWala.Application.Restaurant.Model;
using MessWala.Application.Restaurant.Queries.GetRestaurantsList;
using MessWala.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessWala.Application.Restaurant.Queries
{
    public class GetRestaurantListQueryHandler : IRequestHandler<GetRestaurantListQuery, RestaurantsListViewModel>
    {
        private readonly SampleDbContext context;

        public GetRestaurantListQueryHandler(SampleDbContext context)
        {
            this.context = context;
        }

        public async Task<RestaurantsListViewModel> Handle(GetRestaurantListQuery request, CancellationToken cancellationToken)
        {

            var model = new RestaurantsListViewModel
            {
                Restaurants = await context.Restaurants
                .Select(RestaurantDto.Projection).Where(a => a.Name.Contains(request.SearchFilter))
                .ToListAsync(cancellationToken)
            };
            return model;
        }
    }
}

