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
            ViewData["SelectList"] = GenerateSelectList(entities); 
            return View();
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
            option += "</select><asp:button Text='Submit' runat='server' OnClick='Submit'/>";

            return option;
        }
    }
}
