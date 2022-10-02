using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class CategoryRepository : ICrudRepository<Category>
    {
        private readonly ApplicationDBContext dBContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return dBContext.Category.ToList();
        }

        public Category GetById(Guid id)
        {
            return dBContext.Category.FirstOrDefault(x => x.Id == id);
        }

        public Category Save(Category data)
        {
            dBContext.Category.Add(data);
            dBContext.SaveChanges();
            return data;
        }

        public Category Update(Guid id, Category data)
        {
            var getValue = dBContext.Category.FirstOrDefault(x => x.Id == id);
            if (getValue != null)
            {
                getValue.Name = data.Name;
                dBContext.SaveChanges();
            }
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = dBContext.Category.FirstOrDefault(x => x.Id == id);
            dBContext.Remove(getValue);
            dBContext.SaveChanges();
            return getValue != null;
        }
    }
}