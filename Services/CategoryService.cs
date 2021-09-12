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
            category.Status = (CategoryStatus)1;
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
            if (category == null)
            {
                ServerResponse.SetFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }
            category.Name = input.Name;
            category.Description = input.Description;
            this.DBContext.SaveChanges();
            return true;

        }

        public bool DeleteCategoryHandler(DeleteCategoryDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new DeleteCategoryDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return false;
            }
            var category = this.CategoryRepository.GetCategoryByCategoryId(input.CategoryId);
            if (category == null)
            {
                ServerResponse.SetFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }
            category.Status = 0;
            this.DBContext.SaveChanges();
            return true;
        }
    }
}