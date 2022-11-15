using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CelebrityAPI.Controllers
{
    [ApiController]
    [Route("socialmedia")]
    public class SocialMediaController : ControllerBase
    {
        private readonly IReadAndDeleteRepository<SocialMedia> _readDeleteRepository;
        private readonly ISaveAndUpdateRepository<SocialMedia, SocialMedia> _saveAndUpdateRepository;
        public SocialMediaController(IReadAndDeleteRepository<SocialMedia> readDeleteRepository, ISaveAndUpdateRepository<SocialMedia, SocialMedia> saveAndUpdateRepository)
        {
            this._readDeleteRepository = readDeleteRepository;
            _saveAndUpdateRepository = saveAndUpdateRepository;
        }

        [HttpGet]
        public IActionResult GetAllSocialMedia()
        {
            return Ok(_readDeleteRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetSocialMediaById(Guid id)
        {
            var value = _readDeleteRepository.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveSocialMedia(SocialMedia addSocialMedia)
        {
            var value = _saveAndUpdateRepository.Save(addSocialMedia);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateSocialMedia(Guid id, SocialMedia updateSocialMedia)
        {
            var value = _saveAndUpdateRepository.Update(id, updateSocialMedia);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteSocialMedia(Guid id)
        {
            var isDeleted = _readDeleteRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
