using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Terminal
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Terminal_Name { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Max_Loa { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Max_Beam { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Max_Draft { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Displacement { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Water_Density { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Working_hours { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Type_Cargo { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //TODO: Change Path
        [Display(Name = "Image")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://MEU.azurewebsites.net{ImageUrl.Substring(1)}";

        public Port Port { get; set; }

        public ICollection<LineUp> LineUps { get; set; }

    }
}
