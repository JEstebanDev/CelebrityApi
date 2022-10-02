using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

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
    }
}
