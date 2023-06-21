using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    public class AuthorService : IService<Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Author? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Authors.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public List<Author> Get()
        {
            try
            {
                return _unitOfWork.Authors.Get().Result.ToList();
            }
            catch
            {
                return new List<Author>();
            }
        }

        public bool Insert(Author author)
        {
            try
            {
                _unitOfWork.Authors.Insert(author);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Author author)
        {
            try
            {
                _unitOfWork.Authors.Update(author);
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
            try
            {
                _unitOfWork.Authors.Delete(id);
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
