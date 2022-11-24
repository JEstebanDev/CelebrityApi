using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;
using CelebrityAPI.Error;

namespace CelebrityAPI.Repository
{
    public class UserAdminRepository : IReadAndDeleteRepository<UserAdmin>, ISaveAndUpdateRepository<UserAdmin, UserAdmin>
    {
        private readonly ApplicationDBContext _dBContext;

        public UserAdminRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            var listUserAdmins = _dBContext.UserAdmin.ToList();
            if (listUserAdmins.Count == 0)
            {
                throw new AppException("There are not data");
            }
            if (listUserAdmins == null)
            {
                throw new AppException("Error searching the data");
            }
            return listUserAdmins;
        }

        public UserAdmin GetById(Guid id)
        {
            var userAdmin = _dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
            if (userAdmin == null)
            {
                throw new AppException("There are not user with id:" + id);
            }
            return userAdmin;
        }

        public UserAdmin Save(UserAdmin data)
        {
            try
            {
                CheckValue(data);
                _dBContext.UserAdmin.Add(data);
                _dBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
            return data;
        }

        public UserAdmin Update(Guid id, UserAdmin data)
        {
            try
            {
                CheckValue(data);
                var getValue = _dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
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
                var getValue = _dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
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
        private void CheckValue(UserAdmin data)
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
