using FluentValidation.Results;
using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Pipe;
using Backend.Models;
using Backend.Services.Interface;
using Backend.Controllers.DTO;
using Backend.Utils.Common;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Backend.Utils.Interface;

namespace Backend.Controllers
{
    [Route("/api/product")]
    [RoleGuardAttribute(new UserRole[] { UserRole.MANGER })]
    [ServiceFilter(typeof(AuthGuard))]
    public class ProductApiController : Controller
    {
        private readonly IProductService ProductService;
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryService CategoryService;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IUploadFileService UploadFileService;


        public ProductApiController(IProductService productService, IProductRepository productRepository, ICategoryService categoryService, ICategoryRepository categoryRepository, IUploadFileService uploadFileService)
        {
            this.ProductService = productService;
            this.ProductRepository = productRepository;
            this.CategoryService = categoryService;
            this.CategoryRepository = categoryRepository;
            this.UploadFileService = uploadFileService;
        }

        [HttpPost("")]
        public IActionResult HandleCreateProduct([FromBody] CreateProductDTO body)
        {
            var res = new ServerApiResponse<Product>();
            ValidationResult result = new CreateProductDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var isExistCategory = this.CategoryRepository.GetCategoryByCategoryId(body.CategoryId);
            if (isExistCategory == null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, "categoryId");
                return new NotFoundObjectResult(res.getResponse());
            }

            var isExistProduct = this.ProductRepository.GetProductByProductName(body.Name);
            if (isExistProduct != null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, "Name");
                return new BadRequestObjectResult(res.getResponse());
            }

            var validFile = this.UploadFileService.CheckFileExtension(body.File) && this.UploadFileService.CheckFileSize(body.File, 5);
            if (!validFile)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_INVALID_FILE, "File");
                return new BadRequestObjectResult(res.getResponse());
            }

            var imageUrl = this.UploadFileService.Upload(body.File);
            if (imageUrl == null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_UPLOAD_FILE_FAILED, "File");
                return new BadRequestObjectResult(res.getResponse());
            }

            var product = new Product();
            product.ProductId = Guid.NewGuid().ToString();
            product.Name = body.Name;
            product.Description = body.Description;
            product.Status = (ProductStatus)0;
            product.RetailPrice = body.RetailPrice;
            product.OriginalPrice = body.OriginalPrice;
            product.CreateDate = DateTime.Now.ToShortDateString();
            product.Quantity = body.Quantity;
            product.ImageUrl = imageUrl;
            product.CategoryId = body.CategoryId;

            this.ProductService.CreateProductHandler(product);

            res.data = product;
            res.setErrorMessage(CustomLanguageValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Product");
            return new ObjectResult(res.getResponse());
        }


        [HttpPut("")]
        public IActionResult HandleUpdateProduct([FromBody] UpdateProductDTO body)
        {
            var res = new ServerApiResponse<Product>();
            ValidationResult result = new UpdateProductDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var product = this.ProductRepository.GetProductById(body.ProductId);
            if (product == null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, "ProductId");
                return new NotFoundObjectResult(res.getResponse());
            }

            var isExistCategory = this.CategoryRepository.GetCategoryByCategoryId(body.CategoryId);
            if (isExistCategory == null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, "CategoryID");
                return new NotFoundObjectResult(res.getResponse());
            }

            if (product.Name != body.Name)
            {
                var isExistProduct = this.ProductRepository.GetProductByProductName(body.Name);
                if (isExistProduct != null)
                {
                    res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, "Name");
                    return new BadRequestObjectResult(res.getResponse());
                }
            }

            if (body.File != null)
            {
                var validFile = this.UploadFileService.CheckFileExtension(body.File) && this.UploadFileService.CheckFileSize(body.File, 5);
                if (!validFile)
                {
                    res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_INVALID_FILE, "File");
                    return new BadRequestObjectResult(res.getResponse());
                }

                var imageUrl = this.UploadFileService.Upload(body.File);
                if (imageUrl == null)
                {
                    res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_UPLOAD_FILE_FAILED, "File");
                    return new BadRequestObjectResult(res.getResponse());
                }

                product.ImageUrl = imageUrl;
            }


            product.Name = body.Name;
            product.Description = body.Description;
            product.Status = body.Status;
            product.RetailPrice = body.RetailPrice;
            product.OriginalPrice = body.OriginalPrice;
            product.CreateDate = DateTime.Now.ToShortDateString();
            product.Quantity = body.Quantity;
            product.CategoryId = body.CategoryId;

            this.ProductService.UpdateProductHandler(product);

            res.data = product;
            res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_UPDATE_SUCCESS);
            return new ObjectResult(res.getResponse());
        }

    }
}