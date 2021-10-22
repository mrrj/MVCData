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
            //    if (InMemoryPeopleRepo.people.Count == 0)
            //    {
            //        InMemoryPeopleRepo.CreateDefault();

            //foreach (City c in _peopleRepoDbContext.Cities)
            //{
            //    _peopleRepoDbContext.Cities.Remove(c);
            //}
            //foreach (Country c in _peopleRepoDbContext.Countries)
            //{
            //    _peopleRepoDbContext.Countries.Remove(c);
            //}
            //foreach (Person p in _peopleRepoDbContext.People)
            //{
            //    _peopleRepoDbContext.Remove(p);
            //}

            //Country sweden = _peopleService.AddCountry("Sweden");
            //Country norway = _peopleService.AddCountry("Norway");
            //City gothenburg = _peopleService.AddCity("Gothenburg", sweden);
            //City kungsbacka = _peopleService.AddCity("Kungsbacka", sweden);
            //City oslo = _peopleService.AddCity("Oslo", norway);

            //Person eva = new Person
            //{
            //    Name = "Eva",
            //    PhoneNumber = 000000,
            //    City = oslo
            //};

            //_peopleRepoDbContext.People.Add(eva);
            //_peopleRepoDbContext.SaveChanges();

            //Person adam = new Person
            //{
            //    Name = "Adam",
            //    PhoneNumber = 111111,
            //    City = gothenburg
            //};

            //_peopleRepoDbContext.People.Add(adam);
            //_peopleRepoDbContext.SaveChanges();

            PeopleViewModel peopleVM = new PeopleViewModel();

            //peopleVM.CreatePerson = new CreatePersonViewModel
            //{
            //    SelectCity = new SelectList(_peopleRepoDbContext.Cities, "CityId", "Name")
            //};

            //ViewData["Country"] = new SelectList(_peopleRepoDbContext.Countries, "CountryId", "Name");
            //ViewData["City"] = new SelectList(_peopleRepoDbContext.Cities, "CityId", "Name");

            return View(peopleVM);
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


        //[HttpGet]

      
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
