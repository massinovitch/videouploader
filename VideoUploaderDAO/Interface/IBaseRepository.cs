using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploader;

namespace VideoUploader.DAO
{
    public interface IBaseRepository<T,U>
    {
        void Create(T entity);
        void Update(T entity);
        void DeleteAll();
        void Delete(T entity);
        T FindById(int id);
        List<T> FindByCriteria(U criteria);
        List<T> GetList();
    }
}
