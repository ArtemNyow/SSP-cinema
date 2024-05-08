using Domain.Models;

namespace BLL.Interfaces
{
    public interface ISessionService : ICrud<Session>
    {
        public IQueryable<Session> GetByFilter(SessionFilterSearch filter);
    }
}
