using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    public class EBookService : IService<EBook>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EBook> Get()
        {
            try
            {
                return _unitOfWork.Ebooks.Get().Result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public EBook? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Ebooks.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(EBook eBook)
        {
            try
            {
                _unitOfWork.Ebooks.Insert(eBook);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(EBook eBook)
        {
            try
            {
                _unitOfWork.Ebooks.Update(eBook);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
