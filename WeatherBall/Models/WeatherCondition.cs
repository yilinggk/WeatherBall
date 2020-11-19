using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherBall.Models
{
    public class WeatherCondition
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class WeatherRecord
    {
        [JsonPropertyName("weather")]
        public WeatherCondition[] Weather { get; set; }
    }
}
