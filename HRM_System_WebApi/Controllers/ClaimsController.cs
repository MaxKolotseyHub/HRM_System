
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace HRM_System_WebApi.Controllers
{
    public class ClaimsController : ApiController
    {
        [Route("api/claims"), HttpGet]
        [Authorize]
        public IHttpActionResult Index()
        {
            var identity = User.Identity as ClaimsIdentity;
            var claims = from c in identity.Claims
                         select new
                         {
                             subject = c.Subject.Name,
                             type = c.Type,
                             value = c.Value
                         };

            return Ok(claims);
        }
    }
}
