using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggerSample.BLL.Abstract;
using BloggerSample.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerSample.WebAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public List<UserDTO> Get()
        {
            return userService.getAll();
        }
        [HttpGet("{id}")]
        public UserDTO Get(int Id)
        {
            return userService.getUser(Id);
        }
        //[HttpGet("{name}")]
        //public List<UserDTO>Get(string name)
        //{
        //    return userService.getUserName(name);
        //}
        [HttpPost]
        public UserDTO Post(UserDTO dto)
        {
            return userService.newUser(dto);
        }
        [HttpPut("{id}")]
        public UserDTO Put(UserDTO dto)
        {
            return userService.updateUser(dto);

        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            return userService.deleteUser(Id);
        }
    }
}