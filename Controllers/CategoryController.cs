using Microsoft.AspNetCore.Mvc;
using Backend.Services.Interface;
using Backend.Utils.Common;
using Backend.Controllers.DTO;
using System;
using Backend.Pipe;

namespace Backend.Controllers
{
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }


        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Category()
        {
            return View(Routers.Category.Page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpGet("create")]
        public IActionResult CreateCategory()
        {
            return View(Routers.CreateCategory.Page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpPost("create")]
        public IActionResult HandleCreateCategory(string name, string description)
        {
            var input = new CreateCategoryDTO()
            {
                Name = name,
                Description = description
            };
            var isValid = this.CategoryService.CreateCategoryHandler(input, this.ViewData);
            if (!isValid)
            {
                return View(Routers.CreateCategory.Page);
            }
            return Redirect(Routers.Category.Link);
        }


        [ServiceFilter(typeof(AuthGuard))]
        [HttpGet("update")]
        public IActionResult UpdateCategory()
        {
            return View(Routers.UpdateCategory.Page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpPost("update")]
        public IActionResult handleUpdateCategory(string categoryId, string name, string description)
        {
            var input = new UpdateCategoryDTO()
            {
                CategoryId = categoryId,
                Name = name,
                Description = description
            };
            var isValid = this.CategoryService.UpdateCategoryHandler(input, this.ViewData);
            if (!isValid)
            {
                return View(Routers.UpdateCategory.Page);
            }
            return Redirect(Routers.Category.Link);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpGet("delete")]
        public IActionResult DeleteCategory()
        {
            return View(Routers.DeleteCategory.Page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpPost("delete")]
        public IActionResult handleDeleteCategory(string categoryId)
        {
            var input = new DeleteCategoryDTO()
            {
                CategoryId = categoryId
            };
            var isValid = this.CategoryService.DeleteCategoryHandler(input, this.ViewData);
            if (!isValid)
            {
                return View(Routers.DeleteCategory.Page);
            }
            return Redirect(Routers.Category.Link);
        }
    }
}