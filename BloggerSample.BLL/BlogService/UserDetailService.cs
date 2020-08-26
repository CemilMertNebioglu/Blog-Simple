using BloggerSample.BLL.Abstract;
using BloggerSample.Core.Data.UnitOfWork;
using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping;
using BloggerSample.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloggerSample.BLL.BlogService
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUnitofWork uow;
        public UserDetailService(IUnitofWork _uow)
        {
            uow = _uow;
        }
   
    }
}
