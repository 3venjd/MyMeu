using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Models
{
    public class VesselViewModel : Vessel
    {
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [Display(Name = "Vessel Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must Select a Vessel Type")]
        public int VesselTypeId { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        public IEnumerable<SelectListItem> VesselTypes { get; set; }
    }
}
