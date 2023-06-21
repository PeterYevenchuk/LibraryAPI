using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;

namespace DAL.Extentions
{
    public class ContactService : IService<Contact>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Guid id)
        {
            try
            {
                _unitOfWork.Contacts.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Contact> Get()
        {
            try
            {
                return _unitOfWork.Contacts.Get().Result.ToList();
            }
            catch
            {
                return new List<Contact>();
            }
        }

        public Contact? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.Contacts.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Contact entity)
        {
            try
            {
                _unitOfWork.Contacts.Insert(entity);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Contact entity)
        {
            try
            {
                _unitOfWork.Contacts.Update(entity);
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
