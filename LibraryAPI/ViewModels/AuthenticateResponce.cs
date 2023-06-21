using System.Text.Json.Serialization;

namespace LibraryAPI.ViewModels;

public class AuthenticateResponce
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    [JsonPropertyName("user")]
    public UserViewModel UserViewModel { get; set; } = null!;
}
