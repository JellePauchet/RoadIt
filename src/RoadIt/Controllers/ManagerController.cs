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
            try
            {
                var entities = new sammegf117_roaditEntities();
                return View();
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page";
                return View();
            }
        }

        public string GenerateTableSpecifications(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Project & mixture specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            
            table += "<tr><td><b>Construction site ID (road section ID):</b></td><td></td></tr>";
            table += "<tr><td><b>Layer type:</b></td><td>Toplayer</td></tr>";
            table += "<tr><td><b>Mixture type:</b></td><td></td></tr>";
            table += "<tr><td><b>Accepted temperature range:</b></td><td></td></tr>";
            
            table += "</tabel>";
            return table;
        }

        public string GenerateTableTruck(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Transport specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<th><td>Truck ID</td><td>Plant ID</td><td>Mixture</td><td>Mass(tons)</td><td>Temp.</td><td>Finisher ID</td><td>LocationFinisher</td><td>Accepted</td></th>";
            
            table += "</tabel>";
            return table;
        } 

        public string GenerateTableTotal(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Totals today</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<th><td></td><td>Totals</td><td></td><td></td></th>";
            table += "<tr><td>Accepted trucks</td><td></td><td></td></tr>";
            table += "<tr><td>Rejected trucks</td><td></td><td></td></tr>";
            table += "<tr><td>Accepted mass</td><td></td><td></td></tr>";
            
            table += "</tabel>";
            return table;
        } 

        public string GenerateTablePlants1(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Examples of plants, mixtures, temperatures</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<th><td>Plants</td><td>Full name</td></th>";
            table += "<tr><td></td><td></td></tr>";
            
            table += "</tabel>";
            return table;
        }

        public string GenerateTablePlants2(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Examples of plants, mixtures, temperatures</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<th><td>Mixtures</td><td>Temperature Range</td></th>";
            table += "<tr><td></td><td></td></tr>";

            table += "</tabel>";
            return table
        } 
        
    }
}
