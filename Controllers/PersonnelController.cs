using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Net.Mail;

namespace FirstProjetNRT.Models
{
    public class PersonnelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index2(string searchString)
        {
            XElement doc = XElement.Load("https://richnjembcptedatabase.blob.core.windows.net/nrtct/Personnel1.xml");
            IEnumerable<Personnel> process =

                    from artikel in doc.Descendants("PERSO")
                    where artikel.Element("Matricule").Value.Equals(searchString)
                    

            select new Personnel
                    {
                        NumId = (Int32)artikel.Element("NumId"),
                        Matricule = (string)artikel.Element("Matricule"),
                        Nom = (string)artikel.Element("Nom"),
                        Prenom = (string)artikel.Element("Prenom"),
                        Sexe = (string)artikel.Element("Sexe"),
                        Poste = (string)artikel.Element("Poste"),
                        Departement = (string)artikel.Element("Departement"),
                        Statut = (string)artikel.Element("Statut"),
                        Nationalite = (string)artikel.Element("Nationalite")

            };
                
            
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    var user = process.Where(o => o.Matricule.Equals(searchString) );
                    if (user.Any())
                    {
                       ViewBag.Mat= process.FirstOrDefault().Matricule;
                        ViewBag.Nom = process.FirstOrDefault().Nom;
                        ViewBag.Prenom = process.FirstOrDefault().Prenom;
                        //return RedirectToAction("Index", "Home");
                    }
                    
                    else
                    {
                    ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                        
                }
                else
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }

            }
           

            return View(process);



        }

        [HttpPost]
        public IActionResult Index3(string searchString)
        {
            XElement doc = XElement.Load("https://richnjembcptedatabase.blob.core.windows.net/nrtct/Personnel1.xml");
            IEnumerable<Personnel> process =

                    from artikel in doc.Descendants("PERSO")
                    where artikel.Element("Matricule").Value.Equals(searchString)
                    select new Personnel
                    {
                        NumId = (Int32)artikel.Element("NumId"),
                        Matricule = (string)artikel.Element("Matricule"),
                        Nom = (string)artikel.Element("Nom"),
                        Prenom = (string)artikel.Element("Prenom"),
                        Sexe = (string)artikel.Element("Sexe"),
                        Poste = (string)artikel.Element("Poste"),
                        Departement = (string)artikel.Element("Departement"),
                        Statut = (string)artikel.Element("Statut"),
                        Nationalite = (string)artikel.Element("Nationalite")

                    };
            if (!String.IsNullOrEmpty(searchString))
            {
                var user = process.Where(o => o.Matricule.Equals(searchString));
                if (user.Any())
                {
                    ViewBag.Mat = user.FirstOrDefault().Matricule;
                    ViewBag.Nom = user.FirstOrDefault().Nom;
                    ViewBag.Prenom = user.FirstOrDefault().Prenom;
                   // return RedirectToAction("Index", "Personnel");
                }


               
            }
           
           return View(process);
            
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            XElement doc = XElement.Load("https://richnjembcptedatabase.blob.core.windows.net/nrtct/Personnel1.xml");
            var q = from artikel in doc.Descendants("PERSO")
                    where artikel.Element("Matricule").Value.Contains(searchString)
                    select artikel.Elements().ToList();

            foreach (var r in q)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    if  (r[1].Value== searchString)
                    {
                ViewBag.Mat = r[1].Value;
                ViewBag.Nom = r[2].Value;
                ViewBag.Prenom = r[3].Value;
                       
                        goto exit;
                        //  return RedirectToAction("Index", "Personnel");
                    }
                }
                  
             
            }


        exit:
            
            return View();

           

        }

        
        public IActionResult Affichedata()
        {
            XElement doc = XElement.Load("https://richnjembcptedatabase.blob.core.windows.net/nrtct/Personnel1.xml");
            IEnumerable<Personnel> process =

                    from artikel in doc.Descendants("PERSO")
                   where artikel.Element("Matricule").Value.Equals("")

                    select new Personnel
                    {
                        NumId = (Int32)artikel.Element("NumId"),
                        Matricule = (string)artikel.Element("Matricule"),
                        Nom = (string)artikel.Element("Nom"),
                        Prenom = (string)artikel.Element("Prenom"),
                        Sexe = (string)artikel.Element("Sexe"),
                        Poste = (string)artikel.Element("Poste"),
                        Departement = (string)artikel.Element("Departement"),
                        Statut = (string)artikel.Element("Statut"),
                        Nationalite = (string)artikel.Element("Nationalite")

                    };
            
            ViewBag.List = process;
            ViewData["process"] = process;
            return View(process);
               
        }
        [HttpPost]
        public IActionResult Affichedata(string searchString)
        {
            XElement doc = XElement.Load("https://richnjembcptedatabase.blob.core.windows.net/nrtct/Personnel1.xml");
            IEnumerable<Personnel> process =

                    from artikel in doc.Descendants("PERSO")
                          where artikel.Element("Matricule").Value.Contains(searchString)



                    select new Personnel
                    {
                        NumId = (Int32)artikel.Element("NumId"),
                        Matricule = (string)artikel.Element("Matricule"),
                        Nom = (string)artikel.Element("Nom"),
                        Prenom = (string)artikel.Element("Prenom"),
                        Sexe = (string)artikel.Element("Sexe"),
                        Poste = (string)artikel.Element("Poste"),
                        Departement = (string)artikel.Element("Departement"),
                        Statut = (string)artikel.Element("Statut"),
                        Nationalite = (string)artikel.Element("Nationalite")

                    };

            ViewBag.List = process;
            ViewData["process"] = process;
            return View(process);

        }

    }
}

        
           
            


           
        
   

