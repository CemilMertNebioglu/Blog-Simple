using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloggerSample.Mapping
{
    public  class ArticleProfile : ProfileBase
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
        }
     
    }
}
