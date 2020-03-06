using MEU.web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Models
{
    public class AddEmployeeViewModel : EditEmployeeViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characteres")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "the {0} field must be contain betwenn {2} and {1} characteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "the {0} field must be contain betwenn {2} and {1} characteres")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
