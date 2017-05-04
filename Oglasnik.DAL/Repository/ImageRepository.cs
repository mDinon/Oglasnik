using Oglasnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Oglasnik.DAL.Repository
{
    public class ImageRepository : RepositoryBase<Image>
    {
        public ImageRepository(OglasnikDbContext context) : base(context)
        {
        }

        public List<Image> GetList()
        {
            return this.DbContext.Images
                .Include(i => i.Ad)
                .OrderBy(i => i.ID)
                .ToList();
        }

        public override Image Find(int id)
        {
            return this.DbContext.Images
                .Include(i => i.Ad)
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}
