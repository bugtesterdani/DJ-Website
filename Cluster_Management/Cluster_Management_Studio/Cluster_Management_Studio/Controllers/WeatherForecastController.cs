using Microsoft.AspNetCore.Mvc;
using System;

namespace Cluster_Management_Studio.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            return Ok(rng.Next(10, 100));
        }
    }
}
