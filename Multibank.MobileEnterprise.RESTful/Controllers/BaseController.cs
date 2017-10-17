using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Multibank.MobileEnterprise.RESTful.Controllers
{
    public class BaseController : ApiController
    {
        public T SendResponse<T>(T response, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (statusCode != HttpStatusCode.OK)
            {
                var badResponse = new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };
            }

            return response;
        }
    }
}
