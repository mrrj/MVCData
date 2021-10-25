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
        ICityRepo _cityRepo;
        PeopleRepoDbContext _peopleRepoDbContext;
        
        public PeopleController(IPeopleService peopleService, ICountryRepo countryRepo, ICityRepo cityRepo,
            PeopleRepoDbContext peopleRepoDbContext)
        {
            _peopleService = peopleService;
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
            _peopleRepoDbContext = peopleRepoDbContext;
        }


        [HttpGet]
        public IActionResult Index()
        {

            //PeopleViewModel peopleVM = new PeopleViewModel();

            //peopleVM.CreatePerson = new CreatePersonViewModel
            //{
            //    SelectCity = new SelectList(_peopleRepoDbContext.Cities, "CityId", "Name")
            //};


            //TestSetup();
            

            return View();
        }

        public IActionResult TestSetup()
        {
            foreach (City c in _peopleRepoDbContext.Cities)
            {
                _peopleRepoDbContext.Cities.Remove(c);
            }

            foreach (Country c in _peopleRepoDbContext.Countries)
            {
                _peopleRepoDbContext.Countries.Remove(c);
            }

            foreach (Person p in _peopleRepoDbContext.People)
            {
                _peopleRepoDbContext.People.Remove(p);
            }

            Country sweden = _countryRepo.Create("Sweden");
            City goteborg = _cityRepo.Create("Göteborg", sweden);
            City halmstad = _cityRepo.Create("Halmstad", sweden);

            return RedirectToAction(nameof(Index));

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
            PeopleViewModel result = _peopleService.FindBy(peopleVM);
            //return View(result);
            return PartialView("_PeopleView", result);
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
