using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Models
{
    public class VoysViewModel : Voy
    {

        public int Company_id { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [Display(Name = "Employee")]
        [Range(1, int.MaxValue, ErrorMessage = "You must Select an Employee")]
        public int Employ_id { get; set; }

        public IEnumerable<SelectListItem> Employee_list { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [Display(Name = "Port")]
        [Range(1, int.MaxValue, ErrorMessage = "You must Select a Port")]
        public int Port_id { get; set; }

        public IEnumerable<SelectListItem> Port_list { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [Display(Name = "Vessel")]
        [Range(1, int.MaxValue, ErrorMessage = "You must Select a Vessel")]
        public int Vessel_id { get; set; }

        public IEnumerable<SelectListItem> Vessel_list { get; set; }
    }
}
