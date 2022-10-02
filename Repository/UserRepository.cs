using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class UserRepository : ICrudRepository<User>
    {
        private readonly ApplicationDBContext dBContext;

        public UserRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<User> GetAll()
        {
            return dBContext.User.ToList();
        }

        public User GetById(Guid id)
        {
            return dBContext.User.FirstOrDefault(x => x.Id == id);
        }

        public User Save(User data)
        {
            dBContext.User.Add(data);
            dBContext.SaveChanges();
            return data;
        }

        public User Update(Guid id, User data)
        {
            var getValue = dBContext.User.FirstOrDefault(x => x.Id == id);
            if (getValue != null)
            {
                getValue.Fullname = data.Fullname;
                getValue.Username = data.Username;
                getValue.Email = data.Email;
                getValue.Password = data.Password;
                dBContext.SaveChanges();
            }
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = dBContext.User.FirstOrDefault(x => x.Id == id);
            dBContext.Remove(getValue);
            dBContext.SaveChanges();
            return getValue != null;
        }
    }
}
