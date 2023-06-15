using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using Task = Regista.Domain.Entities.Task;

namespace Regista.Infasctructure.Repositories
{
    public class HomeRepository : Repository, IHomeRepository
    {
        private readonly RegistaContext context;
        private readonly SessionModel session;
        private readonly IUnitOfWork uow;
        public HomeRepository(RegistaContext _context,SessionModel _session, IUnitOfWork _uow) : base(_context, _session)
        {
            context = _context;
            session = _session;
            uow = _uow;
        }
        public async Task<IQueryable<Task>> GetTaskHome()
        {
            try
            {
                var model = GetNonDeletedAndActive<Task>(t => t.ResponsibleID == session.ID);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
