using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Models
{
    public class NewsViewModel : New
    {

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
