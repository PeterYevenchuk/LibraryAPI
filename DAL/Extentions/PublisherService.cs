using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    internal class PublisherService : IService<Publisher>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublisherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Guid id)
        {
            try
            {
                _unitOfWork.Publishers.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Publisher> Get()
        {
            try
            {
                return _unitOfWork.Publishers.Get().Result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Publisher? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Publishers.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Publisher entity)
        {
            try
            {
                _unitOfWork.Publishers.Insert(entity);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Publisher entity)
        {
            try
            {
                _unitOfWork.Publishers.Update(entity);
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
