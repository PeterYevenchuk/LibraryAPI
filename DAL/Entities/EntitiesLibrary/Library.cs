using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities.EntitiesLibrary
{
    public class Library
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Schedule { get; set; }
        [MaybeNull]
        public virtual Contact Contact { get; set; }

    }
}
