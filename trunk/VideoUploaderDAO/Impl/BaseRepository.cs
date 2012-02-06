using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploader.DAO;
using System.Linq.Expressions;

namespace VideoUploader
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {

        public abstract void Create(T entity);

        public abstract void DeleteAll();

        public abstract void Delete(T entity);

        public abstract T FindById(int id);

        public abstract List<T> FindByCriteria(T criteria);
        
        public abstract List<T> GetList();

    }
}
