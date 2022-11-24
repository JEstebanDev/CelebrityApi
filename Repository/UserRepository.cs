using CelebrityAPI.Data;
using CelebrityAPI.Error;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class UserRepository : IReadAndDeleteRepository<User>, ISaveAndUpdateRepository<User, User>
    {
        private readonly ApplicationDBContext _dBContext;

        public UserRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<User> GetAll()
        {
            var listUser = _dBContext.User.ToList();
            if (listUser.Count == 0)
            {
                throw new AppException("There are not data");
            }
            if (listUser == null)
            {
                throw new AppException("Error searching the data");
            }
            return listUser;
        }

        public User GetById(Guid id)
        {
            var user = _dBContext.User.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new AppException("There are not user with id:" + id);
            }
            return user;
        }

        public User Save(User data)
        {
            try
            {
                CheckValue(data);
                _dBContext.User.Add(data);
                _dBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
            return data;
        }

        public User Update(Guid id, User data)
        {
            try
            {
                CheckValue(data);
                var getValue = _dBContext.User.FirstOrDefault(x => x.Id == id);
                if (getValue == null) throw new AppException("There are not data with the id:" + id);
                getValue.Fullname = data.Fullname;
                getValue.Username = data.Username;
                getValue.Email = data.Email;
                getValue.Password = data.Password;
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
                var getValue = _dBContext.User.FirstOrDefault(x => x.Id == id);
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
        private void CheckValue(User data)
        {
            if (data.Fullname == null)
            {
                throw new AppException("Error you need a Fullname");
            }
            if (data.Email == null)
            {
                throw new AppException("Error you need a Email");
            }
            if (data.Password == null)
            {
                throw new AppException("Error you need a Password");
            }
            if (data.Username == null)
            {
                throw new AppException("Error you need a Username");
            }
        }
    }
}
