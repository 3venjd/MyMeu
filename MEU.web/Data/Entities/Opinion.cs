using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Data.Entities
{
    public class Opinion
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "You must Select a Vessel Type")]
        public int Qualification { get; set; }

        public string Description { get; set; }

        public Voy Voy { get; set; }

    }
}
