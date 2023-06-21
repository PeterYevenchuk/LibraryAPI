using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities.EntitiesLibrary
{
    public class Contact
    {
        public Guid ID { get; set; }
        public string PhoneNumber { get; set; }
        [MaybeNull]
        public virtual Address Address { get; set; }
        public string URL { get; set; }
    }
}
