using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using CelebrityAPI.Model.DTO;

namespace CelebrityAPI.Controllers
{
    [ApiController]
    [Route("celebrity")]
    public class CelebrityController : ControllerBase
    {
        private readonly IReadAndDeleteRepository<CelebrityResponse> _readDeleteRepository;
        private readonly ISaveAndUpdateRepository<CelebrityResponse, CelebrityDto> _saveAndUpdateRepository;

        public CelebrityController(ISaveAndUpdateRepository<CelebrityResponse, CelebrityDto> saveAndUpdateRepository, IReadAndDeleteRepository<CelebrityResponse> readDeleteRepository)
        {
            _saveAndUpdateRepository = saveAndUpdateRepository;
            _readDeleteRepository = readDeleteRepository;
        }

        [HttpGet]
        public IActionResult GetAllCelebrity()
        {
            return Ok(_readDeleteRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetCelebrityById(Guid id)
        {
            var value = _readDeleteRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveCelebrity(CelebrityDto addCelebrity)
        {
            var value = _saveAndUpdateRepository.Save(addCelebrity);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateCelebrity(Guid id, CelebrityDto updateCelebrity)
        {
            var value = _saveAndUpdateRepository.Update(id, updateCelebrity);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteCelebrity(Guid id)
        {
            var isDeleted = _readDeleteRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
