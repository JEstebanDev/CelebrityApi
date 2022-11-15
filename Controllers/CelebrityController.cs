using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using CelebrityAPI.Model.DTO;
using CelebrityAPI.Repository;

namespace CelebrityAPI.Controllers
{
    [ApiController]
    [Route("celebrity")]
    public class CelebrityController : ControllerBase
    {
        private readonly IReadAndDeleteRepository<CelebrityResponse> _readDeleteRepository;
        private readonly ISaveAndUpdateRepository<CelebrityResponse, CelebrityDto> _saveAndUpdateRepository;
        private readonly IFiltersRepository _filtersRepository;
        public CelebrityController(ISaveAndUpdateRepository<CelebrityResponse, CelebrityDto> saveAndUpdateRepository,
            IReadAndDeleteRepository<CelebrityResponse> readDeleteRepository, IFiltersRepository filtersRepository)
        {
            _saveAndUpdateRepository = saveAndUpdateRepository;
            _readDeleteRepository = readDeleteRepository;
            _filtersRepository = filtersRepository;
        }

        [HttpGet]
        public IActionResult GetAllCelebrity()
        {
            var celebrityResponses = _readDeleteRepository.GetAll();
            return Ok(celebrityResponses);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetCelebrityById(Guid id)
        {
            var value = _readDeleteRepository.GetById(id);
            return Ok(value);
        }
        [HttpGet]
        [Route("searchByCategory/{categoryId:Guid}")]
        public IActionResult GetCelebrityByCategory(Guid categoryId)
        {
            var value = _filtersRepository.GetByCategory(categoryId);
            return Ok(value);
        }

        [HttpGet]
        [Route("searchByProfession/{professionId:Guid}")]
        public IActionResult GetCelebrityByProfession(Guid professionId)
        {
            var value = _filtersRepository.GetByProfession(professionId);
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
