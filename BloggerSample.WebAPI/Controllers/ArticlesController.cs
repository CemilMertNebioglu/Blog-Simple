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
    [Route("api/Articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public List<ArticleDTO> Get()
        {
            return _articleService.getAll();
        }

        [HttpGet("{id}")]
        public ArticleDTO Get(int id)
        {
            return _articleService.getArticle(id);
        }
        [HttpPost]
        public ArticleDTO Post(ArticleDTO dto)
        {
            return _articleService.newArticle(dto);
        }
        [HttpPut]
        public ArticleDTO Put(ArticleDTO dto)
        {
            return _articleService.updateArticle(dto);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _articleService.deleteArticle(id);
        }
    }
}