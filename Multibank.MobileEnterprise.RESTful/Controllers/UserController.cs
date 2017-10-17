using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Http;
using Multibank.MobileEnterprise.RESTful.Models;
using Multibank.MobileEnterprise.RESTful.Services;

namespace Multibank.MobileEnterprise.RESTful.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : BaseController
    {
        [HttpGet]
        [Authorize]
        [Route("~/api/user/GetCurrentAuthenticated")]
        public ResponseModel<UserHostService.User> GetCurrentAuthenticated()
        {
            IDataService ds = new MockDataService();

            var response = new ResponseModel<UserHostService.User>();
            var data = new UserHostService.User();
            var statusCode = new HttpStatusCode();
            var identity = (ClaimsIdentity)User.Identity;

            try
            {
                data = ds.GetUserById(Convert.ToInt32(identity.Claims.Where(x => x.Type == "IdUser").FirstOrDefault().Value));
                response.Success = true;
                statusCode = data == null ? HttpStatusCode.NoContent : HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                statusCode = HttpStatusCode.InternalServerError;
            }

            response.Data = data;

            return SendResponse(response, statusCode);
        }

        //[HttpGet]
        //[Authorize(Roles = "admin")]
        //[Route("~/api/values/authorize")]
        //public IHttpActionResult GetForAdmin()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var roles = identity.Claims
        //                .Where(c => c.Type == ClaimTypes.Role)
        //                .Select(c => c.Value);
        //    return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        //}
    }
}
