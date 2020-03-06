using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Common.Models
{
    public class EmployeeResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cargo { get; set; }

        public string Skype { get; set; }

        public string Phone_number { get; set; }

        public string Email { get; set; }

        public OfficeResponse Office { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }
}
