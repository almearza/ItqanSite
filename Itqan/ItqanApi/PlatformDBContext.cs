using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Itqan.ItqanApi
{
    public class PlatformDBContext : DbContext
    {
        public DbSet<Tutorial> Tutorials { get; set; }
        public PlatformDBContext()
             : base("QuranEdu")
        {

        }
    }
}