using LibraryAPI.ViewModels;

namespace LibraryAPI.Helpers;

public static class ConfigExtention
{
    public static string[] GetJwtPermissionsForRole(this IConfiguration configuration, string role)
    {
        return configuration.GetSection("RolePermissions")
            .Get<List<RolePermissions>>()!
            .Find(x => x.Role == role)!.Permissions;
    }
    public static string GetJwtAccessKey(this IConfiguration configuration) => configuration.GetSection("Jwt:AccessKey").Value!;
    public static string GetJwtIssuer(this IConfiguration configuration) => configuration.GetSection("Jwt:Issuer").Value!;
    public static string GetJwtAudience(this IConfiguration configuration) => configuration.GetSection("Jwt:Audience").Value!;
    public static string[] GetJwtPermissions(this IConfiguration configuration) => configuration.GetSection("JwtPermissions").Get<string[]>()!;
    public static string GetJwtInternalIssuer(this IConfiguration configuration) => configuration.GetSection("Jwt:InternalIssuer").Value!;
}
