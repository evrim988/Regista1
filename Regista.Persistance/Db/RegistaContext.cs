using Microsoft.EntityFrameworkCore;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Persistance.Db
{
    public class RegistaContext : DbContext
    {
        public RegistaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ProjectNote> projectNotes { get; set; } 
        public DbSet<Request> requests { get; set; }
    }
}
