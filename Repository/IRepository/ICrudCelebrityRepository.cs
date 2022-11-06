using System.Collections.Generic;
using System;
using CelebrityAPI.Model.DTO;

namespace CelebrityAPI.Repository.IRepository
{
    public interface ICrudCelebrityRepository
    {
        List<CelebrityResponse> GetAll();
        CelebrityResponse GetById(Guid id);
        CelebrityResponse Save(CelebrityDto data);
        CelebrityResponse Update(Guid id, CelebrityDto data);
        bool DeleteById(Guid id);
    }
}
