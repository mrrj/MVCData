using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;
using MVCData.Models.ViewModels;

namespace MVCData.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleRepo _peopleRepo;
        IPeopleService _peopleService;

        public PeopleController(IPeopleRepo peopleRepo, IPeopleService peopleService)
        {
            this._peopleRepo = peopleRepo;
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

        public IActionResult Details(int id)
        {

            Person person = _peopleService.FindBy(id);
            return PartialView("_PersonView", person);
        }


        public IActionResult Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                //return status code
            }
            else
            {
                //return status code
            }

            return RedirectToAction(nameof(Index));

        }


        //public IActionResult Remove(int id)
        //{
        //    if (_peopleService.Remove(id)) return RedirectToAction(nameof(Index));
        //    else return View(_peopleService.All());
        //}


        //[HttpPost]
        //public IActionResult Index(PeopleViewModel peopleVM)
        //{
        //    return View(_peopleService.FindBy(peopleVM));
        //}


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
