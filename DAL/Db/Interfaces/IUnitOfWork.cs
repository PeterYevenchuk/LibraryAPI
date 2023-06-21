using DAL.Entities.EntitiesLibrary;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Db.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Visitor> VisitorRepository { get; }
        Repository<Book> BookRepository { get; }
        Repository<Journal> JournalRepository { get; }
        Repository<Author> Authors { get; }
        Repository<EBook> Ebooks { get; }
        Repository<Publication> Publications { get; }
        Repository<Publisher> Publishers { get; }
        Repository<Review> Reviews { get; }
        Repository<Tag> Tags { get; }
        Repository<Address> Addresses { get; }
        Repository<Admin> Admins { get; }
        Repository<Contact> Contacts { get; }
        Repository<Library> Libraries { get; }
        Repository<Manager> Managers { get; }
        Repository<SeasonTicket> SeasonTickets { get; }
        Repository<LibraryItem> LibraryItems { get; }

        void Save();
    }
}
