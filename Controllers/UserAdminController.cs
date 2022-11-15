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
        private readonly IReadAndDeleteRepository<UserAdmin> _readDeleteRepository;
        private readonly ISaveAndUpdateRepository<UserAdmin, UserAdmin> _saveAndUpdateRepository;

        public UserAdminController(IReadAndDeleteRepository<UserAdmin> readDeleteRepository, ISaveAndUpdateRepository<UserAdmin, UserAdmin> saveAndUpdateRepository)
        {
            _readDeleteRepository = readDeleteRepository;
            _saveAndUpdateRepository = saveAndUpdateRepository;
        }

        [HttpGet]
        public IActionResult GetAllUserAdmin()
        {
            return Ok(_readDeleteRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetUserAdminById(Guid id)
        {
            var value = _readDeleteRepository.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveUserAdmin(UserAdmin addUserAdmin)
        {
            var value = _saveAndUpdateRepository.Save(addUserAdmin);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateUserAdmin(Guid id, UserAdmin updateUserAdmin)
        {
            var value = _saveAndUpdateRepository.Update(id, updateUserAdmin);
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteUserAdmin(Guid id)
        {
            var isDeleted = _readDeleteRepository.DeleteById(id);
            return Ok(isDeleted);
        }
    }
}
