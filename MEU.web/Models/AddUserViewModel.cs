using System.ComponentModel.DataAnnotations;

namespace MEU.web.Models
{
    public class AddUserViewModel
    {

        [Display(Name = "Email")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characteres")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characteres")]
        public string Document { get; set; }

        [Display(Name = "Fisrt Name")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characteres")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characteres")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characteres")]
        public string PhoneNumber { get; set; }

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
