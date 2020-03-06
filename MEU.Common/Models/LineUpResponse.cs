using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Common.Models
{
    public class LineUpResponse
    {
        public int Id { get; set; }

        public string Vessel { get; set; }
        
        public DateTime Eta { get; set; }

        public DateTime EtaLocal => Eta.ToLocalTime();

        public DateTime Etb { get; set; }

        public DateTime EtbLocal => Etb.ToLocalTime();

        public DateTime Etc { get; set; }

        public DateTime EtcLocal => Etc.ToLocalTime();

        public DateTime Etd { get; set; }

        public DateTime EtdLocal => Etd.ToLocalTime();

        public string Status { get; set; }

        public string Cargo { get; set; }

        public string Quantity { get; set; }

        public string Laycan { get; set; }

        public string Pol_Pod { get; set; }

        public string Shipper_Consignee { get; set; }

        public string Cargo_Charterer { get; set; }

        public string Agency { get; set; }


    }
}
