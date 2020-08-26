using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloggerSample.Mapping
{
    public  class RoleProfile : ProfileBase
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }

    }
}
