using backend.Services.Interface;
using System;
using backend.Controllers.DTO;
using FluentValidation.Results;
using backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using backend.Utils;
using backend.DAO.Interface;
using backend.Utils.Locale;
using backend.Models;
using backend.Utils.Interface;
using System.Linq;

namespace backend.Services
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
            var isExistCategory = this.categoryRepository.getCategoryByCategoryName(input.name);
            if (isExistCategory != null)
            {
                ServerResponse.setFieldErrorMessage("name", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }

            var category = new Category();
            category.categoryId = Guid.NewGuid().ToString();
            category.name = input.name;
            category.description = input.description;
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
            var category = this.categoryRepository.getCategoryByCategoryId(input.categoryId);
            if (category == null)
            {
                ServerResponse.setFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }
            category.name = input.name;
            category.description = input.description;
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
            var category = this.categoryRepository.getCategoryByCategoryId(input.categoryId);
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