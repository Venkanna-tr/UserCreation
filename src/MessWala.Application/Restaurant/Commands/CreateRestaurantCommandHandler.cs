using MediatR;
using MessWala.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MessWala.Application.Restaurant.Commands
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, CommandResult>
    {
        private readonly SampleDbContext context;

        public CreateRestaurantCommandHandler(SampleDbContext context)
        {
            this.context = context;
        }

        public async Task<CommandResult> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            context.Restaurants.Add(new Data.Restaurant() { Name = request.Name });
            var dbRes = await context.SaveChangesAsync(cancellationToken);
            CommandResult res = new CommandResult() { ObjectId = dbRes, Successful = true };
            return await Task.FromResult(res);
        }

    }
}
