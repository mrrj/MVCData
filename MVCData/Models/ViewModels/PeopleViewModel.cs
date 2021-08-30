using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;

namespace MVCData.Models.ViewModels
{
    public class PeopleViewModel
    {
        private List<Person> people = new List<Person>();
        private string searchPhrase;
        int phoneNumber;
        string name;
        string city;

        public string SearchPhrase { get => searchPhrase; set => searchPhrase = value; }
        public List<Person> People { get => people; set => people = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
    }
}
