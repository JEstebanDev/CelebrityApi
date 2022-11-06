using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CelebrityAPI.Controller
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly IReadAndDeleteRepository<Category> _readDeleteRepository;
        private readonly ISaveAndUpdateRepository<Category,Category> _saveAndUpdateRepository;

        public CategoryController(IReadAndDeleteRepository<Category> crudRepository, ISaveAndUpdateRepository<Category, Category> saveAndUpdateRepository)
        {
            _readDeleteRepository = crudRepository;
            _saveAndUpdateRepository = saveAndUpdateRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_readDeleteRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = _readDeleteRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult SaveCategory(Category addCategory)
        {
            var category = _saveAndUpdateRepository.Save(addCategory);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateCategory(Guid id, Category updateCategory)
        {
            var category = _saveAndUpdateRepository.Update(id, updateCategory);
            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var isDeleted = _readDeleteRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
