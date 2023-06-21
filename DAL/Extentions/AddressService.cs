using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;

namespace DAL.Extentions
{
    public class AddressService : IService<Address>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Guid id)
        {
            try
            {
                _unitOfWork.Addresses.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Address> Get()
        {
            try
            {
                return _unitOfWork.Addresses.Get().Result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Address? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Addresses.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Address address)
        {
            try
            {
                _unitOfWork.Addresses.Insert(address);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Address address)
        {
            try
            {
                _unitOfWork.Addresses.Update(address);
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