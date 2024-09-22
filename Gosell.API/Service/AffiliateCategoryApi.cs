using System.Net;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateCategory;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Queries.AffiliateCategory;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public class AffiliateCategoryApi
    {
        public static async Task<Results<Ok<GenericResponse<AffiliateCategoryViewModel>>, BadRequest<string>>> GetSpecificAffiliateCategoryAsync(
            long id,
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var query = new GetSpecificAffiliateCategoryQuery(id);

                var result = await services.Mediator.Send(query);

                return TypedResults.Ok(new GenericResponse<AffiliateCategoryViewModel>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateCategoryViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        
        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateCategoryViewModel>>>, BadRequest<string>>> GetAllAffiliateCategoryAsync(
            [AsParameters] GetAllAffiliateCategoryQuery request,
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var query = new GetAllAffiliateCategoryQuery()
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    Keyword = request.Keyword,
                    SearchType = request.SearchType,
                    Status = request.Status,
                    StoreStatus = request.StoreStatus,
                    IsPaging = request.IsPaging ?? true,
                    AffiliateStoreId = request.AffiliateStoreId,
                };

                var result = await services.Mediator.Send(query);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateCategoryAsync)}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCategoryViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCategoryViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateCategoryPublicViewModel>>>, BadRequest<string>>> GetAllAffiliateCategoryPublicAsync(
                    [AsParameters] GetAllAffiliateCategoryQuery request,
                    [AsParameters] AffiliateCategoryServices services)
        {
            try
            {

                var commandCategory = new GetBaseSpecificAffiliateStoreByIdQuery(request.AffiliateStoreId);
                var resultCategory = await services.Mediator.Send(commandCategory);

                var verifyToken = new VerifyTokenAPICommand()
                {
                    token = request.TokenAPI
                };
                var payload = await services.Mediator.Send(verifyToken);
                if (payload.APIKey == resultCategory.ApiKey && payload.AffiliateStoreId == resultCategory.Id)
                {
                    var query = new GetAllAffiliateCategoryPublicQuery()
                    {
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize,
                        Keyword = request.Keyword,
                        SearchType = request.SearchType,
                        Status = request.Status,
                        StoreStatus = request.StoreStatus,
                        IsPaging = request.IsPaging ?? true,
                        AffiliateStoreId = request.AffiliateStoreId,
                    };

                    var result = await services.Mediator.Send(query);

                    Log.Logger.Information($"DONE {nameof(GetAllAffiliateCategoryAsync)}");
                    return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCategoryPublicViewModel>>(HttpStatusCode.OK, "Request successfully", result));
                }
                else
                {
                    return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCategoryPublicViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
                }

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCategoryPublicViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> CreateAffiliateCategoryAsync(
            CreateAffiliateCategoryCommand request,
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var command = new CreateAffiliateCategoryCommand()
                {
                    Name = request.Name,
                    RefCategoryId = request.RefCategoryId,
                    AffiliateStoreId = request.AffiliateStoreId,
                };
                
                var result = await services.Mediator.Send(command);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> CreateAffiliateCategoryPublicAsync(
                    CreateAffiliateCategoryPublicCommand request,
                    [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var commandCategory = new GetBaseSpecificAffiliateStoreByIdQuery(request.AffiliateStoreId);
                var resultCategory = await services.Mediator.Send(commandCategory);

                var verifyToken = new VerifyTokenAPICommand()
                {
                    token = request.TokenAPI
                };
                var payload = await services.Mediator.Send(verifyToken);
                if (payload.APIKey == resultCategory.ApiKey && payload.AffiliateStoreId == resultCategory.Id)
                {
                    var command = new CreateAffiliateCategoryPublicCommand()
                    {
                        Name = request.Name,
                        RefCategoryId = request.RefCategoryId,
                        AffiliateStoreId = request.AffiliateStoreId,
                        Status = request.Status,
                        IsDeleted = request.IsDeleted,
                    };

                    var result = await services.Mediator.Send(command);

                    return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
                }
                else
                {
                    return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> UpdateAffiliateCategoryAsync(
            AffiliateCategoryRequest request,
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var command = new UpdateAffiliateCategoryCommand()
                {
                    Id = request.Id,
                    Name = request.Name,
                    RefCategoryId = request.RefCategoryId,
                    AffiliateStoreId= request.AffiliateStoreId,
                };
                
                var result = await services.Mediator.Send(command);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }


        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> DeleteAffiliateCategoryAsync(
            long id,            
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var command = new DeleteAffiliateCategoryCommand(id);

                var result = await services.Mediator.Send(command);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(DeleteAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> ChangeStatusAffiliateCategoryasync(
            ChangeStatusAffiliateCategoryCommand request,
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var result = await services.Mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ChangeStatusAffiliateCategoryasync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CheckDuplicateRefIdAsync(
            CheckDuplicateRefIdRequest request,
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var command = new CheckDuplicateRefIdAffilliateQuery()
                {
                    RefId = request.refId,
                    AffiliateStoreId = request.AffiliateStoreId
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
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CheckDuplicateNameAsync(
           CheckDuplicateNameRequest request,
           [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var command = new CheckDuplicateNameAffilliateQuery()
                {
                    Name = request.name,
                    AffiliateStoreId = request.AffiliateStoreId
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

        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateCategoryViewModel>>>, BadRequest<string>>> GetAffiliateCategorySelectListAsync(
           [AsParameters] GetAffiliateCategorySelectListQuery request,
           [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var result = await services.Mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCategoryViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateCategorySelectListAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCategoryViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<byte[]>>, BadRequest<string>>> ExportImportCategoryTemplate(
            [AsParameters] ExportCategoryImportTemplateQuery query,
            [AsParameters] AffiliateCategoryServices services)
        {
            try
            {
                var result = await services.Mediator.Send(query);
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.OK, "Export category import template successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ExportImportCategoryTemplate)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.BadRequest, "Export category import template failed", null));
            }
        }

        public static async Task<Results<Ok<GenericResponse<ImportAffiliateCategoryResponse>>, BadRequest<string>>> ImportAffiliateCategoryAsync(
           [FromForm] IFormFile file,
           string langKey,
           long affiliateStoreId,
           [AsParameters] AffiliateProductServices services)
        {
            try
            {
                var command = new ImportAffiliateCategoryCommand(file, affiliateStoreId, langKey);

                var result = await services.Mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(ImportAffiliateCategoryAsync)}");
                return TypedResults.Ok(new GenericResponse<ImportAffiliateCategoryResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ImportAffiliateCategoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<ImportAffiliateCategoryResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> CreateTokenAPIAsync(AffiliateTokenCategoryRequest tokenRequest, [AsParameters] AffiliateProductServices services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<GenericResponse<string>>, BadRequest<string>>> VerifyTokenAPIAsync(string token, [AsParameters] AffiliateProductServices services, IBaseApi baseApi)
        {
            try
            {
                var verifytoken = new VerifyTokenAPICommand()
                {
                    token = token
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

        public record CheckDuplicateRefIdRequest(
            string refId,
            long AffiliateStoreId
        );
        public record CheckDuplicateNameRequest(
            string name,
            long AffiliateStoreId
        );
    }
}
