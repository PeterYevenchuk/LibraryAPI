using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    public class PublicationService : IService<Publication>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Publication> Get()
        {
            try
            {
                return _unitOfWork.Publications.Get().Result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Publication? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Publications.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Publication publication)
        {
            try
            {
                _unitOfWork.Publications.Insert(publication);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Publication publication)
        {
            try
            {
                _unitOfWork.Publications.Update(publication);
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
