using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Oglasnik.Model;

namespace Oglasnik.DAL
{
    public class OglasnikDbContext : IdentityDbContext<User>
    {
        public OglasnikDbContext()
            : base("OglasnikDbContext", throwIfV1Schema: false)
        {
        }
        public static OglasnikDbContext Create()
        {
            return new OglasnikDbContext();
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdDetails> AdDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
}
}
