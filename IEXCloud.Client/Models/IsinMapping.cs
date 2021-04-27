using System.Text.Json.Serialization;

namespace IEXCloud.Client
{
    public class IsinMapping
    {
        [JsonPropertyName("symbol")]        
        public string Symbol { get; set; } = null!;

        [JsonPropertyName("exchange")]  
        public string Exchange { get; set; } = null!;
        
        [JsonPropertyName("region")]  
        public string Region { get; set; } = null!;
    }
}