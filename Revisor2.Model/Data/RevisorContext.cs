using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Data
{
    public class RevisorContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<RoomPerson> RoomPeople { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public RevisorContext() : base()
        {
            _ = Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder
                .UseSqlite("Data Source=D:\\Data\\Revisor.db");
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
