using LibraryAPI.Auth.Authorization.Requirements;
using LibraryAPI.Auth.Service;
using LibraryAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LibraryAPI.Auth.Authorization.Handlers;

public class RoleAuthorizationHandler : AuthorizationHandler<RoleAuthorizationRequiment>
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IAuthService _authService;

    public RoleAuthorizationHandler(IConfiguration configuration, IHttpContextAccessor contextAccessor, IAuthService sensorsService)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
        _authService = sensorsService;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAuthorizationRequiment requirement)
    {
        if (context.User.Identity!.IsAuthenticated)
        {
            var role = context.User.FindFirst(ClaimTypes.Role)!.Value;
            var rolePermissions = _configuration.GetJwtPermissionsForRole(role);

            if (rolePermissions.Contains(requirement.Permission))
            {
                if (requirement.Permission == "user:self")
                {
                    if (IsResourceReadAuthorized(context))
                    {
                        context.Succeed(requirement);
                    }
                }
                else
                {
                    context.Succeed(requirement);
                }
            }
        }
        return Task.CompletedTask;
    }

    private bool IsResourceReadAuthorized(AuthorizationHandlerContext context)
    {
        var role = context.User.FindFirst(ClaimTypes.Role)?.Value;

        if (role == "Admin")
        {
            return true;
        }
        var routeData = _contextAccessor.HttpContext!.GetRouteData();

        if (routeData.Values.TryGetValue("Id", out object? routeId))
        {
            //var sensor = _authService.GetSensorById(routeId.ToString());

            //return context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value == sensor?.UserId;
        }
        return false;
    }
}
