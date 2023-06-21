using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;

namespace BLL.Services.UserFinderService;

public class UserFinderService : IUserFinderService
{
    private readonly IUnitOfWork _database;
    private readonly IService<Visitor> _visitorService;
    private readonly IService<Manager> _managerService;
    private readonly IService<Admin> _adminService;

    public UserFinderService(IService<Manager> managerService, IService<Admin> adminService, IService<Visitor> visitorService)
    {
        _visitorService = visitorService;
        _managerService = managerService;
        _adminService = adminService;
    }

    public UserDto? FindUserWithLogin(string login)
    {
        UserDto? userDto = GetAdminByLogin(login);
        if (userDto is not null)
        {
            return userDto;
        }

        userDto = GetManagerByLogin(login);
        if (userDto is not null)
        {
            return userDto;
        }

        userDto = GetVisitorByLogin(login);
        if (userDto is not null)
        {
            return userDto;
        }

        return userDto;
    }

    private UserDto? GetAdminByLogin(string login)
    {
        UserDto? userDto = null!;

        var userAdmin = _adminService.Get().FirstOrDefault(user => user.Login == login);

        if (userAdmin != null)
        {
            userDto = new()
            {
                Login = login,
                Password = userAdmin.Password,
                Role = "Admin",
                Name = userAdmin.Name
            };
        }

        return userDto;
    }

    private UserDto? GetManagerByLogin(string login)
    {
        UserDto? userDto = null!;

        var userManager= _managerService.Get().FirstOrDefault(user => user.Login == login);

        if (userManager != null)
        {
            userDto = new()
            {
                Login = login,
                Password = userManager.Password,
                Role = "Manager",
                Name = userManager.Name
            };
        }

        return userDto;
    }

    private UserDto? GetVisitorByLogin(string login)
    {
        UserDto? userDto = null!;
      
        var userVisitor = _visitorService.Get().FirstOrDefault(user => user.Login == login);
        if (userVisitor != null)
        {
            userDto = new()
            {
                Login = login,
                Password = userVisitor.Password,
                Role = "Visitor",
                Name = userVisitor.Name
            };
        }

        return userDto;
    }

}
