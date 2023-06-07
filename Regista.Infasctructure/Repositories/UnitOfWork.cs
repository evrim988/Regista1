using Regista.Application.Repositories;
using Regista.Application.Services.SecurityServices;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Regista.Infasctructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegistaContext context;
        private readonly SessionModel session;
        public UnitOfWork(RegistaContext _context, ISessionService sessionService)
        {
            session = sessionService.GetInjection();
            context = _context;
        }

        private IRepository _repository;
        public IRepository repository
        {
            get => _repository ?? (_repository = new Repository(context, session));
        }

        private ICustomerRepository _customerRepository;
        public ICustomerRepository customerRepository
        {
            get => _customerRepository ?? (_customerRepository = new CustomerRepository(context, session,this));
        }

        private IUserRepository _userRepository;
        public IUserRepository userRepository
        {
            get => _userRepository ?? (_userRepository = new UserRepository(context, session, this));
        }
        private IProjectRepository _projectRepository;
        public IProjectRepository projectRepository
        {
            get => _projectRepository ?? (_projectRepository = new ProjectRepository(context, session, this));
        }

        private IProjectNoteRepository _projectNoteRepository;
        public IProjectNoteRepository projectNoteRepository
        {
            get => _projectNoteRepository ?? (_projectNoteRepository = new ProjectNoteRepository(context, session, this));
        }

        private IRequestRepository _requestRepository;
        public IRequestRepository requestRepository
        {
            get => _requestRepository ?? (_requestRepository = new RequestRepository(context, session, this));
        }

        private ITaskRepository _taskRepository;
        public ITaskRepository taskRepository
        {
            get => _taskRepository ?? (_taskRepository = new TaskRepository(context, session, this));
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public SessionModel GetSession()
        {
            try
            {
                return session;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
