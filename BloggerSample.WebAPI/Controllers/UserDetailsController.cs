using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggerSample.BLL.Abstract;
using BloggerSample.BLL.BlogService;
using BloggerSample.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerSample.WebAPI.Controllers
{
    [Route("api/UserDetail")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailService UserDetailService;

        public UserDetailsController(IUserDetailService _userdetailservice)
        {
            UserDetailService = _userdetailservice;
        }
       
    }

}