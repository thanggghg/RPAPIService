using System.Data;
using System.Net;
using AutoMapper;
using DocumentFormat.OpenXml;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateCategory;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler;
using GoSell.Affiliate.Tracking.Queries.AffiliateCategory;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Excel;
using GoSell.Library.Helpers.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Functions.Implementation
{
    public class AffiliateCategoryFunctions : IAffiliateCategoryFunctions
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository;
        private readonly IBaseApi _baseApi;
        private readonly IBaseService _baseService;
        private const int IMPORT_CATEGORY_ROW_HEADER_INDEX = 1;
        private const int IMPORT_CATEGORY_START_ROW_INDEX = 3;
        private const int IMPORT_CATEGORY_MAX_INDEX_COL = 2;
        private const int IMPORT_CATEGOR_INDEX_COL_ERR = 3;
        private const int IMPORT_CATEGOR_INDEX_ROW_ERROR = 3;
        private const string IMPORT_CATEGOR_COL_NAME_ERROR = "Error";
        private const string IMPORT_CATEGOR_RED_COLOR_HEX = "FF0000";
        private const int CATEGORY_COL_REF_CATEGORY_ID = 0;
        private const int CATEGORY_COL_CATEGORY_NAME = 1;
        private const int IMPORT_REF_CATEGORY_ID_MAX_LENGTH = 100;
        private const int IMPORT_CATEGORY_NAME_MAX_LENGTH = 200;
        private readonly IWebHostEnvironment _environment;
        private const string LANG_VI = "vi";
        private readonly ILogger<AffiliateCategoryFunctions> _logger;
        public AffiliateCategoryFunctions(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                                  IBaseApi baseApi,
                                                  IBaseService baseService,
                                                  IWebHostEnvironment environment,
                                                  ILogger<AffiliateCategoryFunctions> logger)
        {
            _AffiliateCategoryRepository = AffiliateCategoryRepository;
            _baseApi = baseApi;
            _baseService = baseService;
            _environment = environment;
            _logger = logger;
        }

        public async Task<BaseResponse> ChangeStatusAffiliateCategory(ChangeStatusAffiliateCategoryCommand request)
        {
            var categoryChangeStatus = await _AffiliateCategoryRepository.GetByIdAsync(request.Id);
            if (categoryChangeStatus == null || _baseService.isInvalidAffiliateStore(categoryChangeStatus.AffiliateStoreId, _baseApi.User.StoreId))
            {
                throw new Exception("Category not exist");
            }
            categoryChangeStatus.Status = request.Status;
            categoryChangeStatus.LastModifiedBy = _baseApi.User.Sub;

            await _AffiliateCategoryRepository.Update(categoryChangeStatus);

            return new BaseResponse(HttpStatusCode.OK, "Change Status Affiliate Category successfully");
        }

        public async Task<BaseResponse> CheckDuplicateNameAffilliate(CheckDuplicateNameAffilliateQuery request)
        {
            try
            {
                var result = await _AffiliateCategoryRepository.GetByNameAsync(request.AffiliateStoreId, request.Name);
                Log.Logger.Information($"DONE {nameof(CheckDuplicateNameAffilliateQueryHandle)}");
                return new GenericResponse<bool>(HttpStatusCode.OK, "Check Duplicate Name Category", result != null);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CheckDuplicateNameAffilliateQueryHandle)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseResponse> CheckDuplicateRefIdAffilliate(CheckDuplicateRefIdAffilliateQuery request)
        {
            try
            {
                var result = await _AffiliateCategoryRepository.GetByRefIdAsync(request.RefId, request.AffiliateStoreId);
                Log.Logger.Information($"DONE {nameof(CheckDuplicateRefIdAffilliateQueryHandle)}");
                return new GenericResponse<bool>(HttpStatusCode.OK, "Check Duplicate RefId Category", result != null);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CheckDuplicateRefIdAffilliateQueryHandle)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
		
		public async Task<byte[]> ExportCategoryImportTemplate(ExportCategoryImportTemplateQuery request)
        {
            try
            {
                string fullPath = Path.Combine(_environment.ContentRootPath, "Templates", request.LangKey.ToLower(), "affiliate-category-template-import_template_EN.xlsx");
                if (request.LangKey.ToUpper() == LANG_VI.ToUpper())
                {
                    fullPath = Path.Combine(_environment.ContentRootPath, "Templates", request.LangKey.ToLower(), "affiliate-category-template-import_template_VI.xlsx");
                }

                _logger.LogInformation($"{nameof(ExportCategoryImportTemplateQuery)}: Get  templateFileName file success: {fullPath} ");
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
                _logger.LogError(ex, $"FAIL {nameof(ExportCategoryImportTemplateQuery)} : {ex.Message}");
                throw new Exception($"Export import category template failed. {ex.Message}");
            }
        }

        public async Task<ImportAffiliateCategoryResponse> ImportAffiliateCategory(ImportAffiliateCategoryCommand request)
        {
            try
            {
                if (_baseService.isInvalidAffiliateStore(request.AffiliateStoreId, _baseApi.User.StoreId))
                {
                    throw new Exception("Affiliate store id not found!");
                }

                // init params
                var affCategoryResult = new ImportAffiliateCategoryResponse();

                var dt = await ExcelHelper.ReadDataFromExcelToDataTable(request.File, IMPORT_CATEGORY_START_ROW_INDEX, IMPORT_CATEGORY_MAX_INDEX_COL, IMPORT_CATEGORY_ROW_HEADER_INDEX);
                var builtAffiliateCategoryList = BuildAffiliateCategoryList(dt, request.AffiliateStoreId, request.LangKey);
                affCategoryResult.TotalCount = dt.Rows.Count;
                affCategoryResult.SuccessCount = builtAffiliateCategoryList.SucceededCategory.Count;
                affCategoryResult.ErrorCount = builtAffiliateCategoryList.IndexRowsFailed.Count;
                affCategoryResult.HasError = affCategoryResult.ErrorCount > 0;
                affCategoryResult.ErrorData = affCategoryResult.ErrorData;

                //Import to Database in here
                if (affCategoryResult.SuccessCount > 0)
                {
                    var importedAffiliateCategorys = builtAffiliateCategoryList.SucceededCategory;
                    await _AffiliateCategoryRepository.InsertOrUpdateByBulkAsync(importedAffiliateCategorys, request.AffiliateStoreId);
                }

                //ExportErrorDataToExcel
                if (affCategoryResult.HasError)
                {
                    affCategoryResult.ErrorData = await ExcelHelper.ExportErrorDataToExcel(builtAffiliateCategoryList.IndexRowsSucceeded, 
                        builtAffiliateCategoryList.ErrorData, request.File, IMPORT_CATEGOR_COL_NAME_ERROR, 
                        IMPORT_CATEGOR_INDEX_COL_ERR, IMPORT_CATEGOR_INDEX_ROW_ERROR, IMPORT_CATEGOR_RED_COLOR_HEX);
                }

                Log.Logger.Information($"DONE {nameof(ImportAffiliateCategory)}");

                return affCategoryResult;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ImportAffiliateCategory)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private BuiltAffiliateCategoryResult BuildAffiliateCategoryList(DataTable dt, long affiliateStoreId, string langKey = "en")
        {
            try
            {
                var builtAffCategory = new BuiltAffiliateCategoryResult();
                int startRow = IMPORT_CATEGORY_START_ROW_INDEX;
                var dataImport = new List<AffiliateCategoryImport>();

                foreach (DataRow row in dt.Rows)
                {
                    if (!row.ItemArray.Any(x => x != DBNull.Value))
                    {
                        //check value of all column items is empty
                        continue;
                    }

                    var affiliateCategory = new AffiliateCategory
                    {
                        AffiliateStoreId = affiliateStoreId,
                        CreatedBy = _baseApi.User.Sub,
                        LastModifiedBy = _baseApi.User.Sub,
                        IsDeleted = false,
                        Status = true
                    };

                    var listErrors = new List<string>();

                    for (int i = 0; i < IMPORT_CATEGORY_MAX_INDEX_COL; i++)
                    {
                        string errMessage = BuildErrorMessage(row, i, langKey);

                        if (string.IsNullOrEmpty(errMessage))
                        {
                            var dataCell = row[i].ToString();
                            BuildAffiliateCategoryFromDataRow(dataCell, i, ref affiliateCategory);
                        }
                        else
                        {
                            listErrors.Add(errMessage);
                        }
                    }

                    dataImport.Add(new AffiliateCategoryImport
                    {
                        AffiliateCategory = affiliateCategory,
                        RowIndex = dt.Rows.IndexOf(row) + startRow,
                        ListErrors = listErrors
                    });
                }

                if (dataImport.Count > 0)
                {
                    foreach(var item in dataImport)
                    {
                        if (item.ListErrors.Count == 0)
                        {
                            builtAffCategory.SucceededCategory.Add(item.AffiliateCategory);
                            builtAffCategory.IndexRowsSucceeded.Add(item.RowIndex);
                        }
                        else
                        {
                            builtAffCategory.ErrorData.Add(item.RowIndex, string.Join(",\n", item.ListErrors));
                            builtAffCategory.IndexRowsFailed.Add(item.RowIndex);
                        }
                    }
                }

                return builtAffCategory;
            }
            catch (Exception ex)
            {
                Log.Error($"BuildCategoryList Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private string BuildErrorMessage(DataRow row, int colIndex, string langKey = "en")
        {
            var dataCell = row[colIndex].ToString();
            if (ExcelHelper.IsCellNullOrEmpty(dataCell))
            {
                switch (colIndex)
                {
                    case CATEGORY_COL_REF_CATEGORY_ID:
                        return langKey == LANG_VI ? "<Mã danh mục liên kết>  là giá trị bắt buộc. Vui lòng không để trống" : "<Ref category id> is required. Please do not leave it blank";
                    case CATEGORY_COL_CATEGORY_NAME:
                        return langKey == LANG_VI ? "<Tên danh mục> là giá trị bắt buộc, không được để trống" : "<Category name> is required value. Do not leave it blank";
                }
            }

            switch (colIndex)
            {
                case CATEGORY_COL_REF_CATEGORY_ID:
                    if (dataCell.Contains(" "))
                        return langKey == LANG_VI ? $"<Mã danh mục liên kết> không có khoảng trống ở giữa" : $"<Ref category id> has no space in between characters";
                    else if (dataCell.Length > IMPORT_REF_CATEGORY_ID_MAX_LENGTH)
                        return langKey == LANG_VI ? $"<Mã danh mục liên kết> có chiều dài tối đa là {IMPORT_REF_CATEGORY_ID_MAX_LENGTH} ký tự" : $"<Ref category id>'s max length is {IMPORT_REF_CATEGORY_ID_MAX_LENGTH} characters";
                    break;
                case CATEGORY_COL_CATEGORY_NAME:
                    if (dataCell.Length > IMPORT_CATEGORY_NAME_MAX_LENGTH)
                        return langKey == LANG_VI ? $"<Tên danh mục> có chiều dài tối đa là {IMPORT_CATEGORY_NAME_MAX_LENGTH} ký tự" : $"<Category name>'s max length is {IMPORT_CATEGORY_NAME_MAX_LENGTH} characters";
                    break;
            }
            return "";
        }

        private void BuildAffiliateCategoryFromDataRow(string dataCell, int colIndex, ref AffiliateCategory affiliateCategory)
        {
            if (colIndex == CATEGORY_COL_REF_CATEGORY_ID)
            {
                if (dataCell.Length > IMPORT_REF_CATEGORY_ID_MAX_LENGTH)
                {
                    affiliateCategory.RefCategoryId = dataCell.Substring(0, IMPORT_REF_CATEGORY_ID_MAX_LENGTH);
                }
                else
                {
                    affiliateCategory.RefCategoryId = dataCell;
                }
            }

            if (colIndex == CATEGORY_COL_CATEGORY_NAME)
            {
                if (dataCell.Length > IMPORT_CATEGORY_NAME_MAX_LENGTH)
                {
                    affiliateCategory.Name = dataCell.Substring(0, IMPORT_CATEGORY_NAME_MAX_LENGTH);
                }
                else
                {
                    affiliateCategory.Name = dataCell;
                }
            }
        }
    }

    public class AffiliateCategoryImport
    {
        public int RowIndex { get; set; }
        public List<string> ListErrors { get; set; }
        public AffiliateCategory AffiliateCategory { get; set; }
    }
}
