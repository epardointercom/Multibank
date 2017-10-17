using Multibank.MobileEnterprise.RESTful.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Multibank.MobileEnterprise.RESTful.Services
{
    public class MockDataService : IDataService
    {
        public async Task<Tuple<string, UserHostService.User>> Authentication(string userName, string password)
        {
            string error = "";
            UserHostService.User result = null;

            if (userName == "autorizador")
            {
                if (password == "12345")
                    result = new UserHostService.User()
                    {
                        UserId = 1,
                        UserName = "autorizador",
                        Customer = new UserHostService.Customer()
                        {
                            CustomerId = 1,
                            FullName = "Pepito Mendieto"
                        },
                        CustomerId = 1
                    };
                else
                    error = "Contraseña incorrecta";
            }
            else
                error = "El usuario no existe";

            return new Tuple<String, UserHostService.User>(error, result);
        }

        public UserHostService.User GetUserById(int id)
        {
            UserHostService.User obj = null;

            if (id == 1)
            {
                obj = new UserHostService.User()
                {
                    UserId = 1,
                    UserName = "autorizador",
                    Customer = new UserHostService.Customer()
                    {
                        CustomerId = 1,
                        FullName = "Pepito Mendieto"
                    },
                    CustomerId = 1
                };
            }

            return obj;
        }

        public List<ContactModel> GetSiteInfo()
        {
            var result = new List<ContactModel>()
            {
                new ContactModel(){ Name = "En bogotá", Phone = "123 456 7890" },
                new ContactModel(){ Name = "A nuvel nacional", Phone = "123 456 7890" }
            };

            return result;
        }
    }
}