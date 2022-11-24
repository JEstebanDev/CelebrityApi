using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;
using CelebrityAPI.Error;

namespace CelebrityAPI.Repository
{
    public class CategoryRepository : IReadAndDeleteRepository<Category>, ISaveAndUpdateRepository<Category, Category>
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<Category> GetAll()
        {
            var listCategories = _dBContext.Category.ToList();
            if (listCategories.Count == 0)
            {
                throw new AppException("There are not data");
            }
            if (listCategories == null)
            {
                throw new AppException("Error searching the data");
            }
            return listCategories;
        }
        public Category GetById(Guid id)
        {
            var category = _dBContext.Category.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                throw new AppException("There are not user with id:" + id);
            }
            return category;
        }

        public Category Save(Category data)
        {
            try
            {
                CheckValue(data);
                _dBContext.Category.Add(data);
                _dBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
            return data;
        }

        public Category Update(Guid id, Category data)
        {
            try
            {
                CheckValue(data);
                var getValue = _dBContext.Category.FirstOrDefault((x => x.Id == id));
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
                var getValue = _dBContext.Category.FirstOrDefault((x => x.Id == id));
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

        private void CheckValue(Category data)
        {
            if (data.Name == null)
            {
                throw new AppException("Error you need a Name");
            }
        }
    }
}