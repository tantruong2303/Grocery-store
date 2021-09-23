using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Pipe;
using Backend.Models;
using Backend.Services.Interface;
using Backend.Controllers.DTO;
using grocery_store.Utils.Common;
using Backend.DAO.Interface;
using Backend.Utils.Locale;

namespace Backend.Controllers
{
    [Route("/api/category")]
    [RoleGuardAttribute(new UserRole[] { UserRole.MANGER })]
    [ServiceFilter(typeof(AuthGuard))]
    public class CategoryApiController : Controller
    {
        private readonly ICategoryService CategoryService;
        private readonly ICategoryRepository CategoryRepository;

        public CategoryApiController(ICategoryService categoryService, ICategoryRepository categoryRepository)
        {
            this.CategoryService = categoryService;
            this.CategoryRepository = categoryRepository;
        }


        [HttpPost("create")]
        public IActionResult HandleCreateCategory([FromBody] CreateCategoryDTO body)
        {
            var res = new ServerApiResponse<string>();
            ValidationResult result = new CreateCategoryDTOValidator().Validate(body);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var isExistCategory = this.CategoryRepository.GetCategoryByCategoryName(body.Name);
            if (isExistCategory != null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, "Name");
                return new BadRequestObjectResult(res.getResponse()); ;
            }

            var category = new Category();
            category.CategoryId = Guid.NewGuid().ToString();
            category.Name = body.Name;
            category.Description = body.Description;
            category.Status = (CategoryStatus)body.Status;
            category.CreateDate = DateTime.Now.ToShortDateString();

            this.CategoryService.CreateCategoryHandler(category);


            res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_ADD_SUCCESS);
            return new ObjectResult(res.getResponse());
        }

    }
}