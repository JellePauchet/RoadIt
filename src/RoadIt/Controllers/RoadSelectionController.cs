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
            var entities = new sammegf117_roaditEntities();
            Session["SelectList"] = GenerateSelectList(entities);
            return View();
        }


        [HttpPost]
        public ActionResult SelectSection(int RoadSectionId, DateTime StartDate ,DateTime StopDate) 
        {
            Session["roadID"] = RoadSectionId;
            Session["StartDate"] = StartDate.Date.ToString("d");
            Session["StopDate"] = StopDate.Date.ToString("d");
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
        }

        public string GenerateSelectList(sammegf117_roaditEntities entities)
        {
            var DataList = new List<int>();
            DataList.Add(0);

            var option = "<p>Choose a roadsection from the list.</p><select id='RoadSectionId' name='RoadSectionId'>";
            foreach (var item in entities.RoadSections)
            {
                if (item.RoadId != Convert.ToInt32(DataList.Last()))
                {
                    DataList.Add(item.RoadId);

                    option += "<option value=" + item.RoadId + ">" + item.RoadId + ", " + item.RoadDescription + "</option>";
                }
            }
            option += "</select><br><br><br><br><p>Choose a start and stop date to form a period to search.</p>";
            option += "<p>Start date: <input type='date' id='StartDate' name='StartDate'></p><br/>";
            option += "<p>Stop date: <input type='date' id='StopDate' name='StopDate'></p>";
            option += "<input type='submit' Text='Submit'/>";
            
            return option;
        }
    }
}
