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
        IPeopleService peopleService = new PeopleService();

        /*public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }*/

        public IActionResult PeopleIndex()
        {
            PeopleViewModel peeps = peopleService.All();

            return View(peeps);
        }


    }
}
