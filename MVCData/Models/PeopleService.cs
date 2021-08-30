using MVCData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            this.peopleRepo = peopleRepo;
        }
        public Person Add(CreatePersonViewModel person)
        {
            return peopleRepo.Create(person.Name, person.City, person.PhoneNumber);
        }

        public PeopleViewModel All()
        {

            PeopleViewModel people = new PeopleViewModel
            {
                People = InMemoryPeopleRepo.people
            };
            return people;
        }

        public Person Edit(int id, Person person)
        {
            foreach(Person pers in InMemoryPeopleRepo.people)
            {
                if(pers.Id == id)
                {
                    pers.Name = person.Name;
                    pers.PhoneNumber = person.PhoneNumber;
                    pers.City = person.City;
                    return pers;
                }
            }

            throw new Exception("No such person exists");
        }


        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            PeopleViewModel searchResult = new PeopleViewModel();
            foreach (Person pers in InMemoryPeopleRepo.people)
            {
                if (pers.Name.Contains(search.SearchPhrase) || pers.City.Contains(search.SearchPhrase))
                {
                    searchResult.People.Add(pers);
                }
            }
            return searchResult;
        }

        public Person FindBy(int id)
        {
            foreach (Person pers in InMemoryPeopleRepo.people)
            {
                if (pers.Id == id)
                {
                    return pers;
                }
            }

            throw new Exception("No such person exists");
        }

        public bool Remove(int id)
        {
            foreach (Person pers in InMemoryPeopleRepo.people)
            {
                if (pers.Id == id)
                {
                    InMemoryPeopleRepo.people.Remove(pers);
                    return true;
                }
            }

            return false;
        }
    }
}
