using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class CoProController : Controller
    {
        //
        // GET: /CoPro/

        public ActionResult Index()
        {
            try
            {
                var entities = new sammegf117_roaditEntities();

                Session["arrayOfValues"] = entities.Coproes;

                /*Session["AsphaltMixPlant"] = GenerateTableAsphaltMixPlant(entities);
                Session["Silo"] = GenerateTableSilo(entities);
                Session["AggagaratesBitumenComposition"] = GenerateTableAggagaratesBitumenComposition(entities);
                Session["Truck"] = GenerateTableTruck(entities);
                Session["TruckTemp"] = GenerateTableTruckTemp(entities);
                Session["Compactor"] = GenerateTableCompactor(entities);
                Session["QualityControl"] = GenerateTableQualityControl(entities);*/

                var pageRef = "Manager";
                return RedirectToAction("Index", pageRef);
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page";
                return View();
            }
        }

        /*public string GenerateTableAsphaltMixPlant(sammegf117_roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Asphalt Mixure Plant</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr onClick='showTable1()'><th>Mixture name</th><th>Technical datasheet</th><th>Types of aggregates</th><th>Mixture change</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.AsphaltMixPlantTimestamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr id='tableRow1' class='hide'><td><a href=" + item.MixtureName + ">download</a></td><td><a href=" + item.TechnicalDataSheet + ">download</a></td><td><a href=" + item.TypeOfAggregates + ">download</a></td><td><a href=" + item.MixtureChange + ">download</a></td></tr>";
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
            table += "<tr onClick='showTable2()'><th>Use of filler recuperation</th><th>Mixing temperature</th><th>Mixing time</th><th>Temperature in silo</th><th>Analysis of composition(qualitycontrol)</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.SiloTimpStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.SiloTimpStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr id='tableRow2' class='hide'><td>" + item.FillerRecup + "</td><td>" + item.MixingTemp + "°C</td><td>" + item.MixingTime + "</td><td>" + item.TempSilo + "°C</td><td><a href=" + item.AnalysisComposition + ">download</a></td></tr>";
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
            table += "<tr onClick='showTable3()'><th>Aggregates: min. temperature</th><th>Aggregates: max. temperature</th><th>Bitumen: max. temperature</th><th>Bitumen: min. temperature</th><th>mass of aggregation bunker 1 (kg)</th><th>mass of aggregation bunker 2 (kg)</th><th>mass of aggregation bunker 3 (kg)</th><th>mass of aggregation bunker 4 (kg)</th><th>mass of aggregation bunker 5 (kg)</th><th>mass of aggregation bunker 6 (kg)</th><th>mass of filler (kg)</th><th>mass of bitumen (kg)</th><th>mass of additives (kg)</th></tr>";
            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompositionTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompositionTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr id='tableRow3' class='hide'><td>" + item.AggragationMinTemp + "°C</td><td>" + item.AggragationMaxTemp + "°C</td><td>" + item.BitumenMaxTemp + "°C</td><td>" + item.BitumenMinTemp + "°C</td><td>" + item.MassOfAggregationBunker1 + "</td><td>" + item.MassOfAggregationBunker2 + "</td><td>" + item.MassOfAggregationBunker3 + "</td><td>" + item.MassOfAggregationBunker4 + "</td><td>" + item.MassOfAggregationBunker5 + "</td><td>" + item.MassOfAggregationBunker6 + "</td><td>" + item.Filler + "</td><td>" + item.Bitumen + "</td><td>" + item.AdditivesKg + "</td>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }

        public string GenerateTableTruck(sammegf117_roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr onClick='showTable4()'>";
            table += "<th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th></tr>";

            foreach (var item in entities.Coproes)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr id='tableRow4' class='hide'><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableTruckTemp(sammegf117_roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport temperatuur</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr onClick='showTable5()'>";
            table += "<th>actual temperature asphalt in truck</th></tr>";

            foreach (var item in entities.AsphaltProcucers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TempTruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TempTruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr id='tableRow5' class='hide'><td> Temp: " + item.Temp + "°C Date: " + item.TempTruckTimeStamp + "</td></tr>";
                    }
                }
            }
            table += "</table><br />";

            return table;
        }

        public string GenerateTableCompactor(sammegf117_roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr onClick='showTable6()'>";
            table += "<th>Compactor QR code</th></tr>";

            foreach (var item in entities.Coproes)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompactorTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompactorTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        string name = "https://chart.googleapis.com/chart?chs=150x150&cht=qr&chl=" + item.QrCodeCompactor.ToString();
                        table += "<tr id='tableRow6' class='hide'><td><img src='" + name + "' alt='QR code'></td></tr>";
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
            table += "<tr onClick='showTable7()'><th>Copro samples</th><th>Extra tests asked by client</th></tr>";

            foreach (var item in entities.Coproes)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.QualtityTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.QualtityTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr id='tableRow7' class='hide'><td><a href=" + item.SamplesCopro + ">download</a></td><td><a href=" + item.ExtraTestsAskedBijClient + ">download</a></td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }*/
    }
}
