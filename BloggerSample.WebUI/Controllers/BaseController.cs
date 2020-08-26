using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BloggerSample.DTO;
using BloggerSample.WebUI.Core;
using Microsoft.AspNetCore.Mvc;

namespace BloggerSample.WebUI.Controllers
{
    public class BaseController : Controller
    {

        public UserDTO CurrentUser
        {
            get
            {
                var userDTOjson = HttpContext.User.Claims.FirstOrDefault(z => z.Type == "UserDTO").Value;
                return BloggerConvert.BloggerJsonDeSerializeUserDTO(userDTOjson);
            }
        }
    }
}