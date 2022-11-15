using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;
using CelebrityAPI.Model.DTO;
using CelebrityAPI.Error;

namespace CelebrityAPI.Repository
{
    public class CelebrityRepository : IReadAndDeleteRepository<CelebrityResponse>, ISaveAndUpdateRepository<CelebrityResponse, CelebrityDto>, IFiltersRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public CelebrityRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<CelebrityResponse> GetAll()
        {
            IEnumerable<Celebrity> listCelebrities = _dBContext.Celebrity.ToList();
            if (!listCelebrities.Any())
            {
                throw new AppException("Error searching the data");
            }
            return listCelebrities.Select(TranslateOutputResponse).ToList();
        }

        public IEnumerable<CelebrityResponse> GetByCategory(Guid categoryId)
        {
            try
            {
                IEnumerable<Celebrity> celebrity = _dBContext.Celebrity.Where(x => x.CategoryId == categoryId).ToList();
                if (celebrity.Any())
                {
                   return  celebrity.Select(TranslateOutputResponse).ToList();
                }
                else
                {
                    throw new AppException("There are not data with the category id:" + categoryId);
                }
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public IEnumerable<CelebrityResponse> GetByProfession(Guid professionId)
        {
            try
            {
                IEnumerable<Celebrity> celebrity = _dBContext.Celebrity.Where(x => x.ProfessionId == professionId).ToList();
                if (celebrity.Any())
                {
                    return celebrity.Select(TranslateOutputResponse).ToList();
                }
                else
                {
                    throw new AppException("There are not data with the profession id:" + professionId);
                }
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        public CelebrityResponse GetById(Guid id)
        {
            var celebrity = _dBContext.Celebrity.FirstOrDefault(x => x.Id == id);
            if (celebrity == null)
            {
                throw new AppException("There are not user with id:" + id);
            }
            return TranslateOutputResponse(celebrity);
        }

        public CelebrityResponse Save(CelebrityDto data)
        {
            try
            {
                var celebrity = new Celebrity()
                {
                    Id = data.Id,
                    FullName = data.FullName,
                    Birthday = data.Birthday,
                    Age = data.Age,
                    Country = data.Country,
                    ImageUrl = data.ImageUrl,
                    CategoryId = data.CategoryId,
                    SocialMediaId = data.SocialMediaId,
                    ProfessionId = data.ProfessionId
                };
                _dBContext.Celebrity.Add(celebrity);
                _dBContext.SaveChanges();
                return TranslateOutputResponse(celebrity);
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public CelebrityResponse Update(Guid id, CelebrityDto data)
        {
            try
            {
                var getValue = _dBContext.Celebrity.FirstOrDefault(x => x.Id == id);
                if (getValue == null) throw new AppException("There are not user with id:" + id);
                getValue.FullName = data.FullName;
                getValue.Age = data.Age;
                getValue.ImageUrl = data.ImageUrl;
                getValue.Country = data.Country;
                getValue.CategoryId = data.CategoryId;
                getValue.ProfessionId = data.ProfessionId;
                getValue.SocialMediaId = data.SocialMediaId;
                getValue.Birthday = data.Birthday;
                _dBContext.SaveChanges();
                return TranslateOutputResponse(getValue);
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        private CelebrityResponse TranslateOutputResponse(Celebrity data)
        {
            var socialMedia = _dBContext.SocialMedia.FirstOrDefault(x => x.Id == data.SocialMediaId);
            var category = _dBContext.Category.FirstOrDefault(x => x.Id == data.CategoryId);
            var profession = _dBContext.Profession.FirstOrDefault(x => x.Id == data.ProfessionId);
            var listSocialMedia = new List<string>();
            if (socialMedia != null)
            {
                if (!socialMedia.FacebookURL.Equals(""))
                {
                    listSocialMedia.Add(socialMedia.FacebookURL);
                }
                if (!socialMedia.InstagramURL.Equals(""))
                {
                    listSocialMedia.Add(socialMedia.InstagramURL);
                }
                if (!socialMedia.TwitterURL.Equals(""))
                {
                    listSocialMedia.Add(socialMedia.TwitterURL);
                }
            }
            else
            {
                throw new AppException("There are not socialMedia check your request");
            }

            if (category == null || profession == null) throw new AppException("There are not category or profession check your request");
            var celebrityResponse = new CelebrityResponse()
            {
                Id = data.Id,
                FullName = data.FullName,
                Birthday = data.Birthday,
                Age = data.Age,
                Country = data.Country,
                ImageUrl = data.ImageUrl,
                Category = category.Name,
                Profession = profession.Name,
                SocialMedia = listSocialMedia,
            };
            return celebrityResponse;
        }

        public bool DeleteById(Guid id)
        {
            try
            {
                var getValue = _dBContext.Celebrity.FirstOrDefault(x => x.Id == id);
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
