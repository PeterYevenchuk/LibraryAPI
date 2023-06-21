using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    internal class ReviewService : IService<Review>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Guid id)
        {
            try
            {
                _unitOfWork.Reviews.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Review> Get()
        {
            try
            {
                return _unitOfWork.Reviews.Get().Result.ToList();
            }
            catch
            {
                return new List<Review>();
            }
        }

        public Review? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Reviews.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Review entity)
        {
            try
            {
                _unitOfWork.Reviews.Insert(entity);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Review entity)
        {
            try
            {
                _unitOfWork.Reviews.Update(entity);
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
