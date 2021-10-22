using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;
using MVCData.Models.ViewModels;
using MVCData.Data;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCData.Models.Repo;
using MVCData.Models.Service;

namespace MVCData.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        ICountryRepo _countryRepo;
        PeopleRepoDbContext _peopleRepoDbContext;
        
        public PeopleController(IPeopleService peopleService, ICountryRepo countryRepo,
            PeopleRepoDbContext peopleRepoDbContext)
        {
            _peopleService = peopleService;
            _countryRepo = countryRepo;
            _peopleRepoDbContext = peopleRepoDbContext;
        }


        [HttpGet]
        public IActionResult Index()
        {

            PeopleViewModel peopleVM = new PeopleViewModel();

            peopleVM.CreatePerson = new CreatePersonViewModel
            {
                SelectCity = new SelectList(_peopleRepoDbContext.Cities, "CityId", "Name")
            };

            return View();
        }

        [HttpGet]
        public IActionResult ShowPeople()
        {
            PeopleViewModel allPersons = _peopleService.All(); 
            
            return PartialView("_PeopleView", allPersons);  
        }

        [HttpPost]
        public IActionResult Details(int id)
        {

            PersonDetailsViewModel person = _peopleService.FindById(id);
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
            CreatePersonViewModel createPerson = peopleVM.CreatePerson;
            if (ModelState.IsValid)
            {

                _peopleService.Add(createPerson);

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
