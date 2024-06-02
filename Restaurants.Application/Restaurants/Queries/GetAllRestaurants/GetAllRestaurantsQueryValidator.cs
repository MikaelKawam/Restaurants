using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;
using System.Linq;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
    {
        private int[] allowPageSizes = [5, 10, 15, 20];
        private string[] allowedSortByColumnNames = [nameof(RestaurantDto.Name),
            nameof(RestaurantDto.Category),
            nameof(RestaurantDto.Description)];
        public GetAllRestaurantsQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .Must(value => allowPageSizes.Contains(value))
                .WithMessage($"Page size must be in [{string.Join(",", allowPageSizes)}]");

            RuleFor(x => x.SortBy)
                .Must(value => allowedSortByColumnNames.Contains(value))
                .When(q => q.SortBy != null)
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
