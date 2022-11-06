using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class ProfessionRepository : IReadAndDeleteRepository<Profession>, ISaveAndUpdateRepository<Profession,Profession>
    {
        private readonly ApplicationDBContext _dBContext;

        public ProfessionRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<Profession> GetAll()
        {
            return _dBContext.Profession.ToList();
        }

        public Profession GetById(Guid id)
        {
            return _dBContext.Profession.FirstOrDefault(x => x.Id == id);
        }

        public Profession Save(Profession data)
        {
            _dBContext.Profession.Add(data);
            _dBContext.SaveChanges();
            return data;
        }

        public Profession Update(Guid id, Profession data)
        {
            var getValue = _dBContext.Profession.FirstOrDefault(x => x.Id == id);
            if (getValue == null) return null;
            getValue.Name = data.Name;
            _dBContext.SaveChanges();
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = _dBContext.Profession.FirstOrDefault(x => x.Id == id);
            if (getValue == null) return false;
            _dBContext.Remove(getValue);
            _dBContext.SaveChanges();
            return true;
        }
    }
}
