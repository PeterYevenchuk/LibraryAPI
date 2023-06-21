using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    public class BookService : IService<Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Book> Get()
        {
            try
            {
                return _unitOfWork.BookRepository.Get().Result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Book? GetById(Guid id)
        {
            try
            {
                return _unitOfWork.BookRepository.GetByID(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Book book)
        {
            try
            {
                _unitOfWork.BookRepository.Insert(book);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Book book)
        {
            try
            {
                _unitOfWork.BookRepository.Update(book);
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
