using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Office
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Postal_Code { get; set; }


        [Required(ErrorMessage = "the field {0} is required")]
        public string Phone { get; set; }

        public string Usa_Phone { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Email { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
