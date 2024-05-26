using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantService) : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantService.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await restaurantService.GetRestaurantById(id);

            return restaurant is not null ? Ok(restaurant) : NotFound(restaurant);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = await restaurantService.Create(createRestaurantsDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}