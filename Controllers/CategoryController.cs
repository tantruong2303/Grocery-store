using Microsoft.AspNetCore.Mvc;
using backend.Services.Interface;
using backend.Utils.Common;
using backend.Controllers.DTO;
using System;
using backend.Pipe;

namespace backend.Controllers
{
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Category()
        {
            return View(Routers.Category.page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpGet("create")]
        public IActionResult CreateCategory()
        {
            return View(Routers.CreateCategory.page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpPost("create")]
        public IActionResult handleCreateCategory(string name, string description)
        {
            var input = new CreateCategoryDTO()
            {
                name = name,
                description = description
            };
            var isValid = this.categoryService.createCategoryHandler(input, this.ViewData);
            if (!isValid)
            {
                return View(Routers.CreateCategory.page);
            }
            return Redirect(Routers.Category.link);
        }


        [ServiceFilter(typeof(AuthGuard))]
        [HttpGet("update")]
        public IActionResult UpdateCategory()
        {
            return View(Routers.UpdateCategory.page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpPost("update")]
        public IActionResult handleUpdateCategory(string categoryId, string name, string description)
        {
            var input = new UpdateCategoryDTO()
            {
                categoryId = categoryId,
                name = name,
                description = description
            };
            var isValid = this.categoryService.updateCategoryHandler(input, this.ViewData);
            if (!isValid)
            {
                return View(Routers.UpdateCategory.page);
            }
            return Redirect(Routers.Category.link);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpGet("delete")]
        public IActionResult DeleteCategory()
        {
            return View(Routers.DeleteCategory.page);
        }

        [ServiceFilter(typeof(AuthGuard))]
        [HttpPost("delete")]
        public IActionResult handleDeleteCategory(string categoryId)
        {
            var input = new DeleteCategoryDTO()
            {
                categoryId = categoryId
            };
            var isValid = this.categoryService.deleteCategoryHandler(input, this.ViewData);
            if (!isValid)
            {
                return View(Routers.DeleteCategory.page);
            }
            return Redirect(Routers.Category.link);
        }
    }
}