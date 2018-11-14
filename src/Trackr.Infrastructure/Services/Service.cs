using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trackr.Infrastructure.Data;

namespace Trackr.Infrastructure.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Service(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TEntity Get<Type>(Type id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Type id)
        {
            _dbContext.Set<TEntity>().Remove(Get(id));
            _dbContext.SaveChanges();
        }
    }
}
