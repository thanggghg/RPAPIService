using System.Data.Entity;
using System.Net;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Queries.AffiliateProduct;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Db;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using GoSell.Library.Helpers.Service;
using GoSell.Library.Seedwork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;



namespace GoSell.Affiliate.Tracking.Functions.Implementation
{
    public class AffiliateProductFunctions : IAffiliateProductFunctions
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        private readonly IBaseService _baseService;
        private readonly ILogger<AffiliateProductFunctions> _logger;
        private readonly AffiliateContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        private const string LANG_VI = "vi";

        public IUnitOfWork UnitOfWork => _context;
        public AffiliateProductFunctions(IAffiliateProductRepository affiliateProductRepository,
                                                  IMapper mapper,
                                                  IBaseApi baseApi,
                                                  AffiliateContext affiliateContext,
                                                  IConfiguration configuration,
                                                  ILogger<AffiliateProductFunctions> logger,
                                                  IWebHostEnvironment environment,
                                                  IBaseService baseService)
        {
            _affiliateProductRepository = affiliateProductRepository;
            _mapper = mapper;
            _baseApi = baseApi;
            _context = affiliateContext;
            _configuration = configuration;
            _logger = logger;
            _environment = environment;
            _baseService = baseService;
        }
        public async Task<BaseResponse> CreateAffiliateProduct(CreateAffiliateProductCommand request)
        {
            //var existAffiliateProduct = await _affiliateProductRepository.GetDeletedAffProductByRefIdAsync(request.RefProductId, request.AffiliateStoreId);

            var existAffProductByRefProductId = await _affiliateProductRepository.GetAffProductByRefIdAsync(request.RefProductId, request.AffiliateStoreId);

            //if (existAffiliateProduct != null)
            //{
            //    existAffiliateProduct.ImageUrl = request.ImageUrl;
            //    existAffiliateProduct.Name = request.Name;
            //    existAffiliateProduct.RefProductId = request.RefProductId;
            //    existAffiliateProduct.CategoryId = request.CategoryId;
            //    existAffiliateProduct.ProductUrl = request.ProductUrl;
            //    existAffiliateProduct.RegularPrice = request.RegularPrice;
            //    existAffiliateProduct.SalePrice = request.SalePrice;
            //    existAffiliateProduct.IsOutOfStock = request.IsOutOfStock;
            //    existAffiliateProduct.IsStopSelling = request.IsStopSelling;
            //    existAffiliateProduct.IsPercentage = request.IsPercentage;
            //    existAffiliateProduct.Percentage = request.Percentage;
            //    existAffiliateProduct.IsFixValue = request.IsFixValue;
            //    existAffiliateProduct.FixValue = request.FixValue;
            //    existAffiliateProduct.CollectionId = request.CollectionId;
            //    existAffiliateProduct.IsDeleted = false;

            //    await _affiliateProductRepository.Update(existAffiliateProduct);
            //}
            //else
            //{
                if (existAffProductByRefProductId != null)
                {
                    return new BaseResponse(HttpStatusCode.BadRequest, "Ref product id is existed");
                }
                else { 
                    var affiliateProduct = _mapper.Map<AffiliateProduct>(request);
                    affiliateProduct.AffiliateStoreId = request.AffiliateStoreId;
                    await _affiliateProductRepository.Add(affiliateProduct);
                }
            //}

            return new BaseResponse(HttpStatusCode.OK, "Added Affiliate Product successfully");
        }

        public async Task<BaseResponse> UpdateAffiliateProduct(UpdateAffiliateProductCommand request)
        {
            var updateProduct = await _affiliateProductRepository.GetByIdAsync(request.Id);
            if (updateProduct == null || _baseService.isInvalidAffiliateStore(updateProduct.AffiliateStoreId, _baseApi.User.StoreId))
            {
                throw new Exception("Product not exist");
            }

            updateProduct.ImageUrl = request.ImageUrl;
            updateProduct.Name = request.Name;
            updateProduct.RefProductId = request.RefProductId;
            updateProduct.CategoryId = request.CategoryId;
            //updateProduct.Description = request.Description;
            updateProduct.ProductUrl = request.ProductUrl;
            updateProduct.RegularPrice = request.RegularPrice;
            updateProduct.SalePrice = request.SalePrice;
            updateProduct.IsOutOfStock = request.IsOutOfStock;
            updateProduct.IsStopSelling = request.IsStopSelling;
            updateProduct.IsPercentage = request.IsPercentage;
            updateProduct.Percentage = request.Percentage;
            updateProduct.IsFixValue = request.IsFixValue;
            updateProduct.FixValue = request.FixValue;
            updateProduct.CollectionId = request.CollectionId;
            updateProduct.AffiliateStoreId = request.AffiliateStoreId;

            await _affiliateProductRepository.Update(updateProduct);
            return new BaseResponse(HttpStatusCode.OK, "Updated Affiliate Product successfully");
        }

        public async Task<BaseResponse> UpdateBaseAffiliateProduct(UpdateBaseAffiliateProductCommand request)
        {
            var updateProduct = await _affiliateProductRepository.GetByIdAsync(request.Id);
            if (updateProduct == null)
            {
                throw new Exception("Product not exist");
            }

            updateProduct.ImageUrl = request.ImageUrl;
            updateProduct.Name = request.Name;
            updateProduct.RefProductId = request.RefProductId;
            updateProduct.CategoryId = request.CategoryId;
            //updateProduct.Description = request.Description;
            updateProduct.ProductUrl = request.ProductUrl;
            updateProduct.RegularPrice = request.RegularPrice;
            updateProduct.SalePrice = request.SalePrice;
            updateProduct.IsOutOfStock = request.IsOutOfStock;
            updateProduct.IsStopSelling = request.IsStopSelling;
            updateProduct.IsPercentage = request.IsPercentage;
            updateProduct.Percentage = request.Percentage;
            updateProduct.IsFixValue = request.IsFixValue;
            updateProduct.FixValue = request.FixValue;
            updateProduct.CollectionId = request.CollectionId;
            updateProduct.AffiliateStoreId = request.AffiliateStoreId;

            await _affiliateProductRepository.Update(updateProduct);
            return new BaseResponse(HttpStatusCode.OK, "Updated Affiliate Product successfully");
        }
        public async Task<BaseResponse> DeleteAffiliateProduct(DeleteAffiliateProductCommand request)
        {
            var deleteProduct = await _affiliateProductRepository.GetByIdAsync(request.Id);
            if (deleteProduct == null || _baseService.isInvalidAffiliateStore(deleteProduct.AffiliateStoreId, _baseApi.User.StoreId))
            {
                throw new Exception("Product not exist");
            }

            deleteProduct.IsDeleted = true;
            deleteProduct.LastModifiedBy = request.UserLogin;

            await _affiliateProductRepository.Update(deleteProduct);

            return new BaseResponse(HttpStatusCode.OK, "Deleted Affiliate Product successfully");
        }

        public async Task<BaseResponse> ChangeStatusAffiliateProduct(ChangeStatusAffiliateProductCommand request)
        {
            var ChangeStatusProduct = await _affiliateProductRepository.GetByIdAsync(request.Id, request.AffiliateStoreId);
            if (ChangeStatusProduct == null)
            {
                throw new Exception("Product not exist");
            }

            ChangeStatusProduct.LastModifiedBy = request.UserLogin;

            await _affiliateProductRepository.Update(ChangeStatusProduct);

            return new BaseResponse(HttpStatusCode.OK, "Change Status Affiliate Product successfully");
        }

        public async Task<BaseResponse> UpdateMultipleAffiliateProduct(UpdateMultipleAffiliateProductCommand request)
        {
            var products = _affiliateProductRepository.GetProductByIds(request.ProductIds);

            if (products.Any())
            {
                var affIds = products.Select(x => x.AffiliateStoreId).Distinct().ToList();
                affIds.ForEach(affId =>
                {
                    if (_baseService.isInvalidAffiliateStore(affId, _baseApi.User.StoreId))
                    {
                        throw new Exception($"Affiliate Store Id {affId} on Go Sell store {_baseApi.User.StoreId} not exist");
                    }
                });

                var actionType = request.ActionType;
                var userLogin = request.UserLogin;

                if (actionType == UpdateProductActionType.DeleteMultipleProduct)
                {
                    foreach (var item in products)
                    {
                        item.IsDeleted = true;
                        item.LastModifiedBy = userLogin;
                    }
                }
                else if (actionType == UpdateProductActionType.SetInStock || actionType == UpdateProductActionType.SetOutOfStock)
                {
                    foreach (var item in products)
                    {
                        item.IsOutOfStock = actionType == UpdateProductActionType.SetOutOfStock;
                        item.LastModifiedBy = userLogin;
                    }
                }
                else if (actionType == UpdateProductActionType.SetSelling || actionType == UpdateProductActionType.SetStopSelling)
                {
                    foreach (var item in products)
                    {
                        item.IsStopSelling = actionType == UpdateProductActionType.SetStopSelling;
                        item.LastModifiedBy = userLogin;
                    }
                }
                var res = await _affiliateProductRepository.UpdateMultipleAffiliateProduct(products);
            }

            return new BaseResponse(HttpStatusCode.OK, "Success");
        }

        public async Task<GenericResponse<bool>> CheckDuplicateRefIdAsync(CheckDuplicateRefIdCommand request)
        {
            if (_baseService.isInvalidAffiliateStore(request.AffiliateStoreId ?? 0, _baseApi.User.StoreId))
            {
                return new GenericResponse<bool>(HttpStatusCode.OK, "Check Duplicate RefId", false);
            }

            var res = await _affiliateProductRepository.GetByRefIdWithAffiliateStoreIdAsync(request.Id, request.AffiliateStoreId ?? 0);

            return new GenericResponse<bool>(HttpStatusCode.OK, "Check Duplicate RefId", res == null);
        }

        public async Task<GenericResponse<string>> GetProductLinkToPublisherPage(GetProductLinkQuery request)
        {
            string productLink = string.Empty;
            var affProduct = await _affiliateProductRepository.GetByIdAsync(request.Id);

            if (affProduct == null || _baseService.isInvalidAffiliateStore(affProduct.AffiliateStoreId, _baseApi.User.StoreId))
            {
                return new GenericResponse<string>(HttpStatusCode.BadRequest, "Product is not exist", string.Empty);
            }
            else
            {
                var affiliateStore = _context.AffiliateStore.FirstOrDefault(x => x.Id == affProduct.AffiliateStoreId);
                if (affiliateStore != null)
                {
                    string subDomain = affiliateStore.Website;
                    string baseUrl = _configuration.GetSectionValueWithEnvironment("ApiBaseUrl");
                    Uri baseUri = new Uri(baseUrl);
                    productLink = string.Format("{0}/affiliate/product/{1}", subDomain, affProduct.RefProductId);
                    return new GenericResponse<string>(HttpStatusCode.OK, "Get product link to publisher page successfully", productLink);
                }
                else
                {
                    return new GenericResponse<string>(HttpStatusCode.BadRequest, "Affiliate store is not exist", string.Empty);
                }
            }
        }
        public async Task<byte[]> ExportProductImportTemplate(ExportProductImportTemplateQuery request)
        {
            try
            {
                string fullPath = Path.Combine(_environment.ContentRootPath, "Templates", request.LangKey.ToLower(), "affiliate-product-template-import_template_EN.xlsx");
                if (request.LangKey.ToUpper() == LANG_VI.ToUpper())
                {
                    fullPath = Path.Combine(_environment.ContentRootPath, "Templates", request.LangKey.ToLower(), "affiliate-product-template-import_template_VI.xlsx");
                }

                _logger.LogInformation($"{nameof(ExportProductImportTemplateQuery)}: Get  templateFileName file success: {fullPath} ");
                using (var templateMemoryStream = new MemoryStream())
                {
                    using (var fileStream = File.OpenRead(fullPath))
                    {
                        await fileStream.CopyToAsync(templateMemoryStream);
                        templateMemoryStream.Seek(0, SeekOrigin.Begin);
                    }

                    // Get template file bytes
                    var templateFileBytes = templateMemoryStream.ToArray();
                    // Return template file bytes
                    return templateFileBytes;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"FAIL {nameof(ExportProductImportTemplateQuery)} : {ex.Message}");
                throw new Exception($"Export import product template failed. {ex.Message}");
            }
        }

        public async Task<PagingItems<AffiliateProductViewModel>> GoToPublisherPage(long id)
        {
            var affiliateProducts = await _context.AffiliateProducts.Where(x => x.AffiliateStoreId == _baseApi.User.AffiliateStoreId).ToListAsync();

            var desiredProduct = affiliateProducts.FirstOrDefault(p => p.Id == id);

            if (desiredProduct != null)
            {
                affiliateProducts.Remove(desiredProduct);
                affiliateProducts.Insert(0, desiredProduct);
            }

            return affiliateProducts != null ? _mapper.Map<PagingItems<AffiliateProductViewModel>>(affiliateProducts) : null;
        }


        public List<ProductCateInfoVM> GetProductAndCategoryInfoByProductIds(ProductCateInfoRequest productInfo)
        {
            List<ProductCateInfoVM> res = new List<ProductCateInfoVM>();
            if (productInfo == null) { return res; }
            var lsProductIds = productInfo.AffiliateProductIds.ToList();
            var query = (from p in _context.AffiliateProducts
                         join c in _context.AffiliateCategory
                         on p.CategoryId equals c.Id
                         where p.AffiliateStoreId == productInfo.AffiliateStoreId
                             && c.AffiliateStoreId == productInfo.AffiliateStoreId
                             && p.CategoryId.HasValue
                             && lsProductIds.Any(x => x == p.RefProductId)
                         select new ProductCateInfoVM()
                         {
                             Id = p.Id,
                             RefProductId = p.RefProductId,
                             ProductName = p.Name,
                             CategoryId = p.CategoryId,
                             CategoryName = c.Name,
                             RefCategoryId = c.RefCategoryId,
                             IsActive = p.IsDeleted
                         }).AsQueryable();

            var data = query.ToList();
            if (data != null && data.Count > 0)
            {
                res = data;
            }
            return res;
        }

        public List<ProductCateInfoVM> GetProductCategoryMappings(ProductCateInfoRequest productInfo)
        {
            List<ProductCateInfoVM> res = new List<ProductCateInfoVM>();
            if (productInfo == null) { return res; }
            var lsProductIds = productInfo.AffiliateProductIds.ToList();
            var query = (from p in _context.AffiliateProducts
                         join c in _context.AffiliateCategory
                         on p.CategoryId equals c.Id into categoryGroup
                         from category in categoryGroup.DefaultIfEmpty()
                         where p.AffiliateStoreId == productInfo.AffiliateStoreId
                               && (category == null || category.AffiliateStoreId == productInfo.AffiliateStoreId)
                               && lsProductIds.Contains(p.RefProductId)
                         select new ProductCateInfoVM()
                         {
                             Id = p.Id,
                             RefProductId = p.RefProductId,
                             ProductName = p.Name,
                             CategoryId = p.CategoryId,
                             CategoryName = category.Name,
                             RefCategoryId = category.RefCategoryId,
                             IsActive = !p.IsDeleted
                         }).AsQueryable();

            var data = query.ToList();
            if (data != null && data.Count > 0)
            {
                res = data;
            }
            return res;
        }

        public async Task<byte[]> ResizeImage(ResizeImageCommand request)
        {
            using var image = await Image.LoadAsync(request.Image.OpenReadStream());

            // Check if the image width is greater than 480 and resize if necessary
            if (image.Width > 480)
            {
                image.Mutate(x => x.Resize(480, 480)); // Resizes while maintaining aspect ratio

                using var ms = new MemoryStream();
                await image.SaveAsJpegAsync(ms); // Save the resized image to the memory stream
                return ms.ToArray(); // Return the image as a byte array
            }

            return [];
        }
    }
}
