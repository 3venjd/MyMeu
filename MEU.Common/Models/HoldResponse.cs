using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Common.Models
{
    public class HoldResponse
    {
        public int Id { get; set; }

        public int Hold_Number { get; set; }

        public double Actual_Quantity { get; set; }

        public double Max_Quantity { get; set; }

        public bool Is_Full { get; set; }

        public bool Is_Empty { get; set; }

        public DateTime First_Charge { get; set; }

        public DateTime First_ChargeLocal => First_Charge.ToLocalTime();

        public DateTime Last_Charge { get; set; }

        public DateTime Last_ChargeLocal => Last_Charge.ToLocalTime();

    }
}
