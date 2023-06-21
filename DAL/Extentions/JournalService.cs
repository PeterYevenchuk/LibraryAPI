using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    public class JournalService : IService<Journal>
    {
        private readonly IUnitOfWork _unitOfWork;

        public JournalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Journal> Get()
        {
            try
            {
                return _unitOfWork.JournalRepository.Get().Result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Journal? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.JournalRepository.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Journal journal)
        {
            try
            {
                _unitOfWork.JournalRepository.Insert(journal);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Journal journal)
        {
            try
            {
                _unitOfWork.JournalRepository.Update(journal);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static Guid ToGuid(int value)
        {
            return new Guid(value, 0, 0, new byte[8]);
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
