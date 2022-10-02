using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CelebrityAPI.Controllers
{
    [ApiController]
    [Route("profession")]
    public class ProfessionController : ControllerBase
    {
        private readonly ICrudRepository<Profession> crudRepository;

        public ProfessionController(ICrudRepository<Profession> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        [HttpGet]
        public IActionResult GetAllProfessions()
        {
            return Ok(crudRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetProfessionById(Guid id)
        {
            var value = crudRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveProfession(Profession addProfession)
        {
            var value = crudRepository.Save(addProfession);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateProfession(Guid id, Profession updateProfession)
        {
            var value = crudRepository.Update(id, updateProfession);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteProfession(Guid id)
        {
            var isDeleted = crudRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
