using System.Collections.Generic;
using Backend.Services.Interface;
using System;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using Backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Utils;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Backend.Models;


using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DBContext DBContext;
        private readonly ICategoryRepository CategoryRepository;

        public CategoryService(DBContext dBContext, ICategoryRepository categoryRepository)
        {
            this.DBContext = dBContext;
            this.CategoryRepository = categoryRepository;
        }

        public Category GetCategory(string categoryId)
        {
            var category = this.CategoryRepository.GetCategory(categoryId);
            return category;
        }

        public List<Category> GetCategories()
        {
            return this.CategoryRepository.GetCategories();
        }

        public List<SelectListItem> GetCategoryDropListRender(CategoryStatus categoryStatus)
        {
            var categories = new List<SelectListItem>();
            IEnumerable<Category> list;
            if (categoryStatus == CategoryStatus.ACTIVE)
            {
                list = this.CategoryRepository.GetCategories().Where(c => c.Status == CategoryStatus.ACTIVE);
            }
            else
            {
                list = this.CategoryRepository.GetCategories();
            }
            foreach (var item in list)
            {
                categories.Add(new SelectListItem() { Value = item.CategoryId, Text = item.Name });
            }

            return categories;
        }

        public bool CreateCategoryHandler(Category category)
        {

            return this.CategoryRepository.CreateCategoryHandler(category);
        }

        public bool UpdateCategoryHandler(Category category)
        {

            return this.CategoryRepository.UpdateCategoryHandler(category);
        }

        public (List<Category>, int) GetAllCategoriesWithStatus(int pageIndex, int pageSize, string searchName, CategoryStatus searchStatus) => this.CategoryRepository.GetAllCategoriesWithStatus(pageIndex, pageSize, searchName, searchStatus);

        public List<SelectListItem> GetCategoryStatusDropListRender()
        {
            var status = new List<SelectListItem>(){
                new SelectListItem(){ Value = CategoryStatus.ACTIVE.ToString(), Text = "Active"},
                new SelectListItem() { Value = CategoryStatus.INACTIVE.ToString(), Text = "Inactive" }
            };

            return status;
        }
    }
}