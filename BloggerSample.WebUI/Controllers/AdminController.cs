using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BloggerSample.BLL.Abstract;
using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.WebUI.Core;
using BloggerSample.WebUI.CustomHandler;
using BloggerSample.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloggerSample.WebUI.Controllers
{
    [Authorize(Roles = "Admin,Yönetici")]
    public class AdminController : BaseController
    {
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        private readonly IContactService contactService;
        private readonly IArticleService articleService;

        public AdminController(IUserService _userService,
                               ICategoryService _categoryService,
                               ICommentService _commentService,
                               IContactService _contactService,
                               IArticleService _articleService)
        {
            userService = _userService;
            categoryService = _categoryService;
            commentService = _commentService;
            contactService = _contactService;
            articleService = _articleService;
        }
        [Authorize(Roles = "Admin,Yönetici")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Yönetici")]
        public IActionResult ArticleList()
        {
            ArticleViewModel model = new ArticleViewModel();
            model.ArticleDTOs = articleService.getAll();
            model.CategoryDTOs = categoryService.getAll();

            return View(model);
        }

        [Authorize(Roles = "Admin,Yönetici")]
        public IActionResult ArticleAdd()
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.CategoryDTOs = categoryService.getAll();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin,Yönetici")]
        [HttpPost]
        public IActionResult ArticleAdd(ArticleViewModel viewModel)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");

            var fileStream = new FileStream(Path.Combine(path, viewModel.File.FileName), FileMode.Create);

            viewModel.File.CopyTo(fileStream);


            viewModel.ArticleDTO.UserDTO = CurrentUser;
            viewModel.ArticleDTO.Picture = "/images/" + viewModel.File.FileName;
            ArticleDTO dto = viewModel.ArticleDTO;
            articleService.newArticle(dto);
            return RedirectToAction("ArticleList");
        }


        [Authorize(Roles = "Admin,Yönetici")]
        public IActionResult ArticleEdit(int id)
        {
            ArticleViewModel model = new ArticleViewModel();
            model.ArticleDTO = articleService.getArticle(id);
            model.CategoryDTOs = categoryService.getAll();
            return View(model);
        }
        [Authorize(Roles = "Admin,Yönetici")]
        [HttpPost]
        public IActionResult ArticleEdit(ArticleViewModel model)
        {
            ArticleDTO updatedto = model.ArticleDTO;
            updatedto.Picture = model.File.FileName;

            articleService.updateArticle(updatedto);

            return RedirectToAction("ArticleList");
        }

        #region Categories
        public IActionResult CategoryList()
        {
            return View(categoryService.getAll());
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryDTO categoryDTO)
        {
            categoryService.newCategory(categoryDTO);
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryEdit(int id)
        {
            CategoryDTO selectedCategory = categoryService.getCategory(id);
            return View(selectedCategory);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryDTO categoryDTO)
        {
            categoryService.updateCategory(categoryDTO);
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryDelete(int id)
        {
            categoryService.deleteCategory(id);
            return RedirectToAction("CategoryList");
        }
        #endregion

        #region Comments
        public IActionResult CommentList()
        {
            return View(commentService.getAll());
        }

      

        public IActionResult CommentDelete(int id)
        {
            commentService.deleteComment(id);
            return RedirectToAction("CommentList");
        }
        #endregion

        #region Contacts
        public IActionResult ContactList()
        {
            return View(contactService.getAll());
        }

        public IActionResult MarkAsRead(int Id)
        {
            commentService.markasRead(Id);
            return RedirectToAction("ContactList");
        }
        #endregion
        [Authorize(Roles = "Admin")]
        #region User
        public IActionResult UserList()
        {
            return View(userService.getAll());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserAdd()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UserAdd(UserDTO dto)
        {
            userService.newUser(dto);
            return RedirectToAction("UserList");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserEdit(int Id)
        {
            UserDTO editUser = userService.getUser(Id);
            return View(editUser);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UserEdit(UserDTO dto)
        {
            userService.updateUser(dto);
            return RedirectToAction("UserList");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserDelete(int Id)
        {
            userService.deleteUser(Id);
            return RedirectToAction("UserList");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserFilter()
        {
            return View();
        }
        #endregion

    }
}