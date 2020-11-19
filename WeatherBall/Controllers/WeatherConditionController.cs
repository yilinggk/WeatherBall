using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherBall.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

namespace WeatherBall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherConditionController : ControllerBase
    {
        private readonly ILogger<WeatherConditionController> _logger;
        const string uri = "http://api.openweathermap.org/data/2.5/";
        const string apiKey = "3e4a7ae796b3f41ae36818449149f244";

        public WeatherConditionController(ILogger<WeatherConditionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherCondition> GetWeather()
        {
            string uriParameters = $"weather?q=vancouver,bc,can&appid=3e4a7ae796b3f41ae36818449149f244&units=metric";
            var res = APICall.RunAsync<WeatherRecord>(uri, uriParameters).GetAwaiter().GetResult();

            var weatherConditions = res.Weather;
            return weatherConditions;
        }
    }
}
