using System.ComponentModel.DataAnnotations;

namespace ProxyClient.Models.Requests.Getaways
{
    public class CreateUserRequestModel
    {
        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string Domain { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string LangKey { get; set; }

        [Required]
        public string LocationCode { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
