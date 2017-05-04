using Oglasnik.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Repository
{
    public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected OglasnikDbContext DbContext { get; }

        protected RepositoryBase(OglasnikDbContext context)
        {
            this.DbContext = context;
        }

        public virtual TEntity Find(int id)
        {
            return this.DbContext.Set<TEntity>()
                .Where(p => p.ID == id)
                .FirstOrDefault();
        }

        public bool Save()
        {
            try
            {
                this.DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Add(TEntity model, bool autoSave = false)
        {
            model.DateCreated = DateTime.Now;

            this.DbContext.Set<TEntity>().Add(model);

            if (autoSave)
                this.Save();
        }

        public void Update(TEntity model, bool autoSave = false)
        {
            model.DateModified = DateTime.Now;

            this.DbContext.Entry(model).State = EntityState.Modified;

            if (autoSave)
                this.Save();
        }

        public virtual bool Delete(int id, bool autoSave = false)
        {
            bool ok = false;
            var entity = this.DbContext.Set<TEntity>().Find(id);
            this.DbContext.Entry(entity).State = EntityState.Deleted;

            if (autoSave)
                ok = this.Save();
            return ok;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
