using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace chachi.Controllers
{
    public class DojoController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult index() 
        {
            Dojo retrieve = HttpContext.Session.GetObjectFromJson<Dojo>("Chachi");
            if(retrieve == null)
            {
                TempData["result"]="";
                Dojo Chachi = new Dojo();
                HttpContext.Session.SetObjectAsJson("Chachi", Chachi);
                retrieve = Chachi;
            }
            ViewBag.result = TempData["result"];

            ViewBag.Happiness = retrieve.Happiness;
            if(retrieve.Happiness < 1)
            {
                ViewBag.Hstat = "red";
            }
            else
            {
                ViewBag.Hstat = "green";
            }

            ViewBag.Fullness = retrieve.Fullness;
            if(retrieve.Fullness < 1)
            {
                ViewBag.Fstat = "red";
            }
            else
            {
                ViewBag.Fstat = "green";
            }

            ViewBag.Energy = retrieve.Energy;
            if(retrieve.Energy < 1)
            {
                ViewBag.Estat = "red";
            }
            else
            {
                ViewBag.Estat = "green";
            }

            ViewBag.Meals = retrieve.Meals;
            if(retrieve.Meals < 1)
            {
                ViewBag.Mstat = "red";
            }
            else
            {
                ViewBag.Mstat = "green";
            }           
            return View();
        }

            [HttpGet]
            [Route("action/{option}")]
            public IActionResult Action(int option)
            {
                Dojo retrieve = HttpContext.Session.GetObjectFromJson<Dojo>("Chachi");
                switch(option)
                {
                    case 1:
                        TempData["result"]=retrieve.Feed();
                        break;
                    case 2:
                        TempData["result"]=retrieve.Play();
                        break;
                    case 3:
                        TempData["result"]=retrieve.Work();
                        break;
                    case 4:
                        TempData["result"]=retrieve.Sleep();
                        break;
                    case 5:
                        TempData["result"]=retrieve.Reset();
                        break;
                    default:
                        break;
                }
                HttpContext.Session.SetObjectAsJson("Chachi", retrieve);
                return RedirectToAction("Index");
            }
          
    }
}
