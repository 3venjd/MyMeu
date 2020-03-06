using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Voy
    {

        public int Id { get; set; }

        
        [Required(ErrorMessage = "the field {0} is required")]
        public int Voy_number { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Account { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Laycan { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Contract { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Cargo { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Sf { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Pol { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Facility { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Pod { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Cargo_Charterer { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Owner_Charterer { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Shipper { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Altitude { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastKnowPosition { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastKnowPositionLocal => LastKnowPosition.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Eta { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = false)]
        public DateTime EtaLocal => Eta.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = true)]
        public DateTime Etb { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtbLocal => Etb.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}",  ApplyFormatInEditMode = true)]
        public DateTime Etc { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtcLocal => Etc.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Etd { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtdLocal => Etd.ToLocalTime();

        public Company Company { get; set; }

        public Employee Employee { get; set; }

        public Port Port { get; set; }

        public Vessel Vessel { get; set; }

        public ICollection<Status> Statuses { get; set; }

        public ICollection<Voyimage> Voyimages { get; set; }

        public ICollection<Opinion> Opinions { get; set; }
    }
}
