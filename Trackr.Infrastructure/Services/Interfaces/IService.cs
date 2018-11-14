using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Get<Type>(Type id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Type id);
    }
}
