using Oglasnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Oglasnik.DAL.Repository
{
    public class CurrencyRepository : RepositoryBase<Currency>
    {
        public CurrencyRepository(OglasnikDbContext context) : base(context)
        {
        }

        public List<Currency> GetList()
        {
            return this.DbContext.Currencies
                .Include(c => c.Ads)
                .OrderBy(c => c.Name)
                .ToList();
        }

        public override Currency Find(int id)
        {
            return this.DbContext.Currencies
                .Include(c => c.Ads)
                .Where(c => c.ID == id)
                .FirstOrDefault();
        }
    }
}
