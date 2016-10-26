using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class AsphaltProducerController : Controller
    {
        //
        // GET: /AsphaltProducer/

        public ActionResult Index()
        {
            var entities = new RoadItEntities();

            try
            {
                ViewBag.error = "";
                ViewData["Planning"] = GenerateTablePlanning(entities);
                ViewData["AsphaltMixPlant"] = GenerateTableAsphaltMixPlant(entities);
                ViewData["Truck"] = GenerateTableTruck(entities);
                ViewData["Compactor"] = GenerateTableCompactor(entities);
                ViewData["QualityControl"] = GenerateTableQualityControl(entities);
                return View();
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page";
                return View();
            }

        }

        public string GenerateTablePlanning(RoadItEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Planning</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Estimated amount of asphalt per 24 hours (ton) per asphalt type</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td>" + item.TonPerDay + "</td></tr>";
                }

            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableAsphaltMixPlant(RoadItEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Asphalt Mixure Plant</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Mixture name</th><th>Technical datasheet</th><th>Types of aggregates</th><th>Aggregates: min. temperature</th><th>Aggregates: max. temperature</th><th>Aggregates: time</th><th>Bitumen: max. temperature</th><th>Bitumen: min. temperature</th><th>Bitumen: time</th><th>Use of filler recuperation</th><th>Mixing temperature</th><th>Mixing time</th><th>mass of aggregation bunker 1 (kg)</th><th>mass of aggregation bunker 2 (kg)</th><th>mass of aggregation bunker 3 (kg)</th><th>mass of aggregation bunker 4 (kg)</th><th>mass of aggregation bunker 5 (kg)</th><th>mass of aggregation bunker 6 (kg)</th><th>mass of filler (kg)</th><th>mass of bitumen (kg)</th><th>mass of additives (kg)</th><th>Temperature in silo</th><th>Analysis of composition(qualitycontrol)</th><th>Mixture change</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td><a href=" + item.MixtureName + ">download</a></td><td><a href=" + item.TechnicalDataSheet + ">download</a></td><td><a href=" + item.TypeOfAggregates + ">download</a></td><td>" + item.AggragationMinTemp + "</td><td>" + item.AggragationMaxTemp + "</td><td>" + item.AggragationTimeStamp + "</td><td>" + item.BitumenMaxTemp + "</td><td>" + item.BitumenMinTemp + "</td><td>" + item.BitumenTimeStamp + "</td><td>" + item.FillerRecup + "</td><td>" + item.MixingTemp + "</td><td>" + item.MixingTime + "</td><td>" + item.MassOfAggregationBunker1 + "</td><td>" + item.MassOfAggregationBunker2 + "</td><td>" + item.MassOfAggregationBunker3 + "</td><td>" + item.MassOfAggregationBunker4 + "</td><td>" + item.MassOfAggregationBunker5 + "</td><td>" + item.MassOfAggregationBunker6 + "</td><td>" + item.Filler + "</td><td>" + item.Bitumen + "</td><td>" + item.AdditivesKg + "</td><td>" + item.TempSilo + "</td><td>" + item.AnalysisComposition + "</td><td>" + item.MixtureChange + "</td></tr>";
                }

            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableTruck(RoadItEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th><th>Location Transport (every 30 sec)</th><th>ETA</th><th>actual temperature asphalt in truck</th><th>Arrival time at site</th><th>Time and location of attachment to finisher</th><th>Time and location of deattachment finisher</th><th>Actual position(GPS) (return)</th><th>ETA* (return)</th><th>Arrival at plant</th><th>Unforeseen stop ( > 10 min)</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td><td>" + item.ActualPosition + " " + item.ActualPositionTimeStamp + "</td><td>" + item.ETA + " " + item.ETATimeStamp + "</td><td>" + item.Temp + " " + item.TempTruckTimeStamp + "</td><td>" + item.RealArrivalTime + "</td><td>" + item.AttachmentToFinisherPosition + " " + item.AttachmentToFinisherTime + "</td><td>" + item.DeattachmentFinisherPosition + " " + item.DeattachmentFinisherTime + "</td><td>" + item.ActualPositionReturn +" "+item.ActualPositionReturnTimeStamp+ "</td><td>" + item.ETAReturn +" "+item.ETAReturnTimeStamp+ "</td><td>" + item.ArrivalAtPlant + "</td><td>" + item.UnforseenStopLocation + " " +item.UnforseenStopTime + " " + item.UnforseenStopTimeStamp + "</td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableCompactor(RoadItEntities entities)
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Compactor QR code</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td><a href=" + item.QrCodeCompactor + ">link</a></td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableQualityControl(RoadItEntities entities)
        {
            var table = "<h3>Qualitie control</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Compliance mixtures</th><th>Copro samples</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    table += "<tr><td><a href=" + item.ComplianceMixture + ">download</a></td><td><a href=" + item.SamplesCopro + ">download</a></td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }
    }
}
