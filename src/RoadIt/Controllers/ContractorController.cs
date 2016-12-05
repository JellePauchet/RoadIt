﻿using System;
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
                var entities = new roaditEntities();
                Session["Planning"] = GenerateTablePlanning(entities);
                Session["AsphaltMixPlant"] = GenerateTableAsphaltMixPlant(entities);
                Session["Truck"] = GenerateTableTruck(entities);
                Session["Finisher"] = GenerateTableFinisher(entities);
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

        public string GenerateTablePlanning(roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Planning</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Asphalt layer thickness</th><th>Amount of squares metres planned</th><th>Estimated amount of asphalt per 24 hours (ton) per asphalt type</th></tr>";

            foreach (var item in entities.ContractorVieuws)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.PlanningTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.PlanningTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.LayerThickness + "</td><td>" + item.Surface + "</td><td>" + item.TonPerDay + "</td></tr>";
                    }
                }
            }
            table += "</table><br />";
            return table;
        }

        public string GenerateTableAsphaltMixPlant(roaditEntities entities) //RoadId nog toevoegen aan view
        {
            var table = "<h3>Asphalt Mixure Plant</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Mixture name</th><th>Technical datasheet</th></tr>";

            foreach (var item in entities.ContractorVieuws)
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

        public string GenerateTableTruck(roaditEntities entities)//RoadId nog toevoegen aan view, geen toegang tot actualTemp via view, Time and location of attachment to finisher vergeten in DB
        {
            var table = "<h3>Transport</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Truck ID</th><th>Departure Time</th><th>Mass (Ton)</th><th>Location Transport (every 30 sec)</th><th>ETA</th><th>actual temperature asphalt in truck</th><th>Arrival time at site</th><th>Time and location of attachment to finisher</th><th>Time and location of deattachment finisher</th><th>Actual position(GPS) (return)</th><th>ETA* (return)</th><th>Arrival at plant</th><th>Unforeseen stop ( > 10 min)</th></tr>";

            foreach (var item in entities.ContractorVieuws)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.TruckLicensPlate + "</td><td>" + item.DepartureTime + "</td><td>" + item.MassTruck + "</td><td>" + item.ActualPosition + " " + item.ActualPositionTimeStamp + "</td><td>" + item.ETA + " " + item.ETATimeStamp + "</td><td>" + item.Temp + " " + item.TempTruckTimeStamp + "</td><td>" + item.RealArrivalTime + "</td><td>" + item.AttachmentToFinisherTime + " " + item.AttachmentToFinisherPosition + "</td><td>" + item.DeattachmentFinisherTime + " " + item.DeattachmentFinisherPosition + "</td><td>" + item.ActualPositionReturn + " " + item.ActualPositionReturnTimeStamp + "</td><td>" + item.ETAReturn + " " + item.ETAReturnTimeStamp + "</td><td>" + item.ArrivalAtPlant + "</td><td>" + item.StopTimeUnforseenStop + " " + item.StopLocationUnforseenStop + " " + item.UnforseenStopTimeStamp + "</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableFinisher(roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Finisher</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Speed</th><th>Width</th><th>Angle Left</th><th>Angle Right</th><th>Thickness of the layer (Left)</th><th>Thickness of the layer (Middle)</th><th>Thickness of the layer (Right)</th><th>Tranverse slope</th><th>location and time of stop</th><th>precipitation</th><th>Air temperature</th><th>Wind speed</th><th>Air humidity</th><th>Asphalt temperature after finisher</th></tr>";

            foreach (var item in entities.ContractorVieuws)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.FinisherTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.FinisherTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td>" + item.Speed + "</td><td>" + item.Width + "</td><td>" + item.LeftAngle + "</td><td>" + item.RightAngle + "</td><td>" + item.LeftTickness + "</td><td>" + item.MiddelThickness + "</td><td>" + item.RightThickness + "</td><td>" + item.TranverseSlope + "</td><td>" + item.StopLocationLTS + " " + item.StopTimeLTS + " " + item.StopTimeStamp + "</td><td>" + item.Precipation + "</td><td>" + item.TempWeather + " " + item.WeatherTempTimeStamp + "</td><td>" + item.WindSpeed + " " + item.WindTimeStamp + "</td><td>" + item.AirHumidity + " " + item.AirHumidityTimeStamp + "</td><td>" + item.AsphaltTempAfterFinisherIrScanOrThermo + "</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableCompactor(roaditEntities entities)// batchId niet in view
        {
            var table = "<h3>Compactor</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'><tr>";
            table += "<th>Compactor QR code</th><th>Number of roller compactor passages (+temperature)</th><th>Location of vibration(+temperature)</th><th>ColorCodeID (Finisher and Compactor location)</th><th>Speed of the roller compactor</th><th>Location compactor</th></tr>";

            foreach (var item in entities.ContractorVieuws)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.CompactorTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.CompactorTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        string name = "https://chart.googleapis.com/chart?chs=150x150&cht=qr&chl=" + item.QrCodeCompactor.ToString();
                        table += "<tr><td><img src='" + name + "' alt='QR code'></td><td><a href=" + item.NumberOfRollerCompactorPassages + ">link</a></td><td><a href=" + item.LocationOfVibration + ">link</a></td><td>Finisher: " + item.GPSFinisher + " Compactor: " + item.GPSCompactor + "</td><td>" + item.SpeedOfRollerCompactor + "</td><td>" + item.GPSCompactor + "</td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }

        public string GenerateTableQualityControl(roaditEntities entities)
        {
            var table = "<h3>Qualitie control</h3>";
            table += "<table class='table table-bordered table-hover table-inverse table-responsive'>";
            table += "<tr><th>Compliance mixtures</th><th>Copro samples</th><th>Asphalt temperature (IR scanner)</th><th>Aspahlt temperature (thermometer)</th><th>Density measurements on field</th><th>Cores</th><th>Lengthwise flatness</th><th>Skidreskstance</th><th>IRI</th><th>Extra tests asked by client</th></tr>";

            foreach (var item in entities.ContractorVieuws)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.QualtityTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.QualtityTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        table += "<tr><td><a href=" + item.ComplianceMixture + ">download</a></td><td><a href=" + item.SamplesCopro + ">download</a></td><td>" + item.AsphaltTempAfterFinisherIrScanOrThermo + "</td><td>" + item.Temp + "</td><td><a href=" + item.DensityOfField + ">download</a></td><td><a href=" + item.Cores + ">download</a></td><td><a href=" + item.LengthwiseFlatness + ">download</a></td><td><a href=" + item.Skidresistance + ">download</a></td><td><a href=" + item.Iri + ">download</a></td><td><a href=" + item.ExtraTestsAskedBijClient + ">download</a></td></tr>";
                    }
                }
            }


            table += "</table><br />";

            return table;
        }
    }
}
