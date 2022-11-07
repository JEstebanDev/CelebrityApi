using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class UserAdminRepository : IReadAndDeleteRepository<UserAdmin>,ISaveAndUpdateRepository<UserAdmin,UserAdmin>
    {
        private readonly ApplicationDBContext _dBContext;

        public UserAdminRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            return _dBContext.UserAdmin.ToList();
        }

        public UserAdmin GetById(Guid id)
        {
            return _dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
        }

        public UserAdmin Save(UserAdmin data)
        {
            _dBContext.UserAdmin.Add(data);
            _dBContext.SaveChanges();
            return data;
        }

        public UserAdmin Update(Guid id, UserAdmin data)
        {
            var getValue = _dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
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
            var getValue = _dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
            if (getValue == null) return false;
            _dBContext.Remove(getValue);
            _dBContext.SaveChanges();
            return true;

        }
    }
}
