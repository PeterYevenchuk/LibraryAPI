using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.EntityFrameworkCore;

namespace DAL.Extentions
{
    public class ManagerService : IService<Manager>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Manager> Get()
        {
            try
            {
                return _unitOfWork.Managers.Get().Result.ToList();
            }
            catch
            {
                return new List<Manager>();
            }
        }

        public bool Insert(Manager manager)
        {
            try
            {
                _unitOfWork.Managers.Insert(manager);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Manager? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Managers.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Manager entity)
        {
            try
            {
                _unitOfWork.Managers.Update(entity);
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