using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;

namespace MVCData.ViewModels
{
    public class PeopleViewModel
    {
        List<Person> people;
        string searchPhrase;

        public string SearchPhrase { get => searchPhrase; set => searchPhrase = value; }

    }
}
