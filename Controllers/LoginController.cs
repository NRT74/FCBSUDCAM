using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace FirstProjetNRT.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            List<Login> Login = new List<Login>()
                {
                     new Login
                {
                    Nom = "Njembele",
                    Password= "Etales",
                    Email ="richardthierynjembele@gmail.com"
                },
                     new Login
                {

                    Nom = "Awona",
                    Password= "rilefys",
                    Email ="cyrillejosephaccess2022@gmail.com"
                },
                new Login
                {

                    Nom = "Serges",
                    Password= "passw@rd",
                    Email ="mbengfys@yahoo.fr"
                }
                };
            ViewBag.List = Login;
            ViewData["Login"] = Login;
            return View(Login);

        }

        [HttpPost]
        public IActionResult Index(string searchName, string searchPwd)
        {
            IEnumerable<Login> Login =new List<Login>
            {
                  new Login
                {
                    Nom = "Njembele",
                    Password= "Etales",
                    Email ="richardthierynjembele@gmail.com"
                },
                    
                new Login
                {
                    Nom = "DBPC1",
                    Password= "DBPC1",
                    Email =""
                },
                new Login
                {
                    Nom = "DBPC2",
                    Password= "DBPC2",
                    Email =""
                },
                new Login
                {
                    Nom = "DBPC3",
                    Password= "DBPC3",
                    Email =""
                },
                new Login
                {
                    Nom = "DBPC4",
                    Password= "DBPC4",
                    Email =""
                },
                new Login
                {

                  Nom = "DBPC5",
                    Password= "DBPC5",
                    Email =""
                },
                new Login
                {
                    Nom = "DBPC6",
                    Password= "BBPC6",
                    Email =""
                },
                 new Login
                {
                    Nom = "DBPC7",
                    Password= "BBPC7",
                    Email =""
                },
                  new Login
                {
                    Nom = "DBPC8",
                    Password= "BBPC8",
                    Email =""
                }
            };


            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(searchName))
                {
                    var user = Login.Where(o => o.Nom.Equals(searchName) && o.Password.Equals(searchPwd));
                    if (user.Any())
                        return RedirectToAction("Affichedata", "Personnel");
                    else
                        ModelState.AddModelError("", "The password provided is incorrect.");
                }
                else
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }

            }

                
           
            return View();


        }

        


    }
}
