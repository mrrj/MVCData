using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;

namespace MVCData.Models.ViewModels
{
    public class PeopleViewModel
    {
        private List<Person> people;
        private string searchPhrase;

        public string SearchPhrase { get => searchPhrase; set => searchPhrase = value; }
        public List<Person> People { get => people; set => people = value; }
    }
}
