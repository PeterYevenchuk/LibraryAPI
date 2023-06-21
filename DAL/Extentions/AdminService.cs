using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;

namespace DAL.Extentions
{
    public class AdminService : IService<Admin>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Guid id)
        {
            try
            {
                _unitOfWork.Admins.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Admin> Get()
        {
            try
            {
                return _unitOfWork.Admins.Get().Result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Admin? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Admins.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Admin entity)
        {
            try
            {
                _unitOfWork.Admins.Insert(entity);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Admin entity)
        {
            try
            {
                _unitOfWork.Admins.Update(entity);
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