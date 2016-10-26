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
                var entities = new RoadItEntities();
                ViewData["Truck"] = GenerateTableTruck(entities);
                ViewData["Compactor"] = GenerateTableCompactor(entities);
                return View();
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page";
                return View();
            }
        }

        public string GenerateTableTruck(RoadItEntities entities)//RoadId nog toevoegen aan view
        {
            var table = "<h3>Transport</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr>";
            table += "<th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th><th>Location Transport (every 30 sec)</th><th>ETA</th><th>Arrival time at site</th><th>Time and location of attachment to finisher</th><th>Deattachment finisher position</th><th>Deattachment finisher time</th><th>Actual position(GPS) (return)</th><th>ETA* (return)</th><th>Arrival at plant</th><th>Unforeseen stop ( > 10 min)</th></tr>";

            foreach (var item in entities.Transporters)
            {
                if ("4" == Session["roadID"].ToString())
                {
                    table += "<tr><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td><td>" + item.ActualPosition + "</td><td>" + item.ETA + "</td><td>" + item.RealArrivalTime + "</td><td>" + "tabel vergeten in DB te plaatsen" + "</td><td>" + item.DeattachmentFinisherPosition + "</td><td>" + item.DeattachmentFinisherTime + "</td><td>" + item.ActualPositionReturn + "</td><td>" + item.ETAReturn + "</td><td>" + item.ArrivalAtPlant + "</td><td>" + item.UnforseenStop + "</td></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableCompactor(RoadItEntities entities)// ID niet in view
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse'><tr>";
            table += "<th>Compactor QR code</th></tr>";

            foreach (var item in entities.Transporters)
            {
                if ("4" == Session["roadID"].ToString())
                {
                    table += "<tr><td><a href=" + "geen toegang maar wel recht op (view)" + ">link</a></tr>";
                }
            }


            table += "</table><br />";

            return table;
        }
    }
}
