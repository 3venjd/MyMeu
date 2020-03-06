using MEU.web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MEU.web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboVesselType()
        {
            var list = _dataContext.VesselTypes.Select(c => new SelectListItem
            {
                Text = c.Type_Vessel,
                Value = $"{c.Id}"
            }
            ).OrderBy(c => c.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Vessel Type)",
                Value = "0"

            }
            );
            return list;
        }

        public IEnumerable<SelectListItem> GetComboEmployees()
        {
            var list = _dataContext.Employees.Select(e => new SelectListItem
            {
                Text = e.User.FullName,
                Value = $"{e.Id}"
            }
            ).OrderBy(c => c.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Select an employee)",
                Value = "0"

            }
            );
            return list;
        }

        public IEnumerable<SelectListItem> GetComboPorts()
        {
            var list = _dataContext.Ports.Select(p => new SelectListItem
            {
                Text = p.Port_Name,
                Value = $"{p.Id}"
            }
            ).OrderBy(c => c.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Select a port)",
                Value = "0"

            }
            );
            return list;
        }

        public IEnumerable<SelectListItem> GetComboVessels()
        {
            var list = _dataContext.Vessels.Select(v => new SelectListItem
            {
                Text = v.Vessel_Name,
                Value = $"{v.Id}"
            }
            ).OrderBy(c => c.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Vessel)",
                Value = "0"

            }
            );
            return list;
        }
    }
}
