using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Advertisers()
        {
            return View();
        }

        public ActionResult Streamers()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            Models.ContactsVModel model = new Models.ContactsVModel();

            return View(model);
        }

        [HttpPost()]
        public ActionResult Contacts(Models.ContactsVModel model)
        {
            if(ModelState.IsValid && model.Name != "ruslan")
            {
                return RedirectToAction("Index");
            }

            model.ErrorMsg = true;
            model.ErrorText = "Invalid values";

            return View(model);
        }

        public ActionResult Login()
        {
            Models.UserVModel user = Session["User"] as Models.UserVModel;
            if(user != null)
            {
                return RedirectToAction("Index");
            }
            user = new Models.UserVModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(Models.UserVModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new Models.UserVModel() {
                    UserName = string.IsNullOrEmpty(model.Email) ? "unknow user" : model.Email.Split(new char[] { '@' })[0],
                    Email = model.Email,
                    Cash = "0.00" };
                Session["User"] = user;
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult MiniLogin()
        {
            Models.UserVModel user = Session["User"] as Models.UserVModel;
            return PartialView(user);
        }

        public ActionResult Menu()
        {
            Models.NavigationVModel model = new Models.NavigationVModel();
            model.SubMenu = new List<Models.NavigationVModel>();
            model.SubMenu.Add(new Models.NavigationVModel() { Name = "Advertisers", Url = "/home/advertisers" });
            model.SubMenu.Add(new Models.NavigationVModel() { Name = "Streamers", Url = "/home/streamers" });
            model.SubMenu.Add(new Models.NavigationVModel() { Name = "FAQ", Url = "/home/faq" });
            model.SubMenu.Add(new Models.NavigationVModel() { Name = "Menu with submenus", Url = "#", SubMenu = new List<Models.NavigationVModel>() });
            model.SubMenu.Add(new Models.NavigationVModel() { Name = "Contact", Url = "/home/contacts" });

            model.SubMenu[3].SubMenu.Add(new Models.NavigationVModel() { Name = "Submenu 1", Url = "/home/submenu-1" });
            model.SubMenu[3].SubMenu.Add(new Models.NavigationVModel() { Name = "Submenu 2", Url = "/home/submenu-2" });
            model.SubMenu[3].SubMenu.Add(new Models.NavigationVModel() { Name = "Submenu 3", Url = "/home/submenu-3" });
            return PartialView(model);
        }
    }
}
