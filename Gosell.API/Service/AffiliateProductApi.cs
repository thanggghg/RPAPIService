using System.Net;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Queries.AffiliateProduct;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Extensions.JWT;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using GoSell.Library.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public class AffiliateProductApi
    {

        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateProductViewModel>>>, BadRequest<string>>> GetAllAffiliateProductAsync(
           [AsParameters] GetAllAffiliateProductQuery request,
           [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateProductViewModel>>>, BadRequest<string>>> GetAPIAffiliateProductAsync(
          [AsParameters] GetAPIAffiliateProductQuery request,
          [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var command = new GetBaseSpecificAffiliateStoreByIdQuery(request.AffiliateStoreId);
                var resultAffiliateStore = await services.Mediator.Send(command);

                var verifytoken = new VerifyTokenAPICommand()
                {
                    token = request.TokenAPI
                };
                var payload = await services.Mediator.Send(verifytoken);

                if (payload.APIKey == resultAffiliateStore.ApiKey && payload.AffiliateStoreId == resultAffiliateStore.Id)
                {
                    var result = await services.Mediator.Send(request);
                    return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.OK, "Request successfully", result));
                }
                else
                {
                    return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.Unauthorized, "Unauthorized"));
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateProductViewModel>>>, BadRequest<string>>> GetAffiliateProductViewPublisherAsync(
           [AsParameters] GetAffiliateProductViewPublisherQuery request,
           [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateProductViewPublisherAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateProductViewModel>>>, BadRequest<string>>> GetAffiliateProductViewPublisherPreviewAsync(
           [AsParameters] GetAffiliateProductViewPublisherQuery request,
           [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateProductViewPublisherAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateProductViewModel>>, BadRequest<string>>> GetSpecificAffiliateProductAsync(
            long id,
            [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var command = new GetSpecificAffiliateProductQuery(id);

                var result = await services.Mediator.Send(command);
                return TypedResults.Ok(new GenericResponse<AffiliateProductViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateProductViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateProductViewModel>>>, BadRequest<string>>> GetAllAffiliateProductByStoreIdAsync(
            [AsParameters] GetAllAffiliateProductByStoreIdQuery request,
            [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var command = new GetAllAffiliateProductByStoreIdQuery
                {
                    AffiliateStoreId = request.AffiliateStoreId,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    IsPaging = request.IsPaging
                };

                var result = await services.Mediator.Send(command);

                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateProductByStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> AddAffiliateProductAsync(
            AffiliateProductRequest productRequest,
           [AsParameters] AffiliateProductServices services,
           IBaseApi baseApi)
        {
            try
            {
                var commandProduct = new CreateAffiliateProductCommand()
                {
                    ImageUrl = productRequest.ImageUrl,
                    RefProductId = productRequest.RefProductId,
                    Name = productRequest.Name,
                    CategoryId = productRequest.CategoryId,
                    Description = productRequest.Description,
                    ProductUrl = productRequest.ProductUrl,
                    RegularPrice = productRequest.RegularPrice,
                    SalePrice = productRequest.SalePrice,
                    IsOutOfStock = productRequest.IsOutOfStock,
                    IsStopSelling = productRequest.IsStopSelling,
                    IsPercentage = productRequest.IsPercentage,
                    Percentage = productRequest.Percentage,
                    IsFixValue = productRequest.IsFixValue,
                    FixValue = productRequest.FixValue,
                    IsActive = true,
                    AffiliateStoreId = productRequest.AffiliateStoreId,
                };

                var result = await services.Mediator.Send(commandProduct);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> APIAffiliateProductAsync(
           AffiliateProductRequest productRequest,
          [AsParameters] AffiliateProductServices services,
          IBaseApi baseApi)
        {
            try
            {
                var command = new GetBaseSpecificAffiliateStoreByIdQuery(productRequest.AffiliateStoreId);
                var resultAffiliateStore = await services.Mediator.Send(command);

                var verifytoken = new VerifyTokenAPICommand()
                {
                    token = productRequest.TokenAPI
                };
                var payload = await services.Mediator.Send(verifytoken);

                if(payload.APIKey == resultAffiliateStore.ApiKey && payload.AffiliateStoreId == resultAffiliateStore.Id)
                {
                    if(productRequest.RefProductId != null)
                    { 
                        var commandAffPro = new GetBaseSpecificAffiliateProductQuery(productRequest.Id);

                        var resultQuery = await services.Mediator.Send(commandAffPro);
                            if (resultQuery == null)
                            {
                                var commandProduct = new CreateAffiliateProductCommand()
                                {
                                    ImageUrl = productRequest.ImageUrl,
                                    RefProductId = productRequest.RefProductId,
                                    Name = productRequest.Name,
                                    CategoryId = productRequest.CategoryId,
                                    Description = productRequest.Description,
                                    ProductUrl = productRequest.ProductUrl,
                                    RegularPrice = productRequest.RegularPrice,
                                    SalePrice = productRequest.SalePrice,
                                    IsOutOfStock = productRequest.IsOutOfStock,
                                    IsStopSelling = productRequest.IsStopSelling,
                                    IsPercentage = productRequest.IsPercentage,
                                    Percentage = productRequest.Percentage,
                                    IsFixValue = productRequest.IsFixValue,
                                    FixValue = productRequest.FixValue,
                                    IsActive = true,
                                    AffiliateStoreId = productRequest.AffiliateStoreId,
                                };
                                var result = await services.Mediator.Send(commandProduct);
                                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
                            }
                            else
                            {
                                var commandProduct = new UpdateBaseAffiliateProductCommand()
                                {
                                    Id = productRequest.Id,
                                    ImageUrl = productRequest.ImageUrl,
                                    RefProductId = productRequest.RefProductId,
                                    Name = productRequest.Name,
                                    CategoryId = productRequest.CategoryId,
                                    Description = productRequest.Description,
                                    ProductUrl = productRequest.ProductUrl,
                                    RegularPrice = productRequest.RegularPrice,
                                    SalePrice = productRequest.SalePrice,
                                    IsOutOfStock = productRequest.IsOutOfStock,
                                    IsStopSelling = productRequest.IsStopSelling,
                                    IsPercentage = productRequest.IsPercentage,
                                    Percentage = productRequest.Percentage,
                                    IsFixValue = productRequest.IsFixValue,
                                    FixValue = productRequest.FixValue,
                                    IsDelete = productRequest.IsDelete,
                                    IsActive = productRequest.IsActive,
                                    AffiliateStoreId = productRequest.AffiliateStoreId,
                                    CollectionId = productRequest.CollectionId,
                                };
                                if (productRequest.IsDelete != null)
                                {
                                    commandProduct.IsDelete = productRequest.IsDelete.Value;
                                }
                                var result = await services.Mediator.Send(commandProduct);
                                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
                            }
                        
                    }
                    else
                    {
                        return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
                    }
                }
                else
                {
                    return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.Unauthorized, "Unauthorized"));
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> UpdateAffiliateProductAsync(
            AffiliateProductRequest productRequest,
           [AsParameters] AffiliateProductServices services,
           IBaseApi baseApi)
        {
            try
            {
                var commandProduct = new UpdateAffiliateProductCommand()
                {
                    Id = productRequest.Id,
                    ImageUrl = productRequest.ImageUrl,
                    RefProductId = productRequest.RefProductId,
                    Name = productRequest.Name,
                    CategoryId = productRequest.CategoryId,
                    Description = productRequest.Description,
                    ProductUrl = productRequest.ProductUrl,
                    RegularPrice = productRequest.RegularPrice,
                    SalePrice = productRequest.SalePrice,
                    IsOutOfStock = productRequest.IsOutOfStock,
                    IsStopSelling = productRequest.IsStopSelling,
                    IsPercentage = productRequest.IsPercentage,
                    Percentage = productRequest.Percentage,
                    IsFixValue = productRequest.IsFixValue,
                    FixValue = productRequest.FixValue,
                    IsActive = productRequest.IsActive,
                    AffiliateStoreId = productRequest.AffiliateStoreId,
                    CollectionId = productRequest.CollectionId,
                };

                var result = await services.Mediator.Send(commandProduct);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<ImportAffiliateProductResult>>, BadRequest<string>>> ImportAffiliateProductAsync(
           [FromForm] IFormFile file,
           string langKey,
           long affiliateStoreId,
           IBaseApi baseApi,
           [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var command = new ImportAffiliateProductCommand(file, langKey, affiliateStoreId, baseApi.User.StoreId);

                var result = await services.Mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(ImportAffiliateProductAsync)}");
                return TypedResults.Ok(new GenericResponse<ImportAffiliateProductResult>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AddAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<ImportAffiliateProductResult>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> DeleteAffiliateProductAsync(
            long id,
           [AsParameters] AffiliateProductServices services,
           IBaseApi baseApi)
        {
            try
            {
                var commandProduct = new DeleteAffiliateProductCommand(id, baseApi.User.Sub);

                var result = await services.Mediator.Send(commandProduct);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(DeleteAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> ChangeStatusAffiliateProductAsync(
           long affiliateStoreId,
           long id,
           ChangeStatusAffiliateProductRequest productRequest,
          [AsParameters] AffiliateProductServices services,
          IBaseApi baseApi)
        {
            try
            {
                var commandProduct = new ChangeStatusAffiliateProductCommand(id, affiliateStoreId, productRequest.isActive, baseApi.User.Sub);

                var result = await services.Mediator.Send(commandProduct);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ChangeStatusAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateMultipleAffiliateProductAsync(
           UpdateMultipleAffiliateProductRequest request,
          [AsParameters] AffiliateProductServices services,
          IBaseApi baseApi)
        {
            try
            {
                var commandProduct = new UpdateMultipleAffiliateProductCommand(request.actionType, request.productIds, request.affiliateStoreId, baseApi.User.Sub);

                var result = await services.Mediator.Send(commandProduct);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ChangeStatusAffiliateProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CheckDuplicateRefIdAsync(
              CheckDuplicateRefIdRequest request,
              [AsParameters] AffiliateProductServices services,
              IBaseApi baseApi)
        {
            try
            {
                var command = new CheckDuplicateRefIdCommand()
                {
                    Id = request.id,
                    AffiliateStoreId = request.affiliateStoreId
                };

                var result = await services.Mediator.Send(command);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CheckDuplicateRefIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> GetProductLinkToPublisherPageAsync(
            long id,
            [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var query = new GetProductLinkQuery(id);

                var result = await services.Mediator.Send(query);

                Log.Logger.Information($"DONE {nameof(GetProductLinkToPublisherPageAsync)}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.OK, "Request successfully", result.Data));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetProductLinkToPublisherPageAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> GetAffiliateProductLinkTrackingAsync(
        string refId,
        [AsParameters] AffiliateProductServices services, IBaseApi baseApi)
        {
            try
            {
                var command = new GetAffiliateProductLinkTrackingQuery()
                {
                    RefProductId = refId,
                    IsPublisher = false,
                    UserLogin = baseApi.User.Sub,
                    UserId = baseApi.User.UserId,
                };
                var result = await services.Mediator.Send(command);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateProductViewPublisherAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<byte[]>>, BadRequest<string>>> ExportImportProductTemplate(
     [AsParameters] ExportProductImportTemplateQuery query,
    [AsParameters] AffiliateProductServices services, IBaseApi baseApi)
        {
            try
            {
                var result = await services.Mediator.Send(query);
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.OK, "Export product import template successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ExportImportProductTemplate)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.BadRequest, "Export product import template failed", null));
            }
        }
        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> GetAffiliateProductLinkTrackingFromPublisherAsync(
        string refId,
        [AsParameters] AffiliateProductServices services, IBaseApi baseApi)
        {
            try
            {
                var command = new GetAffiliateProductLinkTrackingQuery()
                {
                    RefProductId = refId,
                    IsPublisher = true,
                    UserLogin = baseApi.User.Sub,
                    UserId = baseApi.User.UserId
                };
                var result = await services.Mediator.Send(command);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateProductViewPublisherAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateProductAddCampaignViewModel>>>, BadRequest<string>>> GetProductsAddCampaignAsync(
            [AsParameters] GetProductsAddCampaignRequest request,
            IBaseApi baseApi,
            [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var command = new GetProductsAddCampaignQuery
                {
                    AffiliateStoreId = request.AffiliateStoreId,
                    StoreId = baseApi.User.StoreId,
                    Keyword = request.Keyword,
                    SearchType = request.SearchType,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    IsPaging = request.IsPaging
                };

                var result = await services.Mediator.Send(command);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateProductByStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateProductAddCampaignViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<byte[]>>, BadRequest<string>>> ResizeImageAsync(
             [FromForm] IFormFile file,
            [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var resizeImageCommand = new ResizeImageCommand()
                {
                    Image = file,
                };
             
                var result = await services.Mediator.Send(resizeImageCommand);

                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ResizeImageAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> CreateTokenAPIAsync(AffiliateTokenProductRequest tokenRequest, [AsParameters] AffiliateProductServices services, IBaseApi baseApi)
        {
            try
            {
                var createTokenAPICommand = new CreateTokenAPICommand()
                {
                    AffiliateStoreId = tokenRequest.affiliateStoreId,
                    APIKey = tokenRequest.APIKey
                };
                var result = await services.Mediator.Send(createTokenAPICommand);

                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateTokenAPIAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> VerifyTokenAPIAsync( string token, [AsParameters] AffiliateProductServices services, IBaseApi baseApi)
        {
            try
            {
                var verifytoken = new VerifyTokenAPICommand()
                {
                    token  = token
                };
                var result = await services.Mediator.Send(verifytoken);

                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.OK, "Request successfully", result.ToString()));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateTokenAPIAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<string>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public record ChangeStatusAffiliateProductRequest(
        bool? isActive

        );

        public record UpdateMultipleAffiliateProductRequest(
        string actionType,
        List<long> productIds,
        long affiliateStoreId
        );

        public record CheckDuplicateRefIdRequest(
          string id,
          long affiliateStoreId
        );
    }
}
