namespace BLL.Services.UserFinderService;

public class UserDto
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Role { get; set; } = null!;
}
