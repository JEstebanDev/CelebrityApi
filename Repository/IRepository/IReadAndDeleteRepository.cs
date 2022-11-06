using System;
using System.Collections.Generic;

namespace CelebrityAPI.Repository.IRepository
{
    public interface IReadAndDeleteRepository<out T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        bool DeleteById(Guid id);
    }
}
