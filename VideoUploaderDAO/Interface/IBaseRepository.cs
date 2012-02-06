using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploader;

namespace VideoUploader.DAO
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        void DeleteAll();
        void Delete(T entity);
        T FindById(int id);
        List<T> FindByCriteria(T criteria);
        List<T> GetList();
    }
}
