using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;
using MVCData.Models.ViewModels;
using System.Net;
using System.Net.Mime;

namespace MVCData.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (InMemoryPeopleRepo.people.Count == 0)
            {
                InMemoryPeopleRepo.CreateDefault();
            }
            return View(_peopleService.All());
        }

        [HttpGet]
        public IActionResult ShowPeople()
        {
            PeopleViewModel allPersons = _peopleService.All(); 
            Console.WriteLine("hello ShowPeople");
            
            return PartialView("_PeopleView", allPersons);  
        }

        [HttpPost]
        public IActionResult Details(int id)
        {

            Person person = _peopleService.FindBy(id);
            return PartialView("_PersonView", person);
        }


        public IActionResult Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                int status = Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(status + ": Person was deleted");
            }
            else
            {
                int status = (int)HttpStatusCode.BadRequest;
                return Json(status + ": Could not find person");
            }

        }


        //public IActionResult Remove(int id)
        //{
        //    if (_peopleService.Remove(id)) return RedirectToAction(nameof(Index));
        //    else return View(_peopleService.All());
        //}


        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleVM)
        {
            return View(_peopleService.FindBy(peopleVM));
        }


        [HttpPost]
        public IActionResult CreatePerson(PeopleViewModel peopleVM)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(peopleVM.CreatePerson);

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
