using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BloggerSample.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using BloggerSample.BLL.Abstract;
using BloggerSample.DTO;

namespace BloggerSample.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        public HomeController(IArticleService _articleService, ICategoryService _categoryService, ICommentService _commentService)
        {
            articleService = _articleService;
            categoryService = _categoryService;
            commentService = _commentService;
        }
        public IActionResult Index()
        {
            return View(articleService.getAll());
        }

        public IActionResult ArticleView(int id)
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            ArticleDTO dto = articleService.getArticle(id);
            ArticleViewModel model = new ArticleViewModel();
            comments = commentService.getByArticleId(id);
            model.CategoryDTOs = categoryService.getAll();
            model.ArticleDTO = dto;
            model.ArticleDTO.CommentDTOs = comments;

            return View(model);
        }


        public JsonResult CommentList(int id)
        {
            List<CommentDTO> commentList = commentService.getByArticleId(id);
            return Json(commentList);
        }

        public void CommentAdd(CommentDTO dto)
        {
            dto.CreateDate = DateTime.Now;
            commentService.newComment(dto);
        }

    }
}
