using DAL.Entities.EntitiesLibrary;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Db.Interfaces
{
    public interface IHistoryVisitorService
    {
        List<PublicationItem> GetHistoryVisitorByID(Guid id);
        bool UpdateHistoryVisitor(Visitor visitor);
    }
}
