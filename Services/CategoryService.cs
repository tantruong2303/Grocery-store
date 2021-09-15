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
using Backend.Utils.Interface;
using System.Linq;

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

        public bool CreateCategoryHandler(CreateCategoryDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new CreateCategoryDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return false;
            }
            var isExistCategory = this.CategoryRepository.GetCategoryByCategoryName(input.Name);
            if (isExistCategory != null)
            {
                ServerResponse.SetFieldErrorMessage("name", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }

            var category = new Category();
            category.CategoryId = Guid.NewGuid().ToString();
            category.Name = input.Name;
            category.Description = input.Description;
            category.Status = (CategoryStatus)input.Status;
            category.CreateDate = DateTime.Now.ToShortDateString();
            this.DBContext.Category.Add(category);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool UpdateCategoryHandler(UpdateCategoryDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new UpdateCategoryDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return false;
            }
            var category = this.CategoryRepository.GetCategoryByCategoryId(input.CategoryId);

            var isExistCategory = this.CategoryRepository.GetCategoryByCategoryName(input.Name);
            if (isExistCategory != null && isExistCategory.Name != category.Name)
            {
                ServerResponse.SetFieldErrorMessage("name", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }

            category.Name = input.Name;
            category.Description = input.Description;
            category.Status = (CategoryStatus)input.Status;
            this.DBContext.SaveChanges();
            return true;

        }
    }
}