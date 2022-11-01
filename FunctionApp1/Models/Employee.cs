using System.Text.Json.Serialization;

namespace FunctionApp1.Models
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("gender")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Non
    }
}


    
