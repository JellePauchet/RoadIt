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
            return View();
        }

        [HttpPost]
        public Boolean checkLogin(string email, string password)
        {
            
            var UserList = new List<string>();
            foreach (var item in entities.Users)
            {
                UserList.Add(item.Email.ToString());
            }
            for (var i = 0; i > UserList.Count;i++)
            {
                if(UserList[i] == email.ToString());
                {
                       
                }
            }
            Session["email"] = email;
            Session["password"] = password;
            
            return (true);
        }
    }
}
