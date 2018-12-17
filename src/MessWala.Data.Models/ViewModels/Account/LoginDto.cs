using System.ComponentModel.DataAnnotations;

namespace MessWala.Data.Models.ViewModels.AccountViewModel {
    public class LoginDto {
        [Required]
        [Display (Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Display (Name = "Password")]
        public string Password { get; set; }
    }
}