namespace Restaurants.Domain.Entities
{
    public class Dish
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    
        public int RestaurantId { get; set; }
    }
}
