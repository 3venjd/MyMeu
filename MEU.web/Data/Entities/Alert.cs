using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Alert
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Alert_Description { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Alert_Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Alert_DateLocal => Alert_Date.ToLocalTime();

        public Status Status { get; set; }

        public ICollection<AlertImage> AlertImages { get; set; }

    }
}
