using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ConexionesDirectorios.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//comentario de prueba

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

        private void GetAllUsers()
        {
           
            System.DirectoryServices.SearchResultCollection sResulta2 = null;
            System.DirectoryServices.DirectorySearcher dsBuscador = null;
                      
            string path = "LDAP://201.217.205.157:389/DC =ita, DC=com";
            string criterios = "(&(objectClass=user))";
            System.DirectoryServices.DirectoryEntry dEntry = new System.DirectoryServices.DirectoryEntry(path);


            dsBuscador = new System.DirectoryServices.DirectorySearcher(dEntry);
            dsBuscador.Filter = "(&(objectCategory=User)(objectClass=person))";

            sResulta2 = dsBuscador.FindAll();

            foreach (System.DirectoryServices.SearchResult sr in sResulta2)
            {
                // Agregar usuarios a combo
            }
        }


        [HttpPost]
        public JsonResult SearchUserLDAP()
        {
            Boolean userExists = false;
            System.DirectoryServices.SearchResultCollection sResults = null;
            string path = "LDAP://201.217.205.157:389/DC =ita, DC=com";
            string criterios = "(&(objectClass=user))";
            try
            {
                System.DirectoryServices.DirectoryEntry dEntry = new System.DirectoryServices.DirectoryEntry(path);
                System.DirectoryServices.DirectorySearcher dSearcher = new System.DirectoryServices.DirectorySearcher(dEntry);
                dSearcher.Filter = criterios;
                sResults = dSearcher.FindAll();

                int result = sResults.Count;
                if (result >= 1)
                {
                    userExists = true;
                }
                else
                {
                    userExists = false;
                }
            }
            catch (Exception ex)
            {
                return Json(userExists, JsonRequestBehavior.AllowGet);
            }
            return Json(userExists, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult ValidateLdapUser(string user)
        {
            Boolean userExists = false;
            System.DirectoryServices.SearchResultCollection sResults = null;
            string path = "LDAP://Falabella.com";
            string criterios = "(&(objectClass=user)(samAccountName=" + user + "))";
            try
            {
                System.DirectoryServices.DirectoryEntry dEntry = new System.DirectoryServices.DirectoryEntry(path);
                System.DirectoryServices.DirectorySearcher dSearcher = new System.DirectoryServices.DirectorySearcher(dEntry);
                dSearcher.Filter = criterios;
                sResults = dSearcher.FindAll();

                int result = sResults.Count;
                if (result >= 1)
                {
                    userExists = true;
                }
                else
                {
                    userExists = false;
                }
            }
            catch (Exception ex)
            {
                return Json(userExists, JsonRequestBehavior.AllowGet);
            }

            return Json(userExists, JsonRequestBehavior.AllowGet);
        }


    }
}