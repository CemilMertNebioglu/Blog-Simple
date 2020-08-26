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
    [Route("api/Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRoleService RoleService;

        public RolesController(IRoleService _roleservice)
        {
            RoleService = _roleservice;
        }
        [HttpGet]
        public List<RoleDTO> Get()
        {
            return RoleService.getAll();
        }
        [HttpGet("{id:int}")]
        public RoleDTO Get(int ıd)
        {
            return RoleService.getRole(ıd);
        }
        [HttpPost]
        public RoleDTO Post(RoleDTO dto)
        {
            return RoleService.newRole(dto);
        }
        [HttpPut]
        public RoleDTO Put(RoleDTO dto)
        {
            return RoleService.updateRole(dto);
        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            return RoleService.deleteRole(Id);
        }

    }
}
