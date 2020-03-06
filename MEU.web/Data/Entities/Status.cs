using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Status
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        [Display(Name = "Status")]
        public string Name_status { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalLocal => Arrival.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Anchored { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime AnchoredLocal => Anchored.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Pob { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PobLocal => Pob.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime AllFast { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime AllFastLocal => AllFast.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Commenced { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CommencedLocal => Commenced.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateUpdate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateUpdateLocal => DateUpdate.ToLocalTime();

        public Voy Voy { get; set; }

        public ICollection<Hold> Holds { get; set; }

        public ICollection<Alert> Alerts { get; set; }

    }
}
