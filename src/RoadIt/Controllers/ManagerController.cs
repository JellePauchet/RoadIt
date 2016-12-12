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
        public ActionResult Index(List<string[]> list1, List<string[]> list2, List<string[]> list3, List<string[]> list4)
        {
            ViewData["tableSpec"] = GenerateTableSpecifications(SpecArray);
            ViewData["tableTransport"] = GenerateTableTransport(TransportList,SpecArray);
            return View();
        }

        //variabelen
        public static List<string[]> TransportList = new List<string[]>();
        public static List<string[]> TotalList = new List<string[]>();
        public static List<string[]> PlantList = new List<string[]>();
        public static List<string[]> MixtureList = new List<string[]>();
        public static string[] SpecArray = new string[5];

        
        //setters
        public static void SetTransportList(List<string[]> input) 
        {
            TransportList = null;
            TransportList = input;
            
        }

        public static void SetTotalList(List<string[]> input)
        {
            TotalList = null;
            TotalList = input;
        }

        public static void SetPlantList(List<string[]> input)
        {
            PlantList = null;
            PlantList = input;
        }

        public static void SetMixtureList(List<string[]> input)
        {
            MixtureList = null;
            MixtureList = input;
        }

        public static void SetSpecArray(string[] input)
        {
            SpecArray = null;
            SpecArray = input;
        }

        public  ManagerController()
        {}

        public  ManagerController(List<string[]> list1, List<string[]> list2, List<string[]> list3, List<string[]> list4, string[] Specs) 
        {
            SetTotalList(list1);
            SetTransportList(list2);
            SetPlantList(list3);
            SetMixtureList(list4);
            SetSpecArray(Specs);
        }

        public string GenerateTableSpecifications(string[] ArraySpec) //RoadId nog toevoegen aan view
        {
            string table = "";
            table += "<h3>Project & mixture specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            
            table += "<tr><td><b>Construction site ID (road section ID):</b></td><td>"+ ArraySpec[0] +"</td></tr>";
            table += "<tr><td><b>Layer type:</b></td><td>" + ArraySpec[1] + "</td></tr>"; 
            table += "<tr><td><b>Mixture type:</b></td><td>" + ArraySpec[2] + "</td></tr>";
            table += "<tr><td><b>Accepted temperature range:</b></td><td>" + ArraySpec[3] + "°C - " + ArraySpec[4] + "°C </td></tr>";
            
            table += "</table>";
            return table;
        }

        public static string GenerateTableTransport(List<string[]> ListValueTruck, string[] ArraySpec) //RoadId nog toevoegen aan view
        {
            string table = "";
            table += "<h3>Transport specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th></th><th>Truck ID</th><th>Plant ID</th><th>Mixture</th><th>Mass(tons)</th><th>Temp.</th><th>Finisher ID</th><th>LocationFinisher</th><th>Accepted</th></tr>";

            
            int counter = 1;
            foreach (var item in ListValueTruck)
            {
                table += "<tr>";
                table += "<td>" + counter + "</td>";
                counter++;
                for (int i = 0; i < 7; i++)
                {
                    table += "<td>";
                    if (item[i] != "")
                    {
                        table += item[i];
                    }
                    table += "</td>";
                }
                table += "<td>";
                if(item[4] != "")
                {
                    if (Convert.ToInt32(item[4]) >= Convert.ToInt32(ArraySpec[3]) && Convert.ToInt32(item[4]) <= Convert.ToInt32(ArraySpec[4]))
                    {
                        table += "Accepted";
                    }
                    else
                    {
                        table += "Rejected";
                    }
                }
                table += "</tr>";
                 
            }            
            table += "</table>";
            return table;
        }

        public static string GenerateTableTotal(List<string[]> ListValue) //RoadId nog toevoegen aan view
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

        public static string GenerateTablePlants1(List<string[]> ListValue) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Examples of plants, mixtures, temperatures</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<tr><th>Plants</th><th>Full name</th></tr>";
            table += "<tr><td></td><td></td></tr>";
            
            table += "</table>";
            return table;
        }

        public static string GenerateTablePlants2(List<string[]> ListValue) //RoadId nog toevoegen aan view
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
