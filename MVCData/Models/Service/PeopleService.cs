using MVCData.Data;
using MVCData.Models.ViewModels;
using MVCData.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCData.Models
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        ICountryRepo _countryRepo;
        ICityRepo _cityRepo;
        

        public PeopleService(IPeopleRepo peopleRepo, ICountryRepo countryRepo, ICityRepo cityRepo)
        {
            _peopleRepo = peopleRepo;
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
        }
        public Person Add(CreatePersonViewModel person)
        {

            return _peopleRepo.Create(person.Name, person.City, person.PhoneNumber) ;
        }

        public City AddCity(string name, Country country)
        {
            return _cityRepo.Create(name, country);
        }

        public Country AddCountry(string name)
        {
            return _countryRepo.Create(name);
        }
        public PeopleViewModel All()
        {

            PeopleViewModel people = new PeopleViewModel
            {
                People = _peopleRepo.Read()
            };
            return people;
        }

        public Person Edit(int id, Person person)
        {
            foreach(Person pers in _peopleRepo.Read())
            {
                if(pers.Id == id)
                {
                    //pers.Name = person.Name;
                    //pers.PhoneNumber = person.PhoneNumber;
                    //pers.City = person.City;
                    //return pers;
                    return _peopleRepo.Update(person);
                }
            }

            throw new Exception("No such person exists");
        }


        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            PeopleViewModel searchResult = new PeopleViewModel();
            foreach (Person pers in _peopleRepo.Read())
            {
                City city = GetCity(pers.CityId);
                if (pers.Name.Contains(search.SearchPhrase) || city.Name.Contains(search.SearchPhrase))
                {
                    searchResult.People.Add(pers);
                }
            }
            return searchResult;
        }

        public Person FindBy(int id)
        {
            foreach (Person pers in _peopleRepo.Read())
            {
                if (pers.Id == id)
                {
                    return pers;
                }
            }

            throw new Exception("No such person exists");
        }

        public PersonDetailsViewModel FindById(int id)
        {
            Person pers = _peopleRepo.Read(id);
            PersonDetailsViewModel personDetails = new PersonDetailsViewModel
            {
                Person = pers,
                City = GetCity(pers.CityId),
                Country = GetCountry(pers.City.CountryId)
            };

            return personDetails;
        }

        public bool Remove(int id)
        {
            foreach (Person pers in _peopleRepo.Read())
            {
                if (pers.Id == id)
                {
                    _peopleRepo.Delete(pers);
                    return true;
                }
            }

            return false;
        }

        public City GetCity(int id)
        {
            return _cityRepo.Read(id);
        }
        public Country GetCountry(int id)
        {
            return _countryRepo.Read(id);
        }
    }
}
