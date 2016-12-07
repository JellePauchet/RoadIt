using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/

        public ActionResult Index()
        {
            Session["tableSpecifications"] = GenerateTableSpecifications();
            Session["tableTruck"] = GenerateTableTruck();
            Session["tableTotal"] = GenerateTableTotal();
            Session["tablePlants1"] = GenerateTablePlants1();
            Session["tablePlants2"] = GenerateTablePlants2();
        }

        public string GenerateTableSpecifications() //RoadId nog toevoegen aan view
        {
            var table = "<h3>Project & mixture specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            
            table += "<tr><td><b>Construction site ID (road section ID):</b></td><td>"+ Session["RoadID"] +"</td></tr>";
            table += "<tr><td><b>Layer type:</b></td><td>Toplayer</td></tr>"; 
            table += "<tr><td><b>Mixture type:</b></td><td></td></tr>";
            table += "<tr><td><b>Accepted temperature range:</b></td><td></td></tr>";
            
            table += "</table>";
            return table;
        }

        public string GenerateTableTruck() //RoadId nog toevoegen aan view
        {
            var table = "<h3>Transport specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th></th><th>Truck ID</th><th>Plant ID</th><th>Mixture</th><th>Mass(tons)</th><th>Temp.</th><th>Finisher ID</th><th>LocationFinisher</th><th>Accepted</th></tr>";

            table += "<tr>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "<td>";
            if ("" == "")
            {
                table += "";
            }
            table += "</td>";

            table += "</tr>";
            
            table += "</table>";
            return table;
        } 

        public string GenerateTableTotal() //RoadId nog toevoegen aan view
        {
            var table = "<h3>Totals today</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<tr><th></th><th>Totals</th><th></th><th></th></tr>";
            table += "<tr><td>Accepted trucks</td><td></td><td></td><td></td></tr>";
            table += "<tr><td>Rejected trucks</td><td></td><td></td><td></td></tr>";
            table += "<tr><td>Accepted mass</td><td></td><td></td><td></td></tr>";
            
            table += "</table>";
            return table;
        } 

        public string GenerateTablePlants1() //RoadId nog toevoegen aan view
        {
            var table = "<h3>Examples of plants, mixtures, temperatures</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<tr><th>Plants</th><th>Full name</th></tr>";
            table += "<tr><td></td><td></td></tr>";
            
            table += "</table>";
            return table;
        }

        public string GenerateTablePlants2() //RoadId nog toevoegen aan view
        {
            var table = "<h3>Examples of plants, mixtures, temperatures</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<tr><th>Mixtures</th><th>Temperature Range</th></tr>";
            table += "<tr><td></td><td></td></tr>";

            table += "</table>";
            return table;
        } 
        
    }
}
