using System.Threading.Tasks;
using Multibank.Autorizador.Models;

namespace Multibank.Autorizador.Services
{
    public interface IDataService
    {
        Task<BaseResponse<bool>> Authentication(string userName, string pasword);

        Task<BaseResponse<Contact>> ContactInfo();
    }
}
