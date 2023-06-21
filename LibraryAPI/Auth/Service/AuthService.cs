using BLL.Helpers.PasswordHasher;
using BLL.Services.UserFinderService;
using LibraryAPI.Auth.Authentication;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Auth.Service;

public class AuthService : IAuthService
{
    private readonly ITokenFactory _tokenFactory;
    private readonly IPasswordHash _passwordHash;
    private readonly IUserFinderService _userService;

    public AuthService(
        ITokenFactory tokenFactory,
        IPasswordHash passwordHash,
        IUserFinderService userService)
    {
        _tokenFactory = tokenFactory;
        _passwordHash = passwordHash;
        _userService = userService;
    }

    public TokenModel CreateNewTokenModel(string userId, string userRole)
    {
        return new()
        {
            AccessToken = _tokenFactory.CreateJwtAccessToken(userId, userRole)
        };
    }

    public AuthenticateResponce AuthenticateUser(AuthenticationRequest request)
    {
        if (request is null)
        {
            throw new Exception("Access denied. Unresolved request from request body.");
        }

        UserDto user = _userService.FindUserWithLogin(request.Login)
           ?? throw new Exception("Access denied. Unresolved user login.");

        var incomingPasswordHash = _passwordHash.EncryptPassword(request.Password, user.Id.ToByteArray());

        if (incomingPasswordHash != user.Password)
        {
            throw new Exception("Access denied. Incorrect password.");
        }

        return new()
        {
            AccessToken = _tokenFactory.CreateJwtAccessToken(user.Id.ToString(), user.Role.ToString()),
            UserViewModel = new()
            {
                Login = user.Login,
                Role = user.Role.ToString(),
                Id = user.Id,
                Name = user.Name
            }
        };
    }
}
