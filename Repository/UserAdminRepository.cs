using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class UserAdminRepository : ICrudRepository<UserAdmin>
    {
        private readonly ApplicationDBContext dBContext;

        public UserAdminRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            return dBContext.UserAdmin.ToList();
        }

        public UserAdmin GetById(Guid id)
        {
            return dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
        }

        public UserAdmin Save(UserAdmin data)
        {
            dBContext.UserAdmin.Add(data);
            dBContext.SaveChanges();
            return data;
        }

        public UserAdmin Update(Guid id, UserAdmin data)
        {
            var getValue = dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
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
            var getValue = dBContext.UserAdmin.FirstOrDefault(x => x.Id == id);
            dBContext.Remove(getValue);
            dBContext.SaveChanges();
            return getValue != null;
        }
    }
}
