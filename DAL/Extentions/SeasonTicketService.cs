using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;

namespace DAL.Extentions
{
    namespace DAL.Extentions
    {
        public class SeasonTicketService : IService<SeasonTicket>
        {
            private readonly IUnitOfWork _unitOfWork;

            public SeasonTicketService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public bool Delete(Guid id)
            {
                try
                {
                    _unitOfWork.SeasonTickets.Delete(id);
                    _unitOfWork.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public SeasonTicket? GetById(Guid id)
            {
                try
                {
                    return _unitOfWork.SeasonTickets.GetByID(id).Result;
                }
                catch
                {
                    return null;
                }
            }

            public List<SeasonTicket> Get()
            {
                try
                {
                    return _unitOfWork.SeasonTickets.Get().Result.ToList();
                }
                catch
                {
                    return null;
                }
            }

            public bool Insert(SeasonTicket seasonTicket)
            {
                try
                {
                    _unitOfWork.SeasonTickets.Insert(seasonTicket);
                    _unitOfWork.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public bool Update(SeasonTicket seasonTicket)
            {
                try
                {
                    _unitOfWork.SeasonTickets.Update(seasonTicket);
                    _unitOfWork.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            private Guid ToGuid(int value)
            {
                return new Guid(value, 0, 0, new byte[8]);
            }
        }
    }

}
