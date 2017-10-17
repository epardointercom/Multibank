using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Multibank.MobileEnterprise.RESTful.Models;

namespace Multibank.MobileEnterprise.RESTful.Services
{
    public interface IDataService
    {
        Task<Tuple<string, UserHostService.User>> Authentication(string userName, string password);

        UserHostService.User GetUserById(int id);

        List<ContactModel> GetSiteInfo();
    }
}
