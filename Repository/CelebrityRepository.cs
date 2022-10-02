using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class CelebrityRepository : ICrudRepository<Celebrity>
    {
        private readonly ApplicationDBContext dBContext;

        public CelebrityRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<Celebrity> GetAll()
        {
            return dBContext.Celebrity.ToList();
        }

        public Celebrity GetById(Guid id)
        {
            return dBContext.Celebrity.FirstOrDefault(x => x.Id == id);
        }

        public Celebrity Save(Celebrity data)
        {
            dBContext.Celebrity.Add(data);
            dBContext.SaveChanges();
            return data;
        }

        public Celebrity Update(Guid id, Celebrity data)
        {
            var getValue = dBContext.Celebrity.FirstOrDefault(x => x.Id == id);
            if (getValue != null)
            {
                getValue.FullName = data.FullName;
                getValue.Age = data.Age;
                getValue.ImageURL = data.ImageURL;
                getValue.Country = data.Country;
                getValue.Category = data.Category;
                getValue.Profession = data.Profession;
                getValue.Birthday = data.Birthday;
                dBContext.SaveChanges();
            }
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = dBContext.Celebrity.FirstOrDefault(x => x.Id == id);
            dBContext.Remove(getValue);
            dBContext.SaveChanges();
            return getValue != null;
        }
    }
}
