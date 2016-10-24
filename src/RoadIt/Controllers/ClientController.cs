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
            ViewData["Table1"] = GenerateTable1(entities);
            ViewData["Table2"] = GenerateTable2(entities);
            ViewData["Table3"] = GenerateTable3(entities);
            ViewData["Table4"] = GenerateTable4(entities);
            return View();
        }

        public string GenerateTable1(RoadItEntities entities)
        {
            var table = "";
            table += "<h3>Project & mixture specifications</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr><th>Construction site ID (road section ID)</th><th>Mixture name</th><th>Technical datasheet</th><th>Mixture change</th></tr>";

            foreach (var item in entities.Clients)
            {
                table += "<tr><td>" + TempData["RoadSection"] + "</td><td><a href=" + item.MixtureName + ">download</a></td><td><a href=" + item.TechnicalDataSheet + ">download</a></td><td><a href=" + item.MixtureChange + ">download</a></td></tr>";
            }

            table += "</table><br />";

            return table;
        }

        public string GenerateTable2(RoadItEntities entities)
        {
            var table = "";
            table += "<h3>Transport details</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr><th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th><th>Location Transport (every 30 sec)</th><th>Arrival time at site</th></tr>";

            foreach (var item in entities.Clients)
            {
                table += "<tr><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td><td>" + item.ActualPosition + "</td><td>" + item.RealArrivalTime + "</td></tr>";
            }

            table += "</table><br />";

            return table;
        }

        public string GenerateTable3(RoadItEntities entities)
        {
            var table = "";
            table += "<h3>Finisher and compactor details</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr><th>Speed</th><th>Width</th><th>Angle Left</th><th>Angle Right</th><th>Thickness of the layer (Left)</th><th>Thickness of the layer (Middle)</th><th>Thickness of the layer (Right)</th><th>Tranverse slope</th><th>location of stop</th><th>Time of stop</th><th>precipitation</th><th>Air temperature</th><th>Wind speed</th><th>Air humidity</th><th>Asphalt temperature after finisher</th><th>Compactor QR code</th><th>Location finisher</th><th>Location compactor</th></tr>";

            foreach (var item in entities.Clients)
            {
                table += "<tr><td>" + item.FinisherSpeed + "</td><td>" + item.Width + "</td><td>" + item.AngleLeft + "</td><td>" + item.AngleRight + "</td><td>" + item.ThicknessLeft + "</td><td>" + item.ThicknessMiddel + "</td><td>" + item.ThicknessRight + "</td><td>" + item.TranverseSlope + "</td><td>" + item.StopLocation + "</td><td>" + item.StopTime + "</td><td>" + item.Precipation + "</td><td>" + item.Temp + "</td><td>" + item.WindSpeed + "</td><td>" + item.AirHumidity + "</td><td>" + item.AsphaltTempAfterFinisherIrScanOrThermo + "</td><td><a href=" + item.QrCodeCompactor + ">link</a></td><td>" + item.GPSFinisher + "</td><td>" + item.GPSCompactor + "</td></tr>";
            }

            table += "</table><br />";

            return table;
        }

        public string GenerateTable4(RoadItEntities entities)
        {
            var table = "";
            table += "<h3>Qualitie control details</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr><th>Compliance mixtures</th><th>Copro samples</th><th>Asphalt temperature (IR scanner)</th><th>Aspahlt temperature (thermometer)</th><th>Density measurements on field</th><th>Cores</th><th>Lengthwise flatness</th><th>Skidreskstance</th><th>IRI</th><th>Extra tests asked by client</th></tr>";

            foreach (var item in entities.Clients)
            {
                table += "<tr><td><a href=" + item.ComplianceMixture + ">download</a></td><td><a href=" + item.SamplesCopro + ">download</a></td><td>" + item.AsphaltTempAfterFinisherIrScanOrThermo + "</td><td>" + item.Temp + "</td><td><a href=" + item.DensityOfField + ">download</a></td><td><a href=" + item.Cores + ">download</a></td><td><a href=" + item.LengthwiseFlatness + ">download</a></td><td><a href=" + item.Skidresistance + ">download</a></td><td><a href=" + item.Iri + ">download</a></td><td><a href=" + item.ExtraTestsAskedBijClient + ">download</a></td></tr>";
            }

            table += "</table><br />";

            return table;
        }
    }
}
