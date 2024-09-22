using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSell.Library.Helpers;
using GoSell.Library.Utils;
using ProxyClient.Constants.Uri;
using ProxyClient.Helpers;
using ProxyClient.Models.Responses.Media;
using ProxyClient.Models.Responses.Store;

namespace ProxyClient.Services
{
    public interface IMediaService
    {
        Task<List<ImageFileModel>> GetAllImageFiles(string baseUrl);
        
    }
    /// <summary>
    /// 
    /// </summary>
    public class MediaService : IMediaService
    {
        private readonly IHttpClientHelper _httpClientHelper;

        public MediaService(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public async Task<List<ImageFileModel>> GetAllImageFiles(string baseUrl)
        {
            return await _httpClientHelper.SendServiceApiGetAsync<List<ImageFileModel>>(baseUrl, string.Format(MediaEndpointConstants.GET_ALL_IMAGE_FILE), ApiNameConstants.SUPPORT_SERVICE);
        }
    }
}
