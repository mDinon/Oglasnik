using Oglasnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Oglasnik.DAL.Repository
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(OglasnikDbContext context) : base(context)
        {
        }

        public List<Category> GetList()
        {
            return this.DbContext.Categories
                .OrderBy(c => c.Name)
                .ToList();
        }

        public override Category Find(int id)
        {
            return this.DbContext.Categories
                .Where(c => c.ID == id)
                .FirstOrDefault();
        }
    }
}
