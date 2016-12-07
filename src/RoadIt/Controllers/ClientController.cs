using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {
            var entities = new sammegf117_roaditEntities();
            Session["tableTransport"] = GetTransportList(entities);
     
            try
            {
                

                return View();
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page"; 
                return View();
            }
            
        }

        public string GetTransportList(sammegf117_roaditEntities entities)
        {
            var table = "<h3>Transport specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Truck ID</th><th>Plant ID</th><th>Mixture</th><th>Mass(tons)</th><th>Temp.</th><th>Finisher ID</th><th>LocationFinisher</th><th>Accepted</th></tr>";
                 
            foreach (var item in entities.Clients)
            {
                table += "<tr>";
                table += "<td>";
                table += item.TruckLicensPlate; //DATA
                table += "</td>";
                table += "<td>";
                table += "In db aanpassen"; //DATA
                table += "</td>";
                table += "<td>";
                table += item.MixtureName; //DATA
                table += "</td>";
                table += "<td>";
                table += item.MassTruck; //DATA
                table += "</td>";
                table += "<td>";
                table += ""; //DATA
                table += "</td>";
                table += "<td>";
                table += ""; //DATA
                table += "</td>";
                table += "<td>";
                table += item.GPSFinisher; //DATA
                table += "</td>";
                table += "</tr>";
            }
                                   
            table += "</table>";

            return table;
        }

        public string GetTotalList(sammegf117_roaditEntities entities)
        {
            var table = "<h3>Totals today</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            foreach (var item in entities.Clients)
            {
                table += "<tr><th></th><th>Totals</th><th></th><th></th></tr>";
                table += "<tr><td>Accepted trucks</td><td></td><td></td><td></td></tr>";
                table += "<tr><td>Rejected trucks</td><td></td><td></td><td></td></tr>";
                table += "<tr><td>Accepted mass</td><td></td><td></td><td></td></tr>";
                //arrayValue[0] = "In db aanpassen";
            }
            
            table += "</table>";
            return table; 
        }

        public List<String[]> GetPlantList(sammegf117_roaditEntities entities)
        {
            List<string[]> PlantList = new List<string[]>();
            foreach (var item in entities.Clients)
            {
                String[] arrayValue = new String[7];
                arrayValue[0] = "In db aanpassen";
                arrayValue[1] = "";
                arrayValue[2] = "";
                arrayValue[3] = "";
                arrayValue[4] = "";
                arrayValue[5] = "";
                arrayValue[6] = "volledige naam asphaltplant";

                PlantList.Add(arrayValue);
            }
             
            return PlantList;
        }

        public List<String[]> GetMixtureList(sammegf117_roaditEntities entities)
        {
            List<string[]> MixtureList = new List<string[]>();
            foreach (var item in entities.Clients)
            {
                String[] arrayValue = new String[3];
                arrayValue[0] = item.MixtureName;
                arrayValue[1] = "MinTemp";
                arrayValue[2] = "MaxTemp";

                MixtureList.Add(arrayValue);
            }
            return MixtureList;
        }

        public string GenerateTableSpecifications() //RoadId nog toevoegen aan view
        {
            var table = "<h3>Project & mixture specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";

            table += "<tr><td><b>Construction site ID (road section ID):</b></td><td>" + Session["RoadID"] + "</td></tr>";
            table += "<tr><td><b>Layer type:</b></td><td>Toplayer</td></tr>";
            table += "<tr><td><b>Mixture type:</b></td><td></td></tr>";
            table += "<tr><td><b>Accepted temperature range:</b></td><td></td></tr>";

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
        /*
        public string GenerateTableAsphaltMixPlant(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Asphalt Mixure Plant</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Mixture name</th><th>Technical datasheet</th><th>Mixture change</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td><a href=" + item.MixtureName + ">download</a></td><td><a href=" + item.TechnicalDataSheet + ">download</a></td><td><a href=" + item.MixtureChange + ">download</a></td></tr>";
                    }
                }
            }
            table += "</table><br />";

            return table;
        }

        public string GenerateTableTruck(sammegf117_roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th><th>Arrival time at site</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td><td>" + item.RealArrivalTime + "</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableTruckLocation(sammegf117_roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<div><h3>Transport location</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<tr><th>Location Transport</th><th>Geschatte tijd van aankomst</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.ActualPositionTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.ActualPositionTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.ActualPosition + " " + item.ActualPositionTimeStamp + "</td><td>" + item.ETA + "</td></tr>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }

        public string GenerateTableFinisher(sammegf117_roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Finisher</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Width</th><th>Angle Left</th><th>Angle Right</th><th>Thickness of the layer (Left)</th><th>Thickness of the layer (Middle)</th><th>Thickness of the layer (Right)</th><th>Tranverse slope</th><th>precipitation</th><th>Asphalt temperature after finisher</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.FinisherTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.FinisherTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.Width + "m</td><td>" + item.LeftAngle + "°</td><td>" + item.RightAngle + "°</td><td>" + item.LeftTickness + "mm</td><td>" + item.MiddelThickness + "mm</td><td>" + item.RightThickness + "mm</td><td>" + item.TranverseSlope + "</td><td><a href=" + item.Precipation + ">download</a></td><td><a href=" + item.AsphaltTempAfterFinisherIrScanOrThermo + ">download</a></td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableFinisherSpeed(sammegf117_roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Finisher speed</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<tr><th>Speed</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.SpeedFinisherTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.SpeedFinisherTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.Speed + "km/u</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableWheater(sammegf117_roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Wheater</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<tr><th>Air temperature</th><th>Wind speed</th><th>Air humidity</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.WeatherTempTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.WeatherTempTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>Temp: " + item.TempWeather + "°C Date: " + item.WeatherTempTimeStamp + "</td><td>Speed: " + item.WindSpeed + "km/u Date: " + item.WindTimeStamp + "</td><td>Humidity: " + item.AirHumidity + "% Date: " + item.AirHumidityTimeStamp + "</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableFinisherStops(sammegf117_roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Finisher stops</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<tr><th>Time and location of stop</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.StopTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.StopTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>Time: " + item.StopTimeLTS + " Coordinates: " + item.StopLocationLTS + " Date: " + item.StopTimeStamp + "</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableCompactor(sammegf117_roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Compactor QR code</th><th>ColorCode (Finisher and compactor location)</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompactorTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompactorTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        string name = "https://chart.googleapis.com/chart?chs=150x150&cht=qr&chl="+item.QrCodeCompactor.ToString();
                        table += "<tr><td><img src='"+name+"' alt='QR code'></td><td> Finisher: " + item.GPS + " Compactor: " + item.GPSCompactor + "</td></tr>";
                    }
                }
            }

            
            table += "</table><br />";

            return table;
        }

        public string GenerateTableQualityControl(sammegf117_roaditEntities entities)
        {
            var table = "<h3>Qualitie control</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Compliance mixtures</th><th>Copro samples</th><th>Asphalt temperature (IR scanner)</th><th>Aspahlt temperature (thermometer)</th><th>Density measurements on field</th><th>Cores</th><th>Lengthwise flatness</th><th>Skidreskstance</th><th>IRI</th><th>Extra tests asked by client</th></tr>";

            foreach (var item in entities.UAs)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.QualtityTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.QualtityTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td><a href=" + item.ComplianceMixture + ">download</a></td><td><a href=" + item.SamplesCopro + ">download</a></td><td><a href=" + item.AsphaltTempAfterFinisherIrScanOrThermo + ">download</a></td><td>" + item.Temp + "°C</td><td><a href=" + item.DensityOfField + ">download</a></td><td><a href=" + item.Cores + ">download</a></td><td><a href=" + item.LengthwiseFlatness + ">download</a></td><td><a href=" + item.Skidresistance + ">download</a></td><td><a href=" + item.Iri + ">download</a></td><td><a href=" + item.ExtraTestsAskedBijClient + ">download</a></td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }*/
    }
}
