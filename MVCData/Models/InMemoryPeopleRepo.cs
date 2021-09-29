using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        public static List<Person> people = new List<Person>();
        public static int idCounter = 0;

        public Person Create(string name, string city, int phoneNumber)
        {
            throw new NotImplementedException();
        }


        //public static void CreateDefault()
        //{
        //    Person p1 = new Person(idCounter, "Anna Svensson", "Gothenburg", 1234567);
        //    idCounter++;
        //    Person p2 = new Person(idCounter, "Eva Svensson", "Stockholm", 1234568);
        //    idCounter++;
        //    Person p3 = new Person(idCounter, "Knut Knutsson", "Gothenburg", 1234569);
        //    idCounter++;
        //    people.Add(p1);
        //    people.Add(p2);
        //    people.Add(p3);

        //}



        //public Person Create(string name, string city, int phoneNumber)
        //{
        //    Person person = new Person(idCounter, name, city, phoneNumber);
        //    people.Add(person);
        //    idCounter++;
        //    return person;
        //}

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
