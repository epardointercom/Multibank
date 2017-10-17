using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Multibank.MobileEnterprise.RESTful.UserHostService;
using Multibank.MobileEnterprise.RESTful.Models;

namespace Multibank.MobileEnterprise.RESTful.Services
{
    public class DataService : IDataService
    {
        public Task<Tuple<string, User>> Authentication(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactModel> GetSiteInfo()
        {
            var sc = new SiteHostService.SiteServiceClient();

            string bogota = sc.GetSiteSettingValue("ContactBogota");
            string national = sc.GetSiteSettingValue("ContactRestConuntry");

            var result = new List<ContactModel>()
            {
                new ContactModel(){ Name = "En bogotá", Phone = bogota },
                new ContactModel(){ Name = "A nuvel nacional", Phone = national }
            };

            return result;
        }
    }
}