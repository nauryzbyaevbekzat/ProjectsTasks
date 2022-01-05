using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAkvelon.Models;

namespace TestAkvelon

{   //To interact with the database through the Entity Framework, 
    //we need a data context - a class inherited from the Microsoft.EntityFrameworkCore.DbContext class.
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects  { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // create the database on the first call
        }
    }
}
