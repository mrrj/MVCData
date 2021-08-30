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

        [HttpGet]
        public IActionResult PeopleIndex()
        {
            if (InMemoryPeopleRepo.people.Count == 0)
            {
                InMemoryPeopleRepo.CreateDefault();
            }

            return View(peopleService.All());
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            peopleService.Remove(id);
            return RedirectToAction(nameof(PeopleIndex));

        }

        [HttpPost]
        public IActionResult PeopleIndex(PeopleViewModel peopleVM)
        {
            return View(peopleService.FindBy(peopleVM));
        }

        
        [HttpPost]
        public IActionResult CreatePerson(PeopleViewModel peopleVM)
        {
            if (ModelState.IsValid)
            {
                peopleService.Add(peopleVM.CreatePerson);

            }
            return RedirectToAction(nameof(PeopleIndex));

        }

    }
}
