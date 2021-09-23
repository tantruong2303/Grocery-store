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

        public bool CreateCategoryHandler(Category category)
        {

            return this.CategoryRepository.CreateCategoryHandler(category);
        }

        public bool UpdateCategoryHandler(Category category)
        {

            return this.CategoryRepository.UpdateCategoryHandler(category);
        }
    }
}