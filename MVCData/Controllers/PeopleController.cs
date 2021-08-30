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
        IPeopleService peopleService = new PeopleService(new InMemoryPeopleRepo());

        /*public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }*/

        [HttpGet]
        public IActionResult PeopleIndex()
        {
            PeopleViewModel peeps = peopleService.All();

            return View(peeps);
        }

        /*[HttpPost]
        public IActionResult PeopleIndex(int personId)
        {
            peopleService.Remove(personId);

            return RedirectToAction(nameof(PeopleIndex));
            //return View(peopleService.All());
        }*/

        [HttpPost]
        public IActionResult PeopleIndex(PeopleViewModel peopleVM)
        {
            PeopleViewModel peeps = peopleService.FindBy(peopleVM);
            return View(peeps);
        }

        
        [HttpPost]
        public IActionResult CreatePerson(PeopleViewModel peopleVM)
        {

            CreatePersonViewModel createPerson = 
                new CreatePersonViewModel(peopleVM.PhoneNumber, peopleVM.Name, peopleVM.City);
            if (ModelState.IsValid)
            {
                peopleService.Add(createPerson);
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

    }
}
