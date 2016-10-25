using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class RoadSelectionController : Controller
    {
        public ActionResult Index()
        {
            var entities = new RoadItEntities();
            Session["SelectList"] = GenerateSelectList(entities);
            return View();
        }


        [HttpPost]
        public ActionResult SelectSection(int RoadSectionId) 
        {
            Session["roadID"] = RoadSectionId;
<<<<<<< HEAD
            var roleId = Convert.ToInt32(Session["RoleId"]);
            var pageRef = "";
            switch (roleId)
            {
                case 1:
                    pageRef = "Client";
                    break;
                case 2:
                    pageRef = "AsphaltProducer";
                    break;
                case 3:
                    pageRef = "Transporter";
                    break;
                case 4:
                    pageRef = "Contractor";
                    break;
                case 5:
                    pageRef = "Copro";
                    break;
                case 6:
                    pageRef = "UA";
                    break;
            }
            return RedirectToAction("Index",pageRef);
=======
            return RedirectToAction("Index","UA");
>>>>>>> cd36851cba3c43700fd5d7f9615a1d7ce5cef4ad
        }

        public string GenerateSelectList(RoadItEntities entities)
        {
            var DataList = new List<int>();
            DataList.Add(0);

            var option = "<select id='RoadSectionId' name='RoadSectionId'>";
            foreach (var item in entities.RoadSections)
            {
                if (item.RoadId != Convert.ToInt32(DataList.Last()))
                {
                    DataList.Add(item.RoadId);

                    option += "<option value=" + item.RoadId + ">" + item.RoadId + ", " + item.RoadDescription + "</option>";
                }
            }
            option += "</select><input type='submit' Text='Submit'/>";

            return option;
        }
    }
}
