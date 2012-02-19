using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploader.DAO;
using System.Linq.Expressions;
using VideoUploaderModel;

namespace VideoUploader
{
    public abstract class BaseRepository<T,U> : IBaseRepository<T,U>
    {

        public abstract void Create(T entity);

        public void Update(T entity)
        {
            using (var context = new ModelContext())
            {
                context.SaveChanges();
            }
        }

        public abstract void DeleteAll();

        public abstract void Delete(T entity);

        public abstract T FindById(int id);

        public abstract List<T> FindByCriteria(U criteria);
        
        public abstract List<T> GetList();

    }
}
