using Oglasnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Oglasnik.DAL.Repository
{
    public class AdRepository : RepositoryBase<Ad>
    {
        public AdRepository(OglasnikDbContext context) : base(context)
        {
        }

        public List<Ad> GetList()
        {
            return this.DbContext.Ads
                .Include(a => a.Currency)
                .Include(a => a.Category)
                .OrderByDescending(a => a.ID)
                .ToList();
        }

        public List<Ad> GetList(string id)
        {
            return this.DbContext.Ads
                .Include(a => a.Currency)
                .Include(a => a.Category)
                .Where(a => a.User_ID == id)
                .OrderByDescending(a => a.ID)
                .ToList();
        }

        public List<Ad> GetList(IAdFilter model)
        {
            return this.DbContext.Ads
                .Include(a => a.Currency)
                .Include(a => a.Category)
                .Where(a => a.Category.Name.ToUpper().Contains(model.Kategorija.ToUpper()))
                .OrderByDescending(a => a.ID)
                .ToList();
        }

        public override Ad Find(int id)
        {
            return this.DbContext.Ads
                .Include(a => a.Currency)
                .Include(a => a.Category)
                .Where(a => a.ID == id)
                .FirstOrDefault();
        }
    }
}
