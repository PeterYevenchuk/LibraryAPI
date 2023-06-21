using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;

namespace DAL.Extentions
{
    public class VisitorService : IService<Visitor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public bool Delete(Guid id)
        {
            try
            {
                _unitOfWork.VisitorRepository.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public VisitorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Visitor? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.VisitorRepository.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public List<Visitor> Get()
        {

            try
            {
                return _unitOfWork.VisitorRepository.Get().Result.ToList();
            }
            catch
            {
                return new List<Visitor>();
            }

        }

        public bool Insert(Visitor visitor)
        {

            try
            {
                _unitOfWork.VisitorRepository.Insert(visitor);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Update(Visitor visitor)
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
