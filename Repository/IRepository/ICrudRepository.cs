using System;
using System.Collections.Generic;

namespace CelebrityAPI.Repository.IRepository
{
    public interface ICrudRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Save(T data);
        T Update(Guid id,T data);
        Boolean DeleteById(Guid id);
    }
}
