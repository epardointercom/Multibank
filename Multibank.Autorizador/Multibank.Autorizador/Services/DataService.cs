using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Multibank.Autorizador.Models;

[assembly: Dependency(typeof(Multibank.Autorizador.Services.DataService))]
namespace Multibank.Autorizador.Services
{
    public class DataService : IDataService
    {
        public async Task<BaseResponse<bool>> Authentication(string userName, string pasword)
        {
            var result = new BaseResponse<bool>() { Data = false };
            var rest = new RESTful<User>();

            var sessionResult = await rest.TokenRegistrationAsync("token", userName, pasword);

            if (sessionResult.Success)
            {
                result.Success = true;
                var token = (sessionResult.Data);

                if (!string.IsNullOrEmpty(token.access_token))
                {
                    Settings.CurrentSession = token;

                    // Get current user data
                    var userResult = await rest.HttpClientResponseAsync("api/user/GetCurrentAuthenticated", HttpMethod.Get, null);

                    if (userResult.Success)
                    {
                        userResult.Data.CompleteName = $"{userResult.Data.FirstName} {userResult.Data.LastName}";
                        Settings.CurrentUser = userResult.Data;
                        result.Data = true;
                    }
                    else
                    {
                        result.Error = userResult.Error;
                    }
                }
                else if (!string.IsNullOrEmpty(token.error))
                {
                    result.Error = token.error_description;
                }
            }
            else
            {
                result.Success = false;
                result.Error = sessionResult.Error;
            }

            return result;
        }

        public async Task<BaseResponse<Contact>> ContactInfo()
        {
            return new BaseResponse<Contact>()
            {
                Data = new Contact() { LocalNumber = "742 4222", NationalNumber = "01 8000 915 690" },
                Success = true
            };
        }
    }
}

