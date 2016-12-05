using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class ContractorController : Controller
    {
        //
        // GET: /Contractor/

        public ActionResult Index()
        {
            try
            {
                var entities = new sammegf117_roaditEntities();
                Session["Planning"] = GenerateTablePlanning(entities);
                Session["AsphaltMixPlant"] = GenerateTableAsphaltMixPlant(entities);
                Session["Truck"] = GenerateTableTruck(entities);
                Session["TruckTime"] = GenerateTableTruckTemp(entities);
                Session["TruckStop"] = GenerateTableTruckStops(entities);
                Session["Position"] = GenerateTableTruckLocation(entities);
                Session["PositionReturn"] = GenerateTableTruckLocationReturn(entities);
                Session["Finisher"] = GenerateTableFinisher(entities);
                Session["FinisherSpeed"] = GenerateTableFinisherSpeed(entities);
                Session["wheater"] = GenerateTableWheater(entities);
                Session["FinisherStop"] = GenerateTableFinisherStops(entities);
                Session["Compactor"] = GenerateTableCompactor(entities);
                Session["QualityControl"] = GenerateTableQualityControl(entities);
                return View();
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page";
                return View();
            }
        }

        public string GenerateTablePlanning(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Planning</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Asphalt layer thickness</th><th>Amount of squares metres planned</th><th>Estimated amount of asphalt per 24 hours (ton) per asphalt type</th></tr>";

            foreach (var item in entities.ContractorViews)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.PlanningTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.PlanningTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.LayerThickness + "mm</td><td>" + item.Surface + "mm²</td><td>" + item.TonPerDay + "</td></tr>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }

        public string GenerateTableAsphaltMixPlant(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Asphalt Mixure Plant</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Mixture name</th><th>Technical datasheet</th></tr>";

            foreach (var item in entities.ContractorViews)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td><a href=" + item.MixtureName + ">download</a></td><td><a href=" + item.TechnicalDataSheet + ">download</a></td></tr>";
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
            table += "<th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th><th>Arrival time at site</th><th>Time and location of attachment to finisher</th><th>Time and location of deattachment finisher</th><th>Arrival at plant</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td><td>" + item.RealArrivalTime + "</td><td>" + item.AttachmentToFinisherPosition + " " + item.AttachmentToFinisherTime + "</td><td>" + item.DeattachmentFinisherPosition + " " + item.DeattachmentFinisherTime + "</td><td>" + item.ArrivalAtPlant + "</td></tr>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }
        public string GenerateTableTruckTemp(sammegf117_roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport temperatuur</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<tr><th>actual temperature asphalt in truck</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TempTruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TempTruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td> Temp: " + item.Temp + "°C Date: " + item.TempTruckTimeStamp + "</td></tr>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }

        public string GenerateTableTruckStops(sammegf117_roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport Stops</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<tr><th>Unforeseen stop ( > 10 min)</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.UnforseenStopTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.UnforseenStopTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td> Time: " + item.StopTimeUnforseenStop + " Coordinates: " + item.StopLocationUnforseenStop + " Date: " + item.UnforseenStopTimeStamp + "</td></tr>";
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

        public string GenerateTableTruckLocationReturn(sammegf117_roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport location return</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<tr><th>Locatie truck (return)</th><th>Geschatte tijd van aankomst (return)</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.ActualPositionReturnTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.ActualPositionReturnTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.ActualPositionReturn + " " + item.ActualPositionReturnTimeStamp + "</td><td>" + item.ETAReturn + "</td></tr>";
                    }
                }
            }
            table += "</table><br /></div>";
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
                        table += "<tr><td>" + item.Speed + "km/h</td></tr>";
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
            table += "<th>Compactor QR code</th><th>Number of roller compactor passages</th><th>Location of vibration</th><th>ColorCodeID (Finisher and Compactor location)</th><th>Speed of the roller compactor</th><th>Location compactor</th></tr>";

            foreach (var item in entities.ContractorViews)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompactorTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompactorTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td><a href=" + item.QrCodeCompactor + ">link</a></td><td><a href=" + item.NumberOfRollerCompactorPassages + ">link</a></td><td><a href=" + item.LocationOfVibration + ">link</a></td><td>Finisher: " + item.GPSFinisher + " Compactor: " + item.GPSCompactor + "</td><td>" + item.SpeedOfRollerCompactor + "km/h</td><td>" + item.GPSCompactor + "</td></tr>";
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

            foreach (var item in entities.ContractorViews)
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
        }
    }
}
