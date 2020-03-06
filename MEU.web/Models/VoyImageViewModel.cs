using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Models
{
    public class VoyImageViewModel : Voyimage
    {
        public int Voy_id { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
