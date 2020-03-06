using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Common.Models
{
    public class AlertResponse
    {
        public int Id { get; set; }

        public string Alert_Description { get; set; }

        public DateTime Alert_Date { get; set; }

        public DateTime Alert_DateLocal => Alert_Date.ToLocalTime();

        public ICollection<AlertImageResponse> AlertImages { get; set; }
    }
}
