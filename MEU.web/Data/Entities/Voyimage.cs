using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Data.Entities
{
    public class Voyimage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Title { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //TODO: Change Path
        [Display(Name = "Image")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://MEU.azurewebsites.net{ImageUrl.Substring(1)}";

        public Voy Voy { get; set; }

    }
}
