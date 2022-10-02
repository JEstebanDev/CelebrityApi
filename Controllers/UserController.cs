using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CelebrityAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ICrudRepository<User> crudRepository;

        public UserController(ICrudRepository<User> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(crudRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var value = crudRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveUser(User addUser)
        {
            var value = crudRepository.Save(addUser);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateUser(Guid id, User updateUser)
        {
            var value = crudRepository.Update(id, updateUser);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteUserAdmin(Guid id)
        {
            var isDeleted = crudRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
