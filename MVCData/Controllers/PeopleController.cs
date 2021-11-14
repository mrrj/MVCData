﻿using Microsoft.AspNetCore.Mvc;
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
        ILanguageRepo _languageRepo;
        IPeopleRepo _peopleRepo;
        PeopleRepoDbContext _peopleRepoDbContext;
        
        public PeopleController(IPeopleService peopleService, ICountryRepo countryRepo, ICityRepo cityRepo,
            ILanguageRepo languageRepo, IPeopleRepo peopleRepo, PeopleRepoDbContext peopleRepoDbContext)
        {
            _peopleService = peopleService;
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
            _languageRepo = languageRepo;
            _peopleRepo = peopleRepo;
            _peopleRepoDbContext = peopleRepoDbContext;
        }


        [HttpGet]
        public IActionResult Index()
        {
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

        public void Init()
        {
        }


        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleVM)
        {
            PeopleViewModel result = _peopleService.FindBy(peopleVM);
            //return View(result);
            return PartialView("_PeopleView", result);
        }

        [HttpPost]
        public IActionResult AddLanguage(int id)
        {
            AddLanguageViewModel addLanguageView = new AddLanguageViewModel()
            {
                PersonId = id,
                AvailableLanguages = _languageRepo.Read()
            };
            return PartialView("_AddLanguageView", addLanguageView);
        }

        [HttpPost]
        public IActionResult AddLanguageToPerson(AddLanguageViewModel addLanguageView)
        {
            Person person = _peopleRepoDbContext.People.Find(addLanguageView.PersonId);
            Language language = _peopleRepoDbContext.Languages.Find(addLanguageView.LanguageId);

            _peopleService.AddLanguageToPerson(person, language);
            return RedirectToAction(nameof(Index));
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



        [HttpGet]
        public IActionResult ShowCountries()
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            peopleView.Countries = _peopleService.AllCountries();

            return PartialView("_CountriesPartialView", peopleView);
        }

        public IActionResult DeleteCountry(int id)
        {
            if (_peopleService.RemoveCountry(id))
            {
                int status = Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(status + ": Country was deleted");
            }
            else
            {
                int status = (int)HttpStatusCode.BadRequest;
                return Json(status + ": Could not find country");
            }

        }
        public IActionResult CreateCountry(PeopleViewModel peopleView)
        {
            CreateCountryViewModel createCountry = peopleView.CreateCountry;

            if (ModelState.IsValid)
            {

                _peopleService.AddCountry(createCountry.Name);

            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult EditCountry(PeopleViewModel peopleView)
        {
            EditCountryViewModel editCountry = peopleView.EditCountry;

            if (ModelState.IsValid)
            {
                Country country = _peopleService.GetCountry(editCountry.Id);
                country.Name = editCountry.NewName;
                _peopleService.EditCountry(country);

            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult ShowCities()
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            peopleView.Cities = _peopleService.AllCities();
            foreach(City city in peopleView.Cities)
            {
                city.Country = _peopleService.GetCountry(city.CountryId);
            }

            return PartialView("_CitiesPartialView", peopleView);
        }

        public IActionResult DeleteCity(int id)
        {
            if (_peopleService.RemoveCity(id))
            {
                int status = Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(status + ": City was deleted");
            }
            else
            {
                int status = (int)HttpStatusCode.BadRequest;
                return Json(status + ": Could not find city");
            }

        }
        public IActionResult CreateCity(PeopleViewModel peopleView)
        {
            CreateCityViewModel createCity = peopleView.CreateCity;

            if (ModelState.IsValid)
            {

                string name = createCity.Name;
                Country country = _peopleService.GetCountry(createCity.CountryId);
                _peopleService.AddCity(name, country);

            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult EditCity(PeopleViewModel peopleView)
        {
            EditCityViewModel editCity = peopleView.EditCity;

            if (ModelState.IsValid)
            {
                City city = _peopleService.GetCity(editCity.Id);
                city.Name = editCity.NewName;
                _peopleService.EditCity(city);

            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult EditPerson(PeopleViewModel peopleView)
        {
            EditPersonViewModel editPerson = peopleView.EditPerson;

            if (ModelState.IsValid)
            {
                Person person = _peopleService.FindBy(editPerson.Id);
                City city = _peopleService.GetCity(editPerson.NewCityId);
                person.City = city;
                person.CityId = editPerson.NewCityId;
                person.Name = editPerson.NewName;
                person.PhoneNumber = editPerson.NewPhoneNumber;
                _peopleService.Edit(editPerson.Id, person);

            }
            return RedirectToAction(nameof(Index));

        }

    }
}
