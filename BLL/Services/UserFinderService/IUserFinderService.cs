namespace BLL.Services.UserFinderService;

public interface IUserFinderService
{
    public UserDto? FindUserWithLogin(string login);
}
