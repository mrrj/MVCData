using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;using MVCData.Models.ViewModels;


namespace MVCData.Models.Service
{
    public interface IPeopleService
    {
        
        Person Add(CreatePersonViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
        Person FindBy(int id);
        Person Edit(int id, Person person);
        bool Remove(int id);
        PersonDetailsViewModel FindById(int id);


        public City AddCity(string name, Country country);
        public Country AddCountry(string name);
        public City GetCity(int id);
        public Country GetCountry(int id);
        public List<City> AllCities();
        public List<Country> AllCountries();
        public bool RemoveCountry(int id);
        public bool RemoveCity(int id);
        public Country EditCountry(Country country);

        public City EditCity(City city);
        public Language AddLanguage(string name);

        public void AddLanguageToPerson(Person person, Language language);

    }
}
