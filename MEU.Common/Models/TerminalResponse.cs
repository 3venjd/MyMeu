using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Common.Models
{
    public class TerminalResponse
    {
        public int Id { get; set; }

        public string Terminal_Name { get; set; }

        public string Max_Loa { get; set; }

        public string Max_Beam { get; set; }

        public string Max_Draft { get; set; }

        public string Displacement { get; set; }

        public string Water_Density { get; set; }

        public string Working_hours { get; set; }

        public string Type_Cargo { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<LineUpResponse> LineUps { get; set; }

    }
}
