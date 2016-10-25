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

        RoadItEntities entities;
        public ActionResult Index()
        {
            entities = new RoadItEntities();
            ViewBag.Error = Session["error"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            entities = new RoadItEntities();
            var MailList = new List<string>();
            var PasswordList = new List<string>();
            var NameList = new List<string>();
            foreach (var item in entities.Users)
            {
                MailList.Add(item.Email.ToString());
                PasswordList.Add(item.Password.ToString());
                NameList.Add(item.Name.ToString());
            }
            Console.WriteLine("het werkt");
            for (var i = 0; i < MailList.Count; i++ )
            {
                if (MailList[i] == email.ToString())
                {
                    if (PasswordList[i].ToString() == password.ToString())
                    {
                        
                        Session["email"] = email;
                        Session["password"] = password;
                        Session["Username"] = NameList[i].ToString() + " - LogOut";
                        return RedirectToAction("Index", "RoadSelection");
                    }
                    else
                    {
                        Session["error"] = "Wrong password";
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            Session["error"] = "Wrong email";
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
