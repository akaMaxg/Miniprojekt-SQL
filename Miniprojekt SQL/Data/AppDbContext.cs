using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miniprojekt_SQL.Models;

namespace Miniprojekt_SQL.Data
{
    internal class AppDbContext : DbContext //Inherit DbContext class - part of EF Core (DB handler)
    {
        private readonly string connectionString; //Prevents unintentional modification to connection string

        public AppDbContext(string connectionString) //Constructor, a string parameter which sets the instance to the input string
        {
            this.connectionString = connectionString;
        }

        //Protected = accessible within class and derived classes
        //Onconfiguring method is unspecified and therefore needs to be overridden
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Override inherited method OnConfiguring to take an object optionsbuilder. It is then used with UseNpgSql method with connectionstring parameter
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        // Models that represent database tables, set as Dbset to allow for CRUD
        public DbSet<Project> Project { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<ProjectPerson> ProjectPerson { get; set; }
    }
}
