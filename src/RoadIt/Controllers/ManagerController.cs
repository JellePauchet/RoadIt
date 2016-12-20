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
            CounterA = 0;
            CounterR = 0;
            TotalMas = 0;
            CountersReset();
            ViewData["tableSpec"] = GenerateTableSpecifications(SpecArray);
            ViewData["tableTransport"] = GenerateTableTransport(TransportList,SpecArray);
            ViewData["tableTotal"] = GenerateTableTotal(TotalList);
            ViewData["tablePlant"] = GenerateTablePlants(PlantList);
            ViewData["tableMix"] = GenerateTableMixture(MixtureList);
            return View();
        }

        #region variabelen

        public static List<string[]> TransportList = new List<string[]>();
        public static List<string[]> TotalList = new List<string[]>();
        public static List<string[]> PlantList = new List<string[]>();
        public static List<string[]> MixtureList = new List<string[]>();
        public static string[] SpecArray = new string[5];
        public static int CounterA = 0;
        public static int CounterR = 0;
        public static List<List<string>> AcceptedList = new List<List<string>>();
        public static List<List<string>> RejectedList = new List<List<string>>();
        public static List<List<string>> TotalMasList = new List<List<string>>();
        public static int TotalMas = 0;
        #endregion

        #region setters
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
        #endregion

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

        #region Counters
        public static void CountersReset()
        {
            AcceptedList.Clear();
            RejectedList.Clear();
            TotalMasList.Clear();
            List<string> nul = new List<string>();
            nul.Add("");
            nul.Add("");
            AcceptedList.Add(nul);
            RejectedList.Add(nul);
            TotalMasList.Add(nul);
        }

        public static void CountAccepted(string CentralName)
        {
            int counter = 0;
            for (int i = 0; i < AcceptedList.Count(); i++)
            {
                if(AcceptedList[i][0] == CentralName)
                {
                    string list = AcceptedList[i][1];
                    int tel = Convert.ToInt32(list);
                    tel++;
                    AcceptedList[i][1] = tel.ToString();
                }
                else
                {
                    counter++;
                }
            }
            if (counter == AcceptedList.Count())
            {
                AcceptedList.Clear();
                List<string> list = new List<string>();
                list.Add(CentralName);
                list.Add("1");
                AcceptedList.Add(list);
            }
        }

        public static void CountRejected(string CentralName)
        {
            int counter = 0;
            for (int i = 0; i < RejectedList.Count(); i++)
            {
                if (RejectedList[i][0] == CentralName)
                {
                    string list = RejectedList[i][1];
                    int tel = Convert.ToInt32(list);
                    tel ++;
                    RejectedList[i][1] = tel.ToString();
                }
                else
                {
                    counter++;
                }
            }
            if (counter == RejectedList.Count())
            {
                RejectedList.Clear();
                List<string> list = new List<string>();
                list.Add(CentralName);
                list.Add("1");
                RejectedList.Add(list);
            }
        
        }

        public static void CountTotalMas(string CentralName, int Mass)
        {
            int counter = 0;
            for (int i = 0; i < TotalMasList.Count(); i++)
            {
                if (TotalMasList[i][0] == CentralName)
                {
                    string list = TotalMasList[i][1];
                    int tel = Convert.ToInt32(list);
                    tel += Mass;
                    TotalMasList[i][1] = tel.ToString();
                }
                else
                {
                    counter++;
                }
            }
            if (counter == TotalMasList.Count())
            {
                TotalMasList.Clear();
                List<string> list = new List<string>();
                list.Add(CentralName);
                list.Add(Mass.ToString());
                TotalMasList.Add(list);
            }
        }
        #endregion

        #region Generators
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
            table += "<tr onClick='showTable1C()'><th></th><th>Truck ID</th><th>Plant ID</th><th>Mixture</th><th>Mass(tons)</th><th>Temp.</th><th>Finisher ID</th><th>LocationFinisher</th><th>Accepted</th></tr>";

            int counter = 1;
            foreach (var item in ListValueTruck)
            {
                table += "<tr class='hide hideH tableRow1'>";
                table += "<td>" + counter + "</td>";
                counter++;
                for (int i = 0; i < 7; i++)
                {
                    table += "<td>";
                    if (item[i] != "")
                    {
                        if (i == 4)
                        {
                            table += "<span style='color:red;'>" + item[i] + "</span>";
                        }
                        else
                        {
                            table += item[i];
                        }
                    }
                    table += "</td>";
                }
                table += "<td>";
                if (item[4] != "")
                {
                    if (Convert.ToInt32(item[4]) >= Convert.ToInt32(ArraySpec[3]) && Convert.ToInt32(item[4]) <= Convert.ToInt32(ArraySpec[4]))
                    {
                        table += "Accepted";
                        CounterA++;
                        CountAccepted(item[1]);
                        CountTotalMas(item[1], Convert.ToInt32(item[3]));
                    }
                    else
                    {
                        table += "<span style='color:red;'>Rejected</span>";
                        CounterR++;
                        CountRejected(item[1]);
                    }
                }
                table += "</tr>";
                TotalMas += Convert.ToInt32(item[3]);
            }            
            table += "</table>";
            return table;
        }

        public static string GenerateTableTotal(List<string[]> ListValue) //RoadId nog toevoegen aan view
        {
            int AcceptedC = 0;
            int RejectedC = 0;
            int MassC = 0;
            string table = "";
            table = "<h3>Totals today</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<tr><th></th><th>Totals</th><th></th><th></th></tr>";
            table += "<tr><td>Accepted trucks</td>";
            table += "<td>" + CounterA.ToString() + "</td>";
            foreach (var item in AcceptedList)
            {
                AcceptedC++;
                if (AcceptedC > 1)
                {
                    table += "<tr><td></td><td></td>";
                }
                for (int i = 0; i < 2; i++)
                {
                    table += "<td>";
                    if (item[i] != "")
                    {
                        table += item[i];

                    }
                    table += "</td>";
                }
                table += "</tr>";
            }
           
            table += "<tr><td>Rejected trucks</td>";
            table += "<td>" + CounterR.ToString() + "</td>";
            foreach (var item in RejectedList)
            {
                RejectedC++;
                if (RejectedC > 1)
                {
                    table += "<tr><td></td><td></td>";
                }
                for (int i = 0; i < 2; i++)
                {
                    table += "<td>";
                    if (item[i] != "")
                    {
                            table += item[i];

                    }
                    table += "</td>";
                }
                table += "</tr>";
            }
            table += "<tr><td>Accepted mass</td>";
            if (AcceptedList.Count() > 2)
            {
                table += "<td>" + TotalMas.ToString() + "</td>";
            }
            else
            {
                table += "<td>0</td>";
            }
            foreach (var item in TotalMasList)
            {
                MassC++;
                if (MassC > 1)
                {
                    table += "<tr><td></td><td></td>";
                }
                for (int i = 0; i < 2; i++)
                {
                    table += "<td>";
                    if (item[i] != "")
                    {
                        table += item[i];

                    }
                    table += "</td>";
                }
                table += "</tr>";
            }
            
            table += "</table>";
            return table;
        }

        public static string GenerateTablePlants(List<string[]> ListValue) //RoadId nog toevoegen aan view
        {
            string table = "";
            table = "<h3>Examples of plants, mixtures, temperatures</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr onClick='showTable2()'><th>Plants</th><th>Full name</th></tr>";

            foreach (var item in ListValue)
            {
                table += "<tr class='hide tableRow2'>";
                for (int i = 0; i < 2; i++)
                {
                    table += "<td>";
                    if (item[i] != "")
                    {
                        table += item[i];
                    }
                    table += "</td>";
                }
                table += "</tr>";
            }
            table += "</table>";
            return table;
        }

        public static string GenerateTableMixture(List<string[]> ListValue) //RoadId nog toevoegen aan view
        {
            string table = "";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr onClick='showTable3()'><th>Mixtures</th><th>Temperature Range</th></tr>";

            foreach (var item in ListValue)
            {
                table += "<tr class='hide tableRow3'>";
                table += "<td>" + item[0] + "</td>";
                table += "<td>" + item[1] + "°C - " + item[2] + "°C";
                table += "</tr>";
            }

            table += "</table>";
            return table;
        }
        #endregion
    }
}
