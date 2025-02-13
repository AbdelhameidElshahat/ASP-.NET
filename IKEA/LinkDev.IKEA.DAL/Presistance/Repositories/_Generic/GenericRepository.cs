using LinkDev.IKEA.DAL.Entities;
using LinkDev.IKEA.DAL.Entities;
using LinkDev.IKEA.DAL.Presistance.Data;
using LinkDev.IKEA.DAL.Presistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Presistance.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    { 
            private readonly ApplicationDbContext _dbcontext;
            public GenericRepository(ApplicationDbContext dbContext) 
            {
                _dbcontext = dbContext;
            }
            public IEnumerable<T> GetAll(bool withAsNoTracking = true)
            {
                if (withAsNoTracking)
                {
                    return _dbcontext.Set<T>().Where(X=>!X.IsDeleted).AsNoTracking().ToList();
                }
                return _dbcontext.Set<T>().Where(X => !X.IsDeleted).ToList();
            }
            public IQueryable<T> GetAllAsIQueryable()
            {
                return _dbcontext.Set<T>();
            }
            public T? Get(int id)
            {
                return _dbcontext.Set<T>().Find(id); // Find method equal all lines below that search for an object local the in DataBase 
                /// var T = _dbcontext.Ts.Local.FirstOrDefault(D=>D.Id == id);
                /// if (T == null) {
                ///     _dbcontext.Ts.FirstOrDefault(D => D.Id == id);
                /// }
                /// return T;
            }
            public int Add(T entity)
            {
                _dbcontext.Set<T>().Add(entity);
                return _dbcontext.SaveChanges();
            }
            public int Update(T entity)
            {
                _dbcontext.Set<T>().Update(entity);
                return _dbcontext.SaveChanges();
            }

            public int Delete(T entity)
            {
                entity.IsDeleted = true;
                _dbcontext.Set<T>().Update(entity);
                return _dbcontext.SaveChanges();
            }
        }
}

