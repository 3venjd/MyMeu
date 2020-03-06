using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEU.Common.Models
{
    public class NewResponse
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateNew { get; set; }

        public DateTime DateNewLocal => DateNew.ToLocalTime();

        public ICollection<NewImageResponse> Newsimg { get; set; }

        public string FirtsImage => Newsimg == null || Newsimg.Count == 0 ?  
            "https://multiportappweb.azurewebsites.net/images/Gallery/c47bc248-e761-413c-9c5f-c98565e52521.jpg" 
            : 
            Newsimg.FirstOrDefault().ImageUrl;

    }
}
