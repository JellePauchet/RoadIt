using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        roaditEntities entities;
        public ActionResult Index()
        {
            entities = new roaditEntities();
            ViewBag.Error = Session["error"];

            //Session["password"] = ("test").GetHashCode().ToString();

            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            entities = new roaditEntities();
            var MailList = new List<string>();
            var PasswordList = new List<string>();
            var NameList = new List<string>();
            var RoleIDList = new List<int>();

            foreach (var item in entities.Users)
            {
                MailList.Add(item.Email.ToString());
                PasswordList.Add(item.Password.ToString());
                NameList.Add(item.Name.ToString());
                RoleIDList.Add(item.RoleId);
            }

            for (var i = 0; i < MailList.Count; i++ )
            {
                if (MailList[i] == email.ToString())
                {
                    if (PasswordList[i].ToString() == password.GetHashCode().ToString())
                    {
                        
                        Session["email"] = email;
                        Session["password"] = password;
                        Session["Username"] = NameList[i].ToString() + " - LogOut";
                        Session["RoleId"] = RoleIDList[i];
                        return RedirectToAction("Index", "RoadSelection");
                    }
                    /*else
                    {
                        Session["error"] = "The given email or password is wrong";
                        return RedirectToAction("Index", "Login");
                    }*/
                }
            }
            Session["error"] = "The given email or password is wrong";
            return RedirectToAction("Index");
        }

        public ActionResult Logout() 
        {
            Session.Clear();
            Session["Username"] = "Login";
            return RedirectToAction("Index");
        }
    }
}
