using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class TransporterController : Controller
    {
        //
        // GET: /Transporter/

        public ActionResult Index()
        {
            try
            {
                var entities = new sammegf117_roaditEntities();
                Session["Truck"] = GenerateTableTruck(entities);
                Session["TruckStop"] = GenerateTableTruckStops(entities);
                Session["Position"] = GenerateTableTruckLocation(entities);
                Session["PositionReturn"] = GenerateTableTruckLocationReturn(entities);
                Session["Compactor"] = GenerateTableCompactor(entities);
                return View();
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page";
                return View();
            }
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
                        table += "<tr><td>" + item.ActualPosition + " " + item.ActualPositionTimeStamp + "</td><td>" + item.ETA +  "</td></tr>";
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

        public string GenerateTableCompactor(sammegf117_roaditEntities entities)// ID niet in view
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Compactor QR code</th></tr>";

            foreach (var item in entities.Truckers)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompactorTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompactorTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        string name = "https://chart.googleapis.com/chart?chs=150x150&cht=qr&chl=" + item.QrCodeCompactor.ToString();
                        table += "<tr><td><img src='" + name + "' alt='QR code'></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }
    }
}
