using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CelebrityAPI.Controllers
{
    [ApiController]
    [Route("useradmin")]
    public class UserAdminController : ControllerBase
    {
        private readonly ICrudRepository<UserAdmin> crudRepository;

        public UserAdminController(ICrudRepository<UserAdmin> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        [HttpGet]
        public IActionResult GetAllUserAdmin()
        {
            return Ok(crudRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetUserAdminById(Guid id)
        {
            var value = crudRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveUserAdmin(UserAdmin addUserAdmin)
        {
            var value = crudRepository.Save(addUserAdmin);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateUserAdmin(Guid id, UserAdmin updateUserAdmin)
        {
            var value = crudRepository.Update(id, updateUserAdmin);
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
