using System;
using CelebrityAPI.Model.DTO;

namespace CelebrityAPI.Repository.IRepository
{
    public interface ISaveCelebrityRepository
    {
        CelebrityResponse Save(CelebrityDto data);
        CelebrityResponse Update(Guid id, CelebrityDto data);
    }
}
