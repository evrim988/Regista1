using Microsoft.EntityFrameworkCore;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Regista.Domain.Entities.Task;
using Version = Regista.Domain.Entities.Version;

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
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Domain.Entities.Action> Actions { get; set; }
        public DbSet<ProjectNote> ProjectNotes { get; set; } 
        public DbSet<Request> Requests { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<Version> Versions { get; set; }
    }
}
