using CelebrityAPI.Data;
using CelebrityAPI.Error;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class ProfessionRepository : IReadAndDeleteRepository<Profession>, ISaveAndUpdateRepository<Profession, Profession>
    {
        private readonly ApplicationDBContext _dBContext;

        public ProfessionRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<Profession> GetAll()
        {
            var listProfession = _dBContext.Profession.ToList();
            if (listProfession.Count == 0)
            {
                throw new AppException("There are not data");
            }
            if (listProfession == null)
            {
                throw new AppException("Error searching the data");
            }
            return listProfession;
        }

        public Profession GetById(Guid id)
        {
            var profession = _dBContext.Profession.FirstOrDefault(x => x.Id == id);
            if (profession == null)
            {
                throw new AppException("There are not user with id:" + id);
            }
            return profession;
        }

        public Profession Save(Profession data)
        {
            try
            {
                _dBContext.Profession.Add(data);
                _dBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
            return data;
        }

        public Profession Update(Guid id, Profession data)
        {
            try
            {
                var getValue = _dBContext.Profession.FirstOrDefault(x => x.Id == id);
                if (getValue == null) throw new AppException("There are not data with the id:" + id);
                getValue.Name = data.Name;
                _dBContext.SaveChanges();
                return getValue;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public bool DeleteById(Guid id)
        {
            try
            {
                var getValue = _dBContext.Profession.FirstOrDefault(x => x.Id == id);
                if (getValue == null) throw new AppException("There are not data with the id:" + id);
                _dBContext.Remove(getValue);
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }
    }
}
