using BLL.Extentions;
using DAL.Extentions;
using LibraryAPI.Auth.Authentication;
using LibraryAPI.Auth.Service;
using LibraryAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// AddServices
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddBLLServices();
builder.Services.AddDALServices(configuration);
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenFactory, TokenFactory>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetJwtIssuer(),
        ValidAudience = builder.Configuration.GetJwtAudience(),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetJwtAccessKey())),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    //foreach (var permission in builder.Configuration.GetJwtPermissions())
    //{
    //    options.AddPolicy(permission, builder =>
    //        builder.AddRequirements(new RoleAuthorizationRequiment(permission)));
    //}
    options.AddPolicy("OnlyForAdmin", policy => {
        policy.RequireClaim(ClaimTypes.Role, "Admin");
    });
    options.AddPolicy("OnlyForManager", policy => {
        policy.RequireClaim(ClaimTypes.Role, "Manager");
    });
    options.AddPolicy("AdminOrManager", policy => {
        policy.RequireClaim(ClaimTypes.Role, "Manager", "Admin");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();