using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientWeb.Models;

namespace ClientWeb.Data
{
    public class ApplicationDbConttext:DbContext
    {
        public ApplicationDbConttext(DbContextOptions<ApplicationDbConttext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> People { get; set; }

        public DbSet<ClientWeb.Models.Prefecture> Prefecture { get; set; }
    }
}
