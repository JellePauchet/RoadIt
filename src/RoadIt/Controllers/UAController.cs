using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoadIt.Models;

namespace RoadIt.Controllers
{
    public class UAController : Controller
    {
        //
        // GET: /UA/

        public ActionResult Index()
        {
            try
            {
                var entities = new sammegf117_roaditEntities();
                ManagerController manager = new ManagerController(GetTotalList(entities), GetTransportList(entities), GetPlantList(entities), GetMixtureList(entities), GetSpecArray(entities));
                return RedirectToAction("Index", "Manager");
            }
            catch
            {
                ViewBag.error = "You are not authorized to view this page";
                return RedirectToAction("Index", "Manager");
            }
        }

        public List<string[]> GetTransportList(sammegf117_roaditEntities entities)
        {
            List<string[]> TransportList = new List<string[]>();
            foreach (var item in entities.UAs)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        string[] arrayValue = new string[7];
                        arrayValue[0] = item.TruckLicensPlate;
                        arrayValue[1] = item.CentralNameShort;
                        arrayValue[2] = item.MixtureName;
                        arrayValue[3] = item.MassTruck.ToString();
                        arrayValue[4] = item.Temp.ToString();
                        arrayValue[5] = item.FinicherId.ToString();
                        arrayValue[6] = item.GPSFinisher;

                        TransportList.Add(arrayValue);
                    }
                }
            }

            return TransportList;
        }

        public List<string[]> GetTotalList(sammegf117_roaditEntities entities)
        {
            List<string[]> TotalList = new List<string[]>();
            foreach (var item in entities.UAs)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        string[] arrayValue = new string[2];
                        arrayValue[0] = item.CentralNameShort;
                        arrayValue[1] = item.MassTruck.ToString();

                        TotalList.Add(arrayValue);
                    }
                }
            }
            return TotalList;
        }

        public List<string[]> GetPlantList(sammegf117_roaditEntities entities)
        {
            List<string[]> PlantList = new List<string[]>();
            foreach (var item in entities.UAs)
            {
                string[] arrayValue = new string[2];
                arrayValue[0] = item.CentralNameShort;
                arrayValue[1] = item.CentralName;

                PlantList.Add(arrayValue);
            }
            return PlantList;
        }

        public List<string[]> GetMixtureList(sammegf117_roaditEntities entities)
        {
            List<string[]> MixtureList = new List<string[]>();
            foreach (var item in entities.UAs)
            {
                string[] arrayValue = new string[3];
                arrayValue[0] = item.MixtureName;
                arrayValue[1] = item.BatchMinTemp.ToString();
                arrayValue[2] = item.BatchMaxTemp.ToString();

                MixtureList.Add(arrayValue);
            }
            return MixtureList;
        }

        public string[] GetSpecArray(sammegf117_roaditEntities entities)
        {
            string[] arrayValue = new string[5];
            foreach (var item in entities.UAs)
            {
                if (item.RoadId.ToString() == Session["roadID"].ToString())
                {
                    if (DateTime.Parse(item.TruckTimeStamp.ToString()) >= DateTime.Parse(Session["StartDate"].ToString()) && DateTime.Parse(item.TruckTimeStamp.ToString()) <= DateTime.Parse(Session["StopDate"].ToString()))
                    {
                        arrayValue[0] = Session["roadID"].ToString();
                        arrayValue[1] = item.LayerType;
                        arrayValue[2] = item.MixtureName;
                        arrayValue[3] = item.BatchMinTemp.ToString();
                        arrayValue[4] = item.BatchMaxTemp.ToString();
                        break;
                    }
                }
            }
            return arrayValue;
        }
    }
}
