using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerSample.Mapping
{
    public  class ContactProfile : ProfileBase
    {
        
        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
