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
using Microsoft.Extensions.Configuration;

namespace WeatherBall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherConditionController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly ILogger<WeatherConditionController> _logger;
        const string uri = "http://api.openweathermap.org/data/2.5/";

        public WeatherConditionController(IConfiguration config, ILogger<WeatherConditionController> logger)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public IEnumerable<WeatherCondition> GetWeather()
        {
            string apiKey = _config.GetValue<string>("WeatherKey");
            Console.WriteLine(apiKey);
            string uriParameters = $"weather?q=vancouver,bc,can&appid={apiKey}&units=metric";
            var res = APICall.RunAsync<WeatherRecord>(uri, uriParameters).GetAwaiter().GetResult();

            var weatherConditions = res.Weather;
            return weatherConditions;
        }
    }
}
