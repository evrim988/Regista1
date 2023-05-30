using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly RegistaContext _context;
        public SecurityRepository(RegistaContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(t => (t.UserName == username || t.EMail == username) && t.password == password && t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == status.Active);
        }
    }
}
