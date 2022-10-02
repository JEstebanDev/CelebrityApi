using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class SocialMediaRepository : ICrudRepository<SocialMedia>
    {
        private readonly ApplicationDBContext dBContext;

        public SocialMediaRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<SocialMedia> GetAll()
        {
            return dBContext.SocialMedia.ToList();
        }

        public SocialMedia GetById(Guid id)
        {
            return dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
        }

        public SocialMedia Save(SocialMedia data)
        {
            dBContext.SocialMedia.Add(data);
            dBContext.SaveChanges();
            return data;
        }

        public SocialMedia Update(Guid id, SocialMedia data)
        {
            var getValue = dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
            if (getValue != null)
            {
                getValue.FacebookURL = data.FacebookURL;    
                getValue.TwitterURL = data.TwitterURL;
                getValue.InstagramURL = data.InstagramURL;
                dBContext.SaveChanges();
            }
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
            dBContext.Remove(getValue);
            dBContext.SaveChanges();
            return getValue != null;
        }
    }
}
