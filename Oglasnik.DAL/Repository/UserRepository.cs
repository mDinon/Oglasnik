using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Oglasnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Repository
{
    public class UserRepository
    {
        protected OglasnikDbContext DbContext { get; }
        public UserRepository(OglasnikDbContext context)
        {
            this.DbContext = context;
        }

        public bool AssignToRole(string id, string role)
        {
            try
            {
                var roleStore = new RoleStore<IdentityRole>(this.DbContext);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<User>(this.DbContext);
                var userManager = new UserManager<User>(userStore);
                userManager.AddToRole(id, role);
                this.DbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
