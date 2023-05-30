using Regista.Application.Repositories;
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
        public UnitOfWork(RegistaContext _context)
        {
            context = _context;
        }

        private IRepository _repository;
        public IRepository Repository
        {
            get => _repository ?? (_repository = new Repository(context,session));
        }
        private ICustomerRepository _customerrepository;
        public ICustomerRepository customerRepository
        {
            get => _customerrepository ?? (_customerrepository = new CustomerRepository(context,session,this));
        }
        private IUserRepository _userRepository;
        public IUserRepository userRepository
        {
            get => _userRepository ?? (_userRepository = new UserRepository(context,session ,this));
        }

        public IRepository repository => throw new NotImplementedException();


        public IRequestRepository _requestRepository;
        public IRequestRepository requestRepository
        {
            get => _requestRepository ?? (_requestRepository = new RequestRepository(context,session,this));
        }

        public IProjectRepository _projectRepository;
        public IProjectRepository projectRepository
        {
            get => _projectRepository ?? (_projectRepository = new ProjectRepository(context,session, this));
        }
        public IProjectNoteRepository _projectNoteRepository;
        public IProjectNoteRepository projectNoteRepository
        {
            get => _projectNoteRepository ?? (_projectNoteRepository = new ProjectNoteRepository(context,session, this));
        }
       
        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task<int> IUnitOfWork.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
