using MVCData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class PeopleService : IPeopleService
    {
        public Person Add(CreatePersonViewModel person)
        {
            throw new NotImplementedException();
        }

        public PeopleViewModel All()
        {

            if(InMemoryPeopleRepo.people.Count == 0)
            {
                InMemoryPeopleRepo.CreateDefault();
            }

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
            //not sure what this is supposed to do?
            //search should be a string no?
            return new PeopleViewModel();
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
