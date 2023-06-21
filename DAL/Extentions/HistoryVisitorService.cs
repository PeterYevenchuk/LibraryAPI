using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    internal class HistoryVisitorService : IHistoryVisitorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HistoryVisitorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<PublicationItem> GetHistoryVisitorByID(Guid id)
        {
            try
            {
                return _unitOfWork.VisitorRepository.GetByID(id).Result.History.ToList();//.First(v => v.ID == visitorId).History.ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateHistoryVisitor(Visitor visitor)
        {
            try
            {
                _unitOfWork.VisitorRepository.Update(visitor);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
