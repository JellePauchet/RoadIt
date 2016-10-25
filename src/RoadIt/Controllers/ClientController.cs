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
            var entities = new RoadItEntities();
            if (Session["RoleId"].ToString() == "1")
            {
                ViewData["AsphaltMixPlant"] = GenerateTableAsphaltMixPlant(entities);
                ViewData["Truck"] = GenerateTableTruck(entities);
                ViewData["Finisher"] = GenerateTableFinisher(entities);
                ViewData["Compactor"] = GenerateTableCompactor(entities);
                ViewData["QualityControl"] = GenerateTableQualityControl(entities);
            }
            else
            {
                ViewBag.error = "You have no authorities to view this page";
            }
            return View();
        }

        public string GenerateTableAsphaltMixPlant(RoadItEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Asphalt Mixure Plant</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'>";
            table += "<tr><th>Construction site ID (road section ID)</th><th>Mixture name</th><th>Technical datasheet</th><th>Mixture change</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td>" + Session["roadID"] + "</td><td><a href=" + item.MixtureName + ">download</a></td><td><a href=" + item.TechnicalDataSheet + ">download</a></td><td>" + item.MixtureChange + "</td></tr>";
                }

            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableTruck(RoadItEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr>";
            table += "<th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th><th>Location Transport (every 30 sec)</th><th>ETA</th><th>Arrival time at site</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td><td>" + item.ActualPosition + "</td><td>" + item.ETA + "</td><td>" + item.RealArrivalTime + "</td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableFinisher(RoadItEntities entities)// batchId niet in view
        {
            var table = "<h3>Finisher</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr>";
            table += "<th>BatchID</th><th>Speed</th><th>Width</th><th>Angle Left</th><th>Angle Right</th><th>Thickness of the layer (Left)</th><th>Thickness of the layer (Middle)</th><th>Thickness of the layer (Right)</th><th>Tranverse slope</th><th>location of stop</th><th>Time of stop</th><th>precipitation</th><th>Air temperature</th><th>Wind speed</th><th>Air humidity</th><th>Asphalt temperature after finisher</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td>" + "geen toegang via view" + "</td><td>" + item.FinisherSpeed + "</td><td>" + item.Width + "</td><td>" + item.AngleLeft + "</td><td>" + item.AngleRight + "</td><td>" + item.ThicknessLeft + "</td><td>" + item.ThicknessMiddel + "</td><td>" + item.ThicknessRight + "</td><td>" + item.TranverseSlope + "</td><td>" + item.StopLocation + "</td><td>" + item.StopTime + "</td><td>" + item.Precipation + "</td><td>" + item.Temp + "</td><td>" + item.WindSpeed + "</td><td>" + item.AirHumidity + "</td><td>" + item.AsphaltTempAfterFinisherIrScanOrThermo + "</td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableCompactor(RoadItEntities entities)// batchId niet in view
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr>";
            table += "<th>Compactor QR code</th><th>ColorCodeID</th></tr>";

            foreach (var item in entities.Clients)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td><a href=" + item.QrCodeCompactor + ">link</a></td><td>" + item.ColorCodeId + "</td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableQualityControl(RoadItEntities entities)
        {
            var table = "<h3>Qualitie control</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'>";
            table += "<tr><th>Compliance mixtures</th><th>Copro samples</th><th>Asphalt temperature (IR scanner)</th><th>Aspahlt temperature (thermometer)</th><th>Density measurements on field</th><th>Cores</th><th>Lengthwise flatness</th><th>Skidreskstance</th><th>IRI</th><th>Extra tests asked by client</th></tr>";

            foreach (var item in entities.UAs)
            {
                if ("4" == Session["roadID"].ToString())
                {
                    table += "<tr><td><a href=" + item.ComplianceMixture + ">download</a></td><td><a href=" + item.SamplesCopro + ">download</a></td><td>" + item.AsphaltTempAfterFinisherIrScanOrThermo + "</td><td>" + item.Temp + "</td><td><a href=" + item.DensityOfField + ">download</a></td><td><a href=" + item.Cores + ">download</a></td><td><a href=" + item.LengthwiseFlatness + ">download</a></td><td><a href=" + item.Skidresistance + ">download</a></td><td><a href=" + item.Iri + ">download</a></td><td><a href=" + item.ExtraTestsAskedBijClient + ">download</a></td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }
    }
}
