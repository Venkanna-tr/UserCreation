using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessWala.Application.Restaurant.Commands
{
    public class CreateRestaurantCommand : IRequest<CommandResult>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
