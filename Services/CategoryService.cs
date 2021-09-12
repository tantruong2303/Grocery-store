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
        private readonly DBContext dBContext;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(DBContext dBContext, ICategoryRepository categoryRepository)
        {
            this.dBContext = dBContext;
            this.categoryRepository = categoryRepository;
        }

        public bool createCategoryHandler(CreateCategoryDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new CreateCategoryDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }
            var isExistCategory = this.categoryRepository.GetCategoryByCategoryName(input.Name);
            if (isExistCategory != null)
            {
                ServerResponse.setFieldErrorMessage("name", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }

            var category = new Category();
            category.categoryId = Guid.NewGuid().ToString();
            category.name = input.Name;
            category.description = input.Description;
            category.status = (CategoryStatus)1;
            category.createDate = DateTime.Now.ToShortDateString();
            this.dBContext.category.Add(category);
            this.dBContext.SaveChanges();
            return true;
        }

        public bool updateCategoryHandler(UpdateCategoryDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new UpdateCategoryDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }
            var category = this.categoryRepository.GetCategoryByCategoryId(input.CategoryId);
            if (category == null)
            {
                ServerResponse.setFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }
            category.name = input.Name;
            category.description = input.Description;
            this.dBContext.SaveChanges();
            return true;

        }

        public bool deleteCategoryHandler(DeleteCategoryDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new DeleteCategoryDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }
            var category = this.categoryRepository.GetCategoryByCategoryId(input.CategoryId);
            if (category == null)
            {
                ServerResponse.setFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }
            category.status = 0;
            this.dBContext.SaveChanges();
            return true;
        }
    }
}