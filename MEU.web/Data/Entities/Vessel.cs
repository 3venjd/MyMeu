﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Vessel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(30, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        public string Vessel_Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //TODO: Change Path
        [Display(Name = "Image")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://MEU.azurewebsites.net{ImageUrl.Substring(1)}";

        public ICollection<Voy> Voys { get; set; }

        public VesselType VesselType { get; set; }
    }
}
