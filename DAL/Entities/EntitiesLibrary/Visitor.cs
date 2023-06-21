using DAL.Entities.EntitiesPublicationItem;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities.EntitiesLibrary
{
    public class Visitor
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [MaybeNull]
        public virtual Contact Contact { get; set; }
        [MaybeNull]
        public virtual IEnumerable<LibraryItem> ActiveLibraryItems { get; set; }
        [MaybeNull]
        public virtual IEnumerable<PublicationItem> History { get; set; }
        [MaybeNull]
        public virtual SeasonTicket SeasonTicket { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
