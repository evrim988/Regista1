using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IUnitOfWork
    {
       IRepository repository { get; }
       ICustomerRepository customerRepository { get; }
       IUserRepository userRepository { get; }
       IProjectRepository projectRepository { get; }
       IProjectNoteRepository projectNoteRepository { get; }
       IRequestRepository requestRepository { get; }
       ITaskRepository taskRepository { get; }
       Task<int> SaveChanges();
       SessionModel GetSession();
    }
}
