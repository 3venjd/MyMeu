using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Company
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public bool Pro { get; set; }

        public ICollection<Client> Clients { get; set; }

        public ICollection<Voy> Voys { get; set; }

    }
}
