using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Common.Models
{
    public class StatusResponse
    {
        public int Id { get; set; }

        public string Name_status { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime ArrivalLocal => Arrival.ToLocalTime();

        public DateTime Anchored { get; set; }

        public DateTime AnchoredLocal => Anchored.ToLocalTime();

        public DateTime Pob { get; set; }

        public DateTime PobLocal => Pob.ToLocalTime();

        public DateTime AllFast { get; set; }

        public DateTime AllFastLocal => AllFast.ToLocalTime();

        public DateTime Commenced { get; set; }

        public DateTime CommencedLocal => Commenced.ToLocalTime();

        public DateTime DateUpdate { get; set; }

        public DateTime DateUpdateLocal => DateUpdate.ToLocalTime();

        public ICollection<HoldResponse> Holds { get; set; }

        public ICollection<AlertResponse> Alerts { get; set; }

    }
}
