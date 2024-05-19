using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    [Route("/example")]
    public IEnumerable<WeatherForecast> Get() => _weatherForecastService.Get();

    [HttpPost("generate")]
    public ObjectResult  GetGenerate([FromQuery] int maxTemp, [FromQuery] int minTemp, [FromQuery] int qntResults)
    {
        if (minTemp > maxTemp || qntResults < 1) return BadRequest("Invalid params.");

        return Ok(_weatherForecastService.GetGenerate(maxTemp, minTemp, qntResults));
    }


    [HttpGet("currentDay")]
    public WeatherForecast GetCurrentDayForecast() => _weatherForecastService.Get().First();

    [HttpPost]
    public string Hello([FromBody] string name) => $"Hello {name}";
}
