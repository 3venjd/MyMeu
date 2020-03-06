using MEU.web.Data;
using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]

    public class NewsController
    {
        private readonly DataContext _dataContext;

        public NewsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("GetNews")]
        public IEnumerable<New> GetNews()
        {
            return _dataContext.News.OrderBy(vt => vt.DatePublicationLocal);
        }
    }
}
