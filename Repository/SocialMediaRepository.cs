using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class SocialMediaRepository : IReadAndDeleteRepository<SocialMedia>, ISaveAndUpdateRepository<SocialMedia,SocialMedia>
    {
        private readonly ApplicationDBContext _dBContext;

        public SocialMediaRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<SocialMedia> GetAll()
        {
            return _dBContext.SocialMedia.ToList();
        }

        public SocialMedia GetById(Guid id)
        {
            return _dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
        }

        public SocialMedia Save(SocialMedia data)
        {
            _dBContext.SocialMedia.Add(data);
            _dBContext.SaveChanges();
            return data;
        }

        public SocialMedia Update(Guid id, SocialMedia data)
        {
            var getValue = _dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
            if (getValue == null) return null;
            getValue.FacebookURL = data.FacebookURL;
            getValue.TwitterURL = data.TwitterURL;
            getValue.InstagramURL = data.InstagramURL;
            _dBContext.SaveChanges();
            return getValue;
        }

        public bool DeleteById(Guid id)
        {
            var getValue = _dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
            if (getValue == null) return false;
            _dBContext.Remove(getValue);
            _dBContext.SaveChanges();
            return true;

        }
    }
}
