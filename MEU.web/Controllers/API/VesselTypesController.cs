using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MEU.web.Data;
using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MEU.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VesselTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public VesselTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/VesselTypes
        [HttpGet]
        public IEnumerable<VesselType> GetVesselTypes()
        {
            return _context.VesselTypes.OrderBy(vt => vt.Type_Vessel);
        }

        
    }
}