using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class ProfessionRepository : ICrudRepository<Profession>
    {
        private readonly ApplicationDBContext dBContext;

        public ProfessionRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<Profession> GetAll()
        {
            return dBContext.Profession.ToList();
        }

        public Profession GetById(Guid id)
        {
            return dBContext.Profession.FirstOrDefault(x => x.Id == id);
        }

        public Profession Save(Profession data)
        {
            dBContext.Profession.Add(data);
            dBContext.SaveChanges();
            return data;
        }

        public Profession Update(Guid id, Profession data)
        {
            var getValue = dBContext.Profession.FirstOrDefault(x => x.Id == id);
            if (getValue != null)
            {
                getValue.Name = data.Name;
                dBContext.SaveChanges();
            }
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = dBContext.Profession.FirstOrDefault(x => x.Id == id);
            dBContext.Remove(getValue);
            dBContext.SaveChanges();
            return getValue != null;
        }
    }
}
