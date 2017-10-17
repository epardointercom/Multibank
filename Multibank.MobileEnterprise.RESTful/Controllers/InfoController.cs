using Multibank.MobileEnterprise.RESTful.Models;
using Multibank.MobileEnterprise.RESTful.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Multibank.MobileEnterprise.RESTful.Controllers
{
    [RoutePrefix("api/info")]
    public class InfoController : BaseController
    {
        [HttpGet]
        [Route("~/api/info/GetContactInfo")]
        public ResponseModel<List<ContactModel>> GetSiteInfo()
        {
            IDataService ds = new DataService();
            var response = new ResponseModel<List<ContactModel>>();

            try
            {
                response.Data = ds.GetSiteInfo();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
            }

            return response;
        }
    }
}
