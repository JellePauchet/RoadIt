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
            var entities = new sammegf117_roaditEntities();

            try
            {
                ViewBag.error = "";
                Session["Planning"] = GenerateTablePlanning(entities);
                Session["AsphaltMixPlant"] = GenerateTableAsphaltMixPlant(entities);
                Session["Silo"] = GenerateTableSilo(entities);
                Session["AggagaratesBitumenComposition"] = GenerateTableAggagaratesBitumenComposition(entities);
                Session["Truck"] = GenerateTableTruck(entities);
                Session["TruckTemp"] = GenerateTableTruckTemp(entities);
                Session["TruckStop"] = GenerateTableTruckStops(entities);
                Session["Position"] = GenerateTableTruckLocation(entities);
                Session["PositionReturn"] = GenerateTableTruckLocationReturn(entities);
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
            table += "<tr><th>Estimated amount of asphalt per 24 hours (ton) per asphalt type</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.PlanningTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.PlanningTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.TonPerDay + "</td></tr>";
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
            table += "<tr><th>Mixture name</th><th>Technical datasheet</th><th>Types of aggregates</th><th>Mixture change</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td><a href=" + item.MixtureName + ">download</a></td><td><a href=" + item.TechnicalDataSheet + ">download</a></td><td><a href=" + item.TypeOfAggregates + ">download</a></td><td><a href =" + item.MixtureChange + ">download</a></td></tr>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }

        public string GenerateTableSilo(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Silo informatie</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Use of filler recuperation</th><th>Mixing temperature</th><th>Mixing time</th><th>Temperature in silo</th><th>Analysis of composition(qualitycontrol)</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.SiloTimpStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.SiloTimpStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.FillerRecup + "</td><td>" + item.MixingTemp + "°C</td><td>" + item.MixingTime + "</td><td>" + item.TempSilo + "°C</td><td><a href=" + item.AnalysisComposition + ">download</a></td></tr>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }

        public string GenerateTableAggagaratesBitumenComposition(sammegf117_roaditEntities entities)
        {
            var table = "<h3>Aggragates, bitumen en compositie</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Aggregates: min. temperature</th><th>Aggregates: max. temperature</th><th>Bitumen: max. temperature</th><th>Bitumen: min. temperature</th><th>mass of aggregation bunker 1 (kg)</th><th>mass of aggregation bunker 2 (kg)</th><th>mass of aggregation bunker 3 (kg)</th><th>mass of aggregation bunker 4 (kg)</th><th>mass of aggregation bunker 5 (kg)</th><th>mass of aggregation bunker 6 (kg)</th><th>mass of filler (kg)</th><th>mass of bitumen (kg)</th><th>mass of additives (kg)</th></tr>";
            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompositionTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompositionTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.AggragationMinTemp + "°C</td><td>" + item.AggragationMaxTemp + "°C</td><td>" + item.BitumenMaxTemp + "°C</td><td>" + item.BitumenMinTemp + "°C</td><td>" + item.MassOfAggregationBunker1 + "</td><td>" + item.MassOfAggregationBunker2 + "</td><td>" + item.MassOfAggregationBunker3 + "</td><td>" + item.MassOfAggregationBunker4 + "</td><td>" + item.MassOfAggregationBunker5 + "</td><td>" + item.MassOfAggregationBunker6 + "</td><td>" + item.Filler + "</td><td>" + item.Bitumen + "</td><td>" + item.AdditivesKg + "</td>";
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

        public string GenerateTableCompactor(sammegf117_roaditEntities entities)
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Compactor QR code</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompactorTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompactorTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        string name = "https://chart.googleapis.com/chart?chs=150x150&cht=qr&chl=" + item.QrCodeCompactor.ToString();
                        table += "<tr><td><img src='" + name + "' alt='QR code'></td></tr>";
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
            table += "<tr><th>Compliance mixtures</th><th>Copro samples</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.QualtityTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.QualtityTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td><a href=" + item.ComplianceMixture + ">download</a></td><td><a href=" + item.SamplesCopro + ">download</a></td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }
    }
}
