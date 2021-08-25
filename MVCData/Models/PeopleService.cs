using MVCData.ViewModels;
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
            PeopleViewModel people = new PeopleViewModel();
            return people;
        }

        public Person Edit(int id, Person person)
        {
            foreach(Person pers in InMemoryPeopleRepo.people)
            {
                if(pers.Id == id)
                {
                    //do stuff?
                    return pers;
                }
            }

            throw new Exception("No such person exists");
        }


        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            throw new NotImplementedException();
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
