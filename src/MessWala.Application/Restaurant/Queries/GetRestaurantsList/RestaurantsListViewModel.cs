using MessWala.Application.Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessWala.Application.Restaurant.Queries.GetRestaurantsList
{
    public class RestaurantsListViewModel : CommandResult
    {
        public IList<RestaurantDto> Restaurants { get; set; }

    }
}
