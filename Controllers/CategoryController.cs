using Microsoft.AspNetCore.Mvc;
using Backend.Services.Interface;
using Backend.Utils.Common;
using Backend.Pipe;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Backend.Controllers
{
    [Route("category")]
    [RoleGuardAttribute(new UserRole[] { UserRole.MANGER })]
    [ServiceFilter(typeof(AuthGuard))]
    public class CategoryController : Controller
    {
        private readonly ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }


        [HttpGet("")]
        public IActionResult Category(string searchName, CategoryStatus searchStatus, int pageIndex = 0, int pageSize = 12)
        {

            if (searchName == null)
            {
                searchName = "";
            }
            this.ViewData["status"] = new SelectList(this.CategoryService.GetCategoryStatusDropListRender(), CategoryStatus.ACTIVE);

            var statusList = this.CategoryService.GetCategoryStatusDropListRender();
            statusList.Add(new SelectListItem() { Text = "All", Value = "" });
            SelectList list = new SelectList(statusList, "");
            this.ViewData["statusSearch"] = list;
            Console.WriteLine(list);

            var (allCategories, allTotal) = this.CategoryService.GetAllCategoriesWithStatus(pageIndex, pageSize, searchName, searchStatus);
            this.ViewData["categories"] = allCategories;
            this.ViewData["total"] = allTotal;
            Console.WriteLine(allCategories);
            Console.WriteLine(allTotal);
            return View(Routers.Category.Page);
        }


        [HttpGet("create")]
        public IActionResult CreateCategory()
        {
            return View(Routers.CreateCategory.Page);
        }


        [HttpGet("update")]
        public IActionResult UpdateCategory(string categoryId)
        {
            var category = this.CategoryService.GetCategory(categoryId);
            this.ViewData["category"] = category;
            return View(Routers.UpdateCategory.Page);
        }

    }
}