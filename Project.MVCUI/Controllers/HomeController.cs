using Project.BLL.DesignPatterns.GenericRepository.ConRep;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MVCUI.AuthenticationClasses;
using Project.MVCUI.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        AppUserRepository _appUser;
        ProductRepository _product;
        UserProfileRepository _profile;
        public HomeController()
        {
            _appUser = new AppUserRepository();
            _product = new ProductRepository();
            _profile = new UserProfileRepository();
            
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(string userName,string password)
        {
            if(_appUser.Any(x => x.UserName == userName && x.Password == password))
            {
                AppUser appUser = _appUser.FirstOrDefault(x => x.UserName == userName && x.Password == password);

                Session["user"] = appUser.ID;

                return RedirectToAction("MainPage");

            }

            ViewBag.fail = "There is no matching user";

            return View();
        }
        [UserAuthentication]
        public ActionResult MainPage()
        {
            AppUser appUser = _appUser.Find(Convert.ToInt32(Session["user"]));

            AppUserVM AVM = new AppUserVM()
            {
                Products = _product.GetActives(),
                AppUser = appUser,
            };

            

            return View(AVM);
        }
        [HttpPost]
        public ActionResult MainPage(string name,string description,decimal price,int id)
        {
            Product product = _product.Find(id);
            product.Name = name;
            product.Description = description;
            product.Price = price;

            _product.Update(product);

            AppUser appUser = _appUser.Find(Convert.ToInt32(Session["user"]));

            AppUserVM AVM = new AppUserVM()
            {
                Products = _product.GetActives(),
                AppUser = appUser,
            };
            return View(AVM);

        }

        public ActionResult SingUp()
        {

            return View();
        }

        [HttpPost]

        public ActionResult SingUp(string userName,string password,string firstName,string lastName,UserRole role)
        {
            if(_appUser.Any(x => x.UserName != userName)){

                UserProfile userProfile = new UserProfile()
                {
                    FirstName = firstName,
                    LastName = lastName,
                };

                AppUser appUser = new AppUser()
                {
                    UserName = userName,
                    Password = password,
                    UserProfile = userProfile,
                    Role = role
                };

                _appUser.Add(appUser);
                _profile.Add(userProfile);

                ViewBag.result = "user successfully added";

            }

            ViewBag.result = "Unable to add user, please choose another username";
            return View();
        }



    }
}