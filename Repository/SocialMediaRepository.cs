using CelebrityAPI.Data;
using CelebrityAPI.Error;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelebrityAPI.Repository
{
    public class SocialMediaRepository : IReadAndDeleteRepository<SocialMedia>, ISaveAndUpdateRepository<SocialMedia, SocialMedia>
    {
        private readonly ApplicationDBContext _dBContext;

        public SocialMediaRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<SocialMedia> GetAll()
        {
            var listSocialMedia = _dBContext.SocialMedia.ToList();
            if (listSocialMedia.Count == 0)
            {
                throw new AppException("There are not data");
            }
            if (listSocialMedia == null)
            {
                throw new AppException("Error searching the data");
            }
            return listSocialMedia;
        }

        public SocialMedia GetById(Guid id)
        {
            var socialMedia = _dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
            if (socialMedia == null)
            {
                throw new AppException("There are not user with id:" + id);
            }
            return socialMedia;
        }

        public SocialMedia Save(SocialMedia data)
        {
            try
            {
                _dBContext.SocialMedia.Add(data);
                _dBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
            return data;
        }

        public SocialMedia Update(Guid id, SocialMedia data)
        {
            try
            {
                var getValue = _dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
                if (getValue == null) throw new AppException("There are not data with the id:" + id);
                getValue.FacebookURL = data.FacebookURL;
                getValue.TwitterURL = data.TwitterURL;
                getValue.InstagramURL = data.InstagramURL;
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
                var getValue = _dBContext.SocialMedia.FirstOrDefault(x => x.Id == id);
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
    }
}
