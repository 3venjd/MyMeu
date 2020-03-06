using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class VesselType
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(20, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        public string Type_Vessel { get; set; }

        public ICollection<Vessel> Vessels { get; set; }
    }
}
