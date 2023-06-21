using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Db
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext libraryContext;

        private Repository<Book> bookRepository;
        private Repository<Journal> journalRepository;
        private Repository<Visitor> visitorRepository;
        private Repository<Author> authorRepository;
        private Repository<EBook> ebookRepository;
        private Repository<Publication> publicationRepository;
        private Repository<Publisher> publisherRepository;
        private Repository<Review> reviewRepository;
        private Repository<Tag> tagRepository;
        private Repository<Address> addresseRepository;
        private Repository<Admin> adminRepository;
        private Repository<Contact> contactRepository;
        private Repository<Library> librarieRepository;
        private Repository<Manager> managerRepository;
        private Repository<SeasonTicket> seasonTicketRepository;
        private Repository<LibraryItem> libraryItemRepository;

        public UnitOfWork(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public Repository<LibraryItem> LibraryItems
        {
            get
            {
                if (libraryItemRepository == null)
                {
                    libraryItemRepository = new Repository<LibraryItem>(libraryContext);
                }
                return libraryItemRepository;
            }
        }

        public Repository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new Repository<Book>(libraryContext);
                }
                return bookRepository;
            }
        }

        public Repository<Journal> JournalRepository
        {
            get
            {
                if (journalRepository == null)
                {
                    journalRepository = new Repository<Journal>(libraryContext);
                }
                return journalRepository;
            }
        }

        public Repository<Visitor> VisitorRepository
        {
            get
            {
                if (visitorRepository == null)
                {
                    visitorRepository = new Repository<Visitor>(libraryContext);
                }
                return visitorRepository;
            }
        }

        public Repository<Author> Authors
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new Repository<Author>(libraryContext);
                }
                return authorRepository;
            }
        }

        public Repository<EBook> Ebooks
        {
            get
            {
                if (ebookRepository == null)
                {
                    ebookRepository = new Repository<EBook>(libraryContext);
                }
                return ebookRepository;
            }
        }

        public Repository<Publication> Publications
        {
            get
            {
                if (publicationRepository == null)
                {
                    publicationRepository = new Repository<Publication>(libraryContext);
                }
                return publicationRepository;
            }
        }

        public Repository<Publisher> Publishers
        {
            get
            {
                if (publisherRepository == null)
                {
                    publisherRepository = new Repository<Publisher>(libraryContext);
                }
                return publisherRepository;
            }
        }

        public Repository<Review> Reviews
        {
            get
            {
                if (reviewRepository == null)
                {
                    reviewRepository = new Repository<Review>(libraryContext);
                }
                return reviewRepository;
            }
        }

        public Repository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                {
                    tagRepository = new Repository<Tag>(libraryContext);
                }
                return tagRepository;
            }
        }

        public Repository<Address> Addresses
        {
            get
            {
                if (addresseRepository == null)
                {
                    addresseRepository = new Repository<Address>(libraryContext);
                }
                return addresseRepository;
            }
        }

        public Repository<Admin> Admins
        {
            get
            {
                if (adminRepository == null)
                {
                    adminRepository = new Repository<Admin>(libraryContext);
                }
                return adminRepository;
            }
        }

        public Repository<Contact> Contacts
        {
            get
            {
                if (contactRepository == null)
                {
                    contactRepository = new Repository<Contact>(libraryContext);
                }
                return contactRepository;
            }
        }

        public Repository<Library> Libraries
        {
            get
            {
                if (librarieRepository == null)
                {
                    librarieRepository = new Repository<Library>(libraryContext);
                }
                return librarieRepository;
            }
        }

        public Repository<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                {
                    managerRepository = new Repository<Manager>(libraryContext);
                }
                return managerRepository;
            }
        }

        public Repository<SeasonTicket> SeasonTickets
        {
            get
            {
                if (seasonTicketRepository == null)
                {
                    seasonTicketRepository = new Repository<SeasonTicket>(libraryContext);
                }
                return seasonTicketRepository;
            }
        }

        public void Save()
        {
            libraryContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    libraryContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}