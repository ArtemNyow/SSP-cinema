using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public List<Movie> Movies { get; set; } = new();
    }
}
