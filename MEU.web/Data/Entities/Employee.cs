using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Employee
    {

        public int Id { get; set; }

        public User User { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Skype { get; set; }

        public ICollection<Voy> Voys { get; set; }

        public Office Office { get; set; }
    }
}
