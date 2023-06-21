using LibraryAPI.ViewModels;

namespace LibraryAPI.Auth.Service;

public interface IAuthService
{
    public TokenModel CreateNewTokenModel(string userId, string userRole);
    public AuthenticateResponce AuthenticateUser(AuthenticationRequest request);
}
