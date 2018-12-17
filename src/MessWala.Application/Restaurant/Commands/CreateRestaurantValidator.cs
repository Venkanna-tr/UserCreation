using FluentValidation;

namespace MessWala.Application.Restaurant.Commands
{
    public class CreateRestaurantValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
            RuleFor(x => x.City).MaximumLength(15);
        }
    }
}
