using System.Text.Json.Serialization;

namespace Dometrain.EFCore.API.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    [JsonIgnore] //If we don't do that we will have a cycle object
    public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

}