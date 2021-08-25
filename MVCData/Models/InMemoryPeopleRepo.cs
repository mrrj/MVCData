using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        public static List<Person> people;
        public static int idCounter;

        public Person Create(string name)
        {
            Person person = new Person(idCounter, name);
            people.Add(person);
            idCounter++;
            return person;
        }

        public bool Delete(Person person)
        {
            if (people.Contains(person))
            {
                people.Remove(person);
                return true;
            }

            return false;
        }

        public List<Person> Read()
        {
            return people;
        
        }

        public Person Read(int id)
        {
            foreach(Person pers in people)
            {
                if(pers.Id == id)
                {
                    return pers;
                }

            }
            throw new Exception("No such person exists");
        }


        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
