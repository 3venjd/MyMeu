using System.Collections.Generic;
using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MEU.web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboVesselType();

        IEnumerable<SelectListItem> GetComboEmployees();

        IEnumerable<SelectListItem> GetComboPorts();

        IEnumerable<SelectListItem> GetComboVessels();

    }
}