using BloggerSample.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerSample.WebUI.Models
{
    public class ArticleViewModel
    {
        public ArticleDTO ArticleDTO { get; set; }
        public List<ArticleDTO> ArticleDTOs { get; set; }
        public List<CategoryDTO> CategoryDTOs { get; set; }
        public IFormFile File { get; set; }
        public CommentDTO CommentDTO { get; set; }
    }
}
