using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;

namespace DAL.Extentions
{
    internal class LibraryItemService : IService<LibraryItem>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Guid id)
        {
            try
            {
                _unitOfWork.LibraryItems.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<LibraryItem> Get()
        {
            try
            {
                return _unitOfWork.LibraryItems.Get().Result.ToList();

            }
            catch
            {
                return new List<LibraryItem>();
            }

        }

        public LibraryItem? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.LibraryItems.GetByID(id).Result;

            }
            catch
            {
                return null;
            }
        }

        public bool Insert(LibraryItem entity)
        {
            try
            {
                _unitOfWork.LibraryItems.Insert(entity);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(LibraryItem entity)
        {
            try
            {
                _unitOfWork.LibraryItems.Update(entity);
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
