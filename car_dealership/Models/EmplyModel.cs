using System.Text.Json.Serialization;

namespace car_dealership.Models
{
    public class EmplyModel
    {
        [JsonPropertyName("emply_id")]
        public int? EmplyID { get; set; }
        [JsonPropertyName("initial")]
        public string? Initial { get; set; }
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        [JsonPropertyName("emply_type")]
        public string? Type { get; set; }
        


    }
}
