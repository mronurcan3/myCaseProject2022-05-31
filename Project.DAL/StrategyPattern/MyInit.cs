using Project.DAL.Context;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit: DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            UserProfile userProfileSysAdmin = new UserProfile()
            {
                FirstName = "onurcan",
                LastName = "yildirim",

            };

            AppUser appUserSysAdmin = new AppUser()
            {
                UserName = "sAdmin",
                Password = "123",
                UserProfile = userProfileSysAdmin,
                Role = Entities.Enums.UserRole.SysAdmin
            };

            context.AppUsers.Add(appUserSysAdmin);
            context.UserProfiles.Add(userProfileSysAdmin);

            Product product = new Product()
            {
                Name = $"product admin",
                Description = $"Description admin",
                Price = 30
            };

            List<Product> products = new List<Product>();
            products.Add(product);

            UserProfile userProfileAdmin = new UserProfile()
            {
                FirstName = "mehmet",
                LastName = "yildirim",

            };

            AppUser appUserAdmin = new AppUser()
            {
                UserName = "admin",
                Password = "123",
                UserProfile = userProfileAdmin,
                Role = Entities.Enums.UserRole.Admin,
                Products = products
                
                
            };

            context.Products.Add(product);

            context.AppUsers.Add(appUserAdmin);
            context.UserProfiles.Add(userProfileAdmin);

            UserProfile userProfileCustomer = new UserProfile()
            {
                FirstName = "alisya",
                LastName = "yildirim",

            };

            AppUser appUserCustomer = new AppUser()
            {
                UserName = "customer",
                Password = "123",
                UserProfile = userProfileCustomer,
                Role = Entities.Enums.UserRole.Customer
            };

            context.AppUsers.Add(appUserCustomer);
            context.UserProfiles.Add(userProfileCustomer);

            for (int i = 1; i < 20; i++)
            {
                Product product1 = new Product()
                {
                    Name = $"product{i}",
                    Description = $"Description{i}",
                    Price = Convert.ToDecimal(i)
                };

                context.Products.Add(product1);

                context.SaveChanges();

            }

            context.SaveChanges();



        }

    }
}
