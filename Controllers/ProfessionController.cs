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
        private readonly IReadAndDeleteRepository<Profession> _readDeleteRepository;
        private readonly ISaveAndUpdateRepository<Profession, Profession> _saveAndUpdateRepository;

        public ProfessionController(IReadAndDeleteRepository<Profession> readDeleteRepository, ISaveAndUpdateRepository<Profession, Profession> saveAndUpdateRepository)
        {
            this._readDeleteRepository = readDeleteRepository;
            _saveAndUpdateRepository = saveAndUpdateRepository;
        }

        [HttpGet]
        public IActionResult GetAllProfessions()
        {
            return Ok(_readDeleteRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetProfessionById(Guid id)
        {
            var value = _readDeleteRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveProfession(Profession addProfession)
        {
            var value = _saveAndUpdateRepository.Save(addProfession);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateProfession(Guid id, Profession updateProfession)
        {
            var value = _saveAndUpdateRepository.Update(id, updateProfession);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteProfession(Guid id)
        {
            var isDeleted = _readDeleteRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
