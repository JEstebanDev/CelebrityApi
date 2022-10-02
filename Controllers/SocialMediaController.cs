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
        private readonly ICrudRepository<SocialMedia> crudRepository;

        public SocialMediaController(ICrudRepository<SocialMedia> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        [HttpGet]
        public IActionResult GetAllSocialMedia()
        {
            return Ok(crudRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetSocialMediaById(Guid id)
        {
            var value = crudRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveSocialMedia(SocialMedia addSocialMedia)
        {
            var value = crudRepository.Save(addSocialMedia);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateSocialMedia(Guid id, SocialMedia updateSocialMedia)
        {
            var value = crudRepository.Update(id, updateSocialMedia);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteSocialMedia(Guid id)
        {
            var isDeleted = crudRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
