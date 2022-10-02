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
        private readonly ICrudRepository<Category> crudRepository;

        public CategoryController(ICrudRepository<Category> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(crudRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = crudRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult SaveCategory(Category addCategory)
        {
            var category = crudRepository.Save(addCategory);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateCategory(Guid id, Category updateCategory)
        {
            var category = crudRepository.Update(id, updateCategory);
            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var isDeleted = crudRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
