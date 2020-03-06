using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Common.Models
{
    public class PortResponse
    {
        public int Id { get; set; }

        public string Port_Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<TerminalResponse> Terminals { get; set; }
    }
}
