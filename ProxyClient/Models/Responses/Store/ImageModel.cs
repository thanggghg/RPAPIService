using System.ComponentModel.DataAnnotations;

namespace ProxyClient.Models.Responses.Store
{
    public class ImageModel
    {
        public const string IMAGE_ID = "imageId";
        public const string URL_PREFIX = "urlPrefix";
        public const string IMAGE_UUID = "imageUUID";
        public const string EXTENSION = "extension";

        public long ImageId { get; set; }

        [Required]
        public string ImageUUID { get; set; }

        [Required]
        public string UrlPrefix { get; set; }

        public string Extension { get; set; }

        public ImageModel(long imageId, string imageUUID, string urlPrefix, string extension)
        {
            ImageId = imageId;
            ImageUUID = imageUUID;
            UrlPrefix = urlPrefix;
            Extension = extension;
        }

        public ImageModel()
        {
        }
    }
}
