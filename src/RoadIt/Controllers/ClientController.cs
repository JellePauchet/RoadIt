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
        
        List<string[]> TotalList = new List<string[]>();
        List<string[]> PlantList = new List<string[]>();
        List<string[]> MixtureList = new List<string[]>();

        public ActionResult Index()
        {
            
            try
            {
                var entities = new sammegf117_roaditEntities();
                /*Session["AsphaltMixPlant"] = GenerateTableAsphaltMixPlant(entities);
                Session["Truck"] = GenerateTableTruck(entities);
                Session["TruckLocation"] = GenerateTableTruckLocation(entities);
                Session["Finisher"] = GenerateTableFinisher(entities);
                Session["FinisherSpeed"] = GenerateTableFinisherSpeed(entities);
                Session["wheater"] = GenerateTableWheater(entities);
                Session["FinisherStop"] = GenerateTableFinisherStops(entities);
                Session["Compactor"] = GenerateTableCompactor(entities);
                Session["QualityControl"] = GenerateTableQualityControl(entities);*/
                Session["TransportList"] = (List<string[]>) GetTransportList(entities);
                Session["TotalList"] = GetTotalList(entities);
                Session["PlantList"] = GetPlantList(entities);
                Session["MixtureList"] = GetMixtureList(entities);
                return RedirectToAction("Index", "Manager");
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page"; 
                return View();
            }
            
        }

        public List<String[]> GetTransportList(sammegf117_roaditEntities entities)
        {
            List<string[]> TransportList = new List<string[]>();
            foreach (var item in entities.Clients)
            {
                String[] arrayValue = new String[6];
                arrayValue[0] = item.TruckLicensPlate;
                arrayValue[1] = "In db aanpassen";
                arrayValue[2] = item.MixtureName;
                arrayValue[3] = item.MassTruck.ToString();
                arrayValue[4] = "";
                arrayValue[5] = "";
                arrayValue[6] = item.GPSFinisher;
  
                TransportList.Add(arrayValue);
            }
            return TransportList;
        }

        public List<String[]> GetTotalList(sammegf117_roaditEntities entities)
        {
            foreach (var item in entities.Clients)
            {
                String[] arrayValue = new String[1];
                arrayValue[0] = "In db aanpassen";

                TotalList.Add(arrayValue);
            }
            return TotalList;
        }
        public List<String[]> GetPlantList(sammegf117_roaditEntities entities)
        {
            foreach (var item in entities.Clients)
            {
                String[] arrayValue = new String[2];
                arrayValue[0] = "In db aanpassen";
                arrayValue[6] = "volledige naam asphaltplant";

                PlantList.Add(arrayValue);
            }
            return PlantList;
        }
        public List<String[]> GetMixtureList(sammegf117_roaditEntities entities)
        {
            foreach (var item in entities.Clients)
            {
                String[] arrayValue = new String[2];
                arrayValue[0] = item.MixtureName;
                arrayValue[1] = "MinTemp";
                arrayValue[2] = "MaxTemp";

                MixtureList.Add(arrayValue);
            }
            return MixtureList;
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
