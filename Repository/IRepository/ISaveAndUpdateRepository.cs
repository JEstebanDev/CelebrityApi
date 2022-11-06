using System;

namespace CelebrityAPI.Repository.IRepository
{
    public interface ISaveAndUpdateRepository<out T, in TL> where T : class
    {
        T Save(TL data);
        T Update(Guid id, TL data);
    }
}
