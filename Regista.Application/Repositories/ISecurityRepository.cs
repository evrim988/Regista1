using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface ISecurityRepository 
    {
       Task<User> Login(string username, string password);
    }
}
