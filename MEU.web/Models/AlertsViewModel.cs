using MEU.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Models
{
    public class AlertsViewModel : Alert
    {
        public int Status_id { get; set; }
    }
}
