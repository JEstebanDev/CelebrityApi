using System;

namespace CelebrityAPI.Repository.IRepository
{
    public interface ISaveAndUpdateRepository<T> where T : class
    {
        T Save(T data);
        T Update(Guid id, T data);
    }
}
