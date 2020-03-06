using System;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class LineUp
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(20, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        public string Vessel { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Eta { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtaLocal => Eta.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Etb { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtbLocal => Etb.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Etc { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtcLocal => Etc.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Etd { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtdLocal => Etd.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Laycan { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Pol_Pod { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Shipper_Consignee { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Cargo_Charterer { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Agency { get; set; }

        public Terminal Terminal { get; set; }


    }
}
