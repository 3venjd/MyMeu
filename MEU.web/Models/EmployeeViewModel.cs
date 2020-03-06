using MEU.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Models
{
    public class EmployeeViewModel : Employee
    {
        public int Office_id { get; set; }
    }
}
