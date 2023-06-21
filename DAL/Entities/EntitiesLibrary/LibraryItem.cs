using DAL.Entities.EntitiesPublicationItem;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities.EntitiesLibrary
{
    public class LibraryItem
    {
        public Guid ID { get; set; }
        public DateTime IssuanceDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DeadLine { get; set; }
        [MaybeNull]
        public virtual PublicationItem PublicationItem { get; set; }
    }
}
