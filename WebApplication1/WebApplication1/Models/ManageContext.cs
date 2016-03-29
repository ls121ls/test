using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Model;

namespace WebApplication1.Models
{
    public class ManageContext:DbContext
    {
        public DbSet<entry> Entries { get; set; }
        public DbSet<Article> Articles { get; set; }

        public ManageContext() : base("SqliteTest")
        {
            
        }
    }
}