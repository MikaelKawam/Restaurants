using MediatR;

namespace Restaurants.Application.Dishes.DeleteDishes
{
    public class DeleteDishesForRestaurantCommand(int restaurantId) : IRequest
    {
        public int RestaurantId { get; } = restaurantId;
    }
}
