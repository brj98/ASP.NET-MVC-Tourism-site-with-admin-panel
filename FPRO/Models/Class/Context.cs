using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FPRO.Models.Class
{
    public class Context : DbContext
    {
       
        public DbSet <Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Restoranlar> Restoranlar { get; set; }
        public DbSet<Oteller> Oteller { get; set; }
        public DbSet<Uyeler> Uyeler { get; set; }




    }
}