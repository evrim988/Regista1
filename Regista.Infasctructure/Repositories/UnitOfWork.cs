using Regista.Application.Repositories;
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

        public UnitOfWork(RegistaContext _context)
        {
            context = _context;
        }

        private IRepository _repository;
        public IRepository Repository
        {
            get => _repository ?? (_repository = new Repository(context));
        }
        private ICustomerRepository _customerrepository;
        public ICustomerRepository customerRepository
        {
            get => _customerrepository ?? (_customerrepository = new CustomerRepository(context,this));
        }
        private IUserRepository _userRepository;
        public IUserRepository userRepository
        {
            get => _userRepository ?? (_userRepository = new UserRepository(context, this));
        }

        public IRepository repository => throw new NotImplementedException();

       

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
