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
        public ActionResult Index()
        {
            return View();
        }

        //variabelen
        public List<string[]> TransportList = new List<string[]>();
        public List<string[]> TotalList = new List<string[]>();
        public List<string[]> PlantList = new List<string[]>();
        public List<string[]> MixtureList = new List<string[]>();

        //getters
        public List<string[]> GetTransportList() 
        {
            return this.TransportList;
        }

        public List<string[]> GetTotalList()
        {
            return this.TotalList;
        }

        public List<string[]> GetPlantList()
        {
            return this.PlantList;
        }

        public List<string[]> GetMixtureList()
        {
            return this.MixtureList;
        }

        //setters
        public void SetTransportList(List<string[]> input) 
        {
            this.TransportList = null;
            this.TransportList = input;
            
        }

        public void SetTotalList(List<string[]> input)
        {
            this.TotalList = input;
        }

        public void SetPlantList(List<string[]> input)
        {
            this.PlantList = input;
        }

        public void SetMixtureList(List<string[]> input)
        {
            this.MixtureList = input;
        }


        public ManagerController(List<string[]> list1, List<string[]> list2, List<string[]> list3, List<string[]> list4) 
        {
            this.SetTotalList(list1);
            this.SetTransportList(list2);
            this.SetPlantList(list3);
            this.SetMixtureList(list4);

            //Session["tableSpecifications"] = null;
            //Session.Add("tableTransport", GenerateTableTransport(this.TransportList));
            ViewBag.tableTransport = GenerateTableTransport(this.TransportList);
            //Session["tableTotal"] = null;
            //Session["tablePlants"] = null;
            //Session["tableMixture"] = null;
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

        public string GenerateTableTransport(List<string[]> ListValue) //RoadId nog toevoegen aan view
        {
            string table = "";
            table += "<h3>Transport specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th></th><th>Truck ID</th><th>Plant ID</th><th>Mixture</th><th>Mass(tons)</th><th>Temp.</th><th>Finisher ID</th><th>LocationFinisher</th><th>Accepted</th></tr>";

            table += "<tr>";

            for (int i = 0; i < 1; i++)
            { 
                for (int a = 0; a < 1; a++)
                { 
                    table += "<td>";
                    if (ListValue.ElementAt(0)[0] != "")
                    {
                        table += ListValue.ElementAt(0)[0];
                    }
                    table += "</td>";
                }
            }
                
            table += "</tr>";
            
            table += "</table>";
            return table;
        }

        public string GenerateTableTotal(List<string[]> ListValue) //RoadId nog toevoegen aan view
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

        public string GenerateTablePlants1(List<string[]> ListValue) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Examples of plants, mixtures, temperatures</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<tr><th>Plants</th><th>Full name</th></tr>";
            table += "<tr><td></td><td></td></tr>";
            
            table += "</table>";
            return table;
        }

        public string GenerateTablePlants2(List<string[]> ListValue) //RoadId nog toevoegen aan view
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
