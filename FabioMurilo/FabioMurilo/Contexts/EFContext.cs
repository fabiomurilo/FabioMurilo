using FabioMurilo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FabioMurilo.Contexts
{
    public class EFContext : DbContext
    {
        #region [ DbSet Properties ]

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }


        public EFContext() : base("Asp_Net_MVC_CS")
        {
            
        }

        #endregion
    }
}