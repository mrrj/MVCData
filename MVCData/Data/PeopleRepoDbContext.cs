using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;

namespace MVCData.Data
{
    public class PeopleRepoDbContext : DbContext
    {
        public PeopleRepoDbContext(DbContextOptions<PeopleRepoDbContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
        
        }

        public DbSet<Person> People { get; set; }

    }
}
