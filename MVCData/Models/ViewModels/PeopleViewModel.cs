using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCData.Models;

namespace MVCData.Models.ViewModels
{
    public class PeopleViewModel
    {
        private List<Person> people = new List<Person>();
        private string searchPhrase;
        private CreatePersonViewModel createPerson;


        public string SearchPhrase { get => searchPhrase; set => searchPhrase = value; }
        public List<Person> People { get => people; set => people = value; }
        public CreatePersonViewModel CreatePerson { get => createPerson; set => createPerson = value; }

        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }

        public CreateCountryViewModel CreateCountry {get;set;}
        public CreateCityViewModel CreateCity { get; set; }

        public EditCountryViewModel EditCountry { get; set; }
        public EditCityViewModel EditCity { get; set; }

        public EditPersonViewModel EditPerson { get; set; }

    }


}
