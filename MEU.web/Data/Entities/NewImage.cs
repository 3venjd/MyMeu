using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class NewImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //TODO: Change Path
        [Display(Name = "Image")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://MEU.azurewebsites.net{ImageUrl.Substring(1)}";

        public New New { get; set; }


    }
}
