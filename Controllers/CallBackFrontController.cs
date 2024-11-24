using Microsoft.AspNetCore.Mvc;

namespace BackForFrontVue2.Controllers
{
    [ApiController]
    [Route("CallBackFront")]
    public class CallBackFrontController : Controller
    {
        [HttpGet]
        public IActionResult GetWeather()
        {
            var weather = new { Temp = 20, Condition = "Sunny" };
            return Ok(weather);
        }

        [HttpPost]
        public IActionResult PostWeather([FromBody] WeatherRequest request)
        {
            return Ok(new { Message = "Weather updated", Data = request });
        }
    }

    public class WeatherRequest
    {
        public int Temp { get; set; }
        public string Condition { get; set; }
    }
}