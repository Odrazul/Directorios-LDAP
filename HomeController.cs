using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ConexionesDirectorios.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConexionesDirectorios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult SearchUserLDAP()
        {
            string username = "pruebas01";
            string pwd = "pru120!!";
            string strPath = "LDAP://201.217.205.157:389/DC =ita, DC=com";
            string strDomain = "asmws";
            string domainAndUsername = strDomain + @"" + username;

            //System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(strPath, domainAndUsername, pwd);


            List <NodeDataArray> usersDetail = new List<NodeDataArray>()
            {


                 new NodeDataArray()
                 {
                      key=1,
                      name="Faustino Hermo",
                       title ="Gerente"
                 },
                new NodeDataArray()
                 {
                      key=2,
                      name="Luis Llerena",
                       title ="Coordinador",
                       parent=1
                 },
                 new NodeDataArray()
                 {
                      key=3,
                      name="Sheila Hernández",
                       title ="Coordinadora",
                       parent=1
                 },
                 new NodeDataArray()
                 {
                     key=4,
                     name ="Isilio Peluffo",
                     title ="Especialista",
                     parent =2
                 },
                 new NodeDataArray()
                 {
                     key=5, name="Jorge Hernández", title="Especialista", parent=2
                 },
             

            };

            Usuarios users = new Usuarios()
            {
                className = "go.TreeModel",
                nodeDataArray = usersDetail
            };


            return Json(JsonConvert.SerializeObject(users,
                Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                JsonRequestBehavior.AllowGet);


        }
    }
}