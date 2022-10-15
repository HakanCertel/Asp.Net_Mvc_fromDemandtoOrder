using System.ComponentModel.DataAnnotations;

namespace Senfoni.Satis.Webui.Models
{
    public class LoginModel
    {
        //[Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserName { get; set; }
        public string ReturnUrl { get; set; }
    }
}
