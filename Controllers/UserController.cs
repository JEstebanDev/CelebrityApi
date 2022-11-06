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
        private readonly IReadAndDeleteRepository<User> _readDeleteRepository;
        private readonly ISaveAndUpdateRepository<User, User> _saveAndUpdateRepository;
        public UserController(IReadAndDeleteRepository<User> readDeleteRepository, ISaveAndUpdateRepository<User, User> saveAndUpdateRepository)
        {
            _readDeleteRepository = readDeleteRepository;
            _saveAndUpdateRepository = saveAndUpdateRepository;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_readDeleteRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var value = _readDeleteRepository.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SaveUser(User addUser)
        {
            var value = _saveAndUpdateRepository.Save(addUser);
            return Ok(value);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateUser(Guid id, User updateUser)
        {
            var value = _saveAndUpdateRepository.Update(id, updateUser);
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
