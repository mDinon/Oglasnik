using Oglasnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Oglasnik.DAL.Repository
{
    public class AdDetailsRepository : RepositoryBase<AdDetails>
    {
        public AdDetailsRepository(OglasnikDbContext context) : base(context)
        {
        }

        public List<AdDetails> GetList()
        {
            return this.DbContext.AdDetails
                .Include(a => a.Ad)
                .OrderBy(a => a.ID)
                .ToList();
        }

        public override AdDetails Find(int id)
        {
            return this.DbContext.AdDetails
                .Include(a => a.Ad)
                .Where(a => a.ID == id)
                .FirstOrDefault();
        }

        public AdDetails Find(int id, bool isAd)
        {
            return this.DbContext.AdDetails
                .Include(a => a.Ad)
                .Where(a => a.Ad_ID == id)
                .FirstOrDefault();
        }

        public virtual bool Delete(int id, bool all, bool autoSave = false)
        {
            bool ok = false;
            var details = this.DbContext.AdDetails.Where(a => a.Ad_ID == id);
            this.DbContext.AdDetails.RemoveRange(details);

            if (autoSave)
                ok = this.Save();
            return ok;
        }
    }
}
