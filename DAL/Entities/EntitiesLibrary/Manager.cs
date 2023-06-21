using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities.EntitiesLibrary
{
    public class Manager
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [MaybeNull]
        public virtual Contact Contact { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
