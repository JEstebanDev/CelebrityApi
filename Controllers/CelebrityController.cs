using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CelebrityAPI.Controllers
{
    [ApiController]
    [Route("celebrity")]
    public class CelebrityController : ControllerBase
    {
        private readonly ICrudRepository<Celebrity> crudRepository;

        public CelebrityController(ICrudRepository<Celebrity> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        [HttpGet]
        public IActionResult GetAllCelebrity()
        {
            return Ok(crudRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetCelebrityById(Guid id)
        {
            var value = crudRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveCelebrity(Celebrity addCelebrity)
        {
            var value = crudRepository.Save(addCelebrity);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateCelebrity(Guid id, Celebrity updateCelebrity)
        {
            var value = crudRepository.Update(id, updateCelebrity);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteCelebrity(Guid id)
        {
            var isDeleted = crudRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
