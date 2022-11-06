using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class UserRepository : IReadDeleteRepository<User>, ISaveAndUpdateRepository<User>
    {
        private readonly ApplicationDBContext _dBContext;

        public UserRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _dBContext.User.ToList();
        }

        public User GetById(Guid id)
        {
            return _dBContext.User.FirstOrDefault(x => x.Id == id);
        }

        public User Save(User data)
        {
            _dBContext.User.Add(data);
            _dBContext.SaveChanges();
            return data;
        }

        public User Update(Guid id, User data)
        {
            var getValue = _dBContext.User.FirstOrDefault(x => x.Id == id);
            if (getValue == null) return null;
            getValue.Fullname = data.Fullname;
            getValue.Username = data.Username;
            getValue.Email = data.Email;
            getValue.Password = data.Password;
            _dBContext.SaveChanges();
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = _dBContext.User.FirstOrDefault(x => x.Id == id);
            if (getValue == null) return false;
            _dBContext.Remove(getValue);
            _dBContext.SaveChanges();
            return true;
        }
    }
}
