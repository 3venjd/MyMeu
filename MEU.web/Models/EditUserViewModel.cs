using System.ComponentModel.DataAnnotations;

namespace MEU.web.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

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
    }
}
