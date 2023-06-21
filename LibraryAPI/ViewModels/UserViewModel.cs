using System.Text.Json.Serialization;

namespace LibraryAPI.ViewModels;    

public class UserViewModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("email")]
    public string Login { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("role")]
    public string Role { get; set; } = null!;
}
