using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class CategoryRepository : IReadAndDeleteRepository<Category>,ISaveAndUpdateRepository<Category,Category>
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dBContext.Category.ToList();
        }

        public Category GetById(Guid id)
        {
            return _dBContext.Category.FirstOrDefault(x => x.Id == id);
        }

        public Category Save(Category data)
        {
            _dBContext.Category.Add(data);
            _dBContext.SaveChanges();
            return data;
        }

        public Category Update(Guid id, Category data)
        {
            var getValue = _dBContext.Category.FirstOrDefault((x => x.Id == id));
            if (getValue == null) return null;
            getValue.Name = data.Name;
            _dBContext.SaveChanges();
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = _dBContext.Category.FirstOrDefault((x => x.Id == id));
            if (getValue == null) return false;
            _dBContext.Remove(getValue);
            _dBContext.SaveChanges();
            return true;
        }
    }
}