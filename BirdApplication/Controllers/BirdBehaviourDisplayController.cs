using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirdApplication.Models;
using BirdApplication.BirdClass;
namespace BirdApplication.Controllers
{
    public class BirdBehaviourDisplayController : Controller
    {
        // GET: BirdBehaviourDisplay
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(BirdModel birdModel,string submit,string birdSearch)
        {
            if (submit == "AddBird")
            {
                if (birdModel.BirdName == "" || birdModel.BirdName==null)
                    TempData["BirdNameEmpty"] = $"BirdName is empty";
                else
                {   if (birdModel.BirdBehaviourList!=null)
                    {
                        Session[birdModel.BirdName] = birdModel.BirdBehaviourList;
                        TempData["BirdNameAdded"] = $"{birdModel.BirdName} added succesfullly";
                        return RedirectToAction("Index");
                    }
                    else
                        TempData["EmptyBehaviour"] = "Choose atleast one behaviour from list";
                }
            }
            if(submit=="Search")
            {
                if (birdSearch != "" && Session!=null)
                {
                    foreach (string bird in Session)
                    {
                        if (bird.ToUpper() == birdSearch.ToUpper())
                        {
                           IBirdBehaviour b1 = new Bird(bird);
                            BirdModel birds=b1.BirdDetail((List<string>)Session[bird]);
                            ViewBag.BirdBehaviour = birds.BirdBehaviourList;
                            ViewBag.BirdName = birds.BirdName;
                            break;
                        }
                    }
                }
                else
                    ViewBag.SearchBird = $"You did not enter  bird name or bird list";
            }
            return View();
        }
    }
}