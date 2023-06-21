using DAL.Entities.EntitiesLibrary;
using DAL.Entities.EntitiesPublicationItem;
using Microsoft.EntityFrameworkCore;

namespace DAL
{

    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublicationItem>().UseTphMappingStrategy();
            modelBuilder.Entity<Book>().UseTphMappingStrategy();
            modelBuilder.Entity<EBook>().UseTphMappingStrategy();
            modelBuilder.Entity<Journal>().UseTphMappingStrategy();
            modelBuilder.Entity<Publication>().UseTphMappingStrategy();
        }

        public DbSet<PublicationItem> PublicationItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<EBook> Ebooks { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<SeasonTicket> SeasonTickets { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}