using System.ComponentModel.DataAnnotations;

namespace EShopApi.Models
{
    public class Login
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
    }
}
