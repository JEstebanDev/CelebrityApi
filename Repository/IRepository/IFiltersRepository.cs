using System;
using System.Collections.Generic;
using CelebrityAPI.Model.DTO;

namespace CelebrityAPI.Repository.IRepository
{
    public interface IFiltersRepository
    {
        public IEnumerable<CelebrityResponse> GetByCategory(Guid categoryId);
        public IEnumerable<CelebrityResponse> GetByProfession(Guid professionId);
    }
}
