using Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Course.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("CourseConnectionString")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Cursus> Cursus { get; set; }
        public DbSet<CursusInstantie> CursusInstantie { get; set; }
    }
}