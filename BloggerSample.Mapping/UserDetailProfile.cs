using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerSample.Mapping
{
    public  class UserDetailProfile : ProfileBase
    {
      public UserDetailProfile()
        {
            CreateMap<UserDetail, UserDetailDTO>().ReverseMap();
        }
    }
}
