using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;

namespace DAL.Extentions
{
    public class TagService : IService<Tag>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Tag? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> Get()
        {
            try
            {
                return _unitOfWork.Tags.Get().Result.ToList();
            }
            catch
            {
                return new List<Tag>();
            }
        }

        public bool Insert(Tag tag)
        {
            try
            {
                _unitOfWork.Tags.Insert(tag);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Tag entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}