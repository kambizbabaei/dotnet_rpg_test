using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IRepository;
using pr.Data;
using pr.Models.baseClass;

namespace pr.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : entity
    {
        public readonly DataContext Db;
        public readonly ILogger Logger;
        public readonly DbSet<T> dbset;
        public GenericRepository(DataContext Db, ILogger logger, DbSet<T> dbset)
        {
            this.dbset = dbset;
            this.Logger = logger;
            this.Db = Db;
        }
        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                T existing = await Find(entity.Id);
                if (existing == null)
                {
                    await dbset.AddAsync(entity);
                    return true;
                }
                Logger.LogError(string.Format("{0} exists", typeof(T)));
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{Repo} Add error", typeof(GenericRepository<T>));
                return false;
            }
        }
        public virtual async Task<IEnumerable<T>> All()
        {
            try
            {
                return await dbset.ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{} all method error", typeof(T));
                return new List<T>();
            }

        }
        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                T entity = await this.Find(id);
                if (entity == null)
                {
                    Logger.LogError(string.Format("{} entity not found", typeof(T)));
                    return false;
                }
                dbset.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{} delete method error", typeof(T));
                return false;
            }
        }
        public virtual async Task<T> Find(int id)
        {
            try
            {
                return await dbset.FindAsync(id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{} find method error", typeof(T));
                return null;
            }
        }
        public virtual Task<bool> Upsert(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}