using DAL.Db;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using DAL.Entities.EntitiesPublicationItem;
using DAL.Extentions.DAL.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extentions;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
    {
        //add another DAL services here
        services.AddDbContext<LibraryContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("ConnectionDb");
            options.UseSqlServer(connectionString);
        });

        LibraryContext libraryContext = services.BuildServiceProvider().GetRequiredService<LibraryContext>();
        libraryContext.Database.EnsureCreated();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IService<Visitor>, VisitorService>();      
        services.AddScoped<IHistoryVisitorService, HistoryVisitorService>();
        services.AddScoped<IService<Address>, AddressService>();
        services.AddScoped<IService<Book>, BookService>();
        services.AddScoped<IService<Journal>, JournalService>();
        services.AddScoped<IService<EBook>, EBookService>();
        services.AddScoped<IService<Publication>, PublicationService>();
        services.AddScoped<IService<Author>, AuthorService>();
        services.AddScoped<IService<SeasonTicket>, SeasonTicketService>();
        services.AddScoped<IService<Publisher>, PublisherService>();
        services.AddScoped<IService<Review>, ReviewService>();
        services.AddScoped<IService<Tag>, TagService>();
        services.AddScoped<IService<Manager>, ManagerService>();
        services.AddScoped<IService<Admin>, AdminService>();
        services.AddScoped<IService<Contact>, ContactService>();
        services.AddScoped<IService<LibraryItem>, LibraryItemService>();
        return services;
    }
}