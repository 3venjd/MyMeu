using System;
using System.ComponentModel.DataAnnotations;

namespace MEU.web.Data.Entities
{
    public class Hold
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public int Hold_Number { get; set; }

        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "the field {0} is required")]
        public double Actual_Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "the field {0} is required")]
        public double Max_Quantity { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public bool Is_Full { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public bool Is_Empty { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime First_Charge { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime First_ChargeLocal => First_Charge.ToLocalTime();

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Last_Charge { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Last_ChargeLocal => Last_Charge.ToLocalTime();

        public Status Status { get; set; }

    }
}
