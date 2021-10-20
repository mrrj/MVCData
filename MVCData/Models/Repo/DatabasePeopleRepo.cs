using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;

namespace MVCData.Data
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private PeopleRepoDbContext _peopleRepoDbContext;

        public DatabasePeopleRepo(PeopleRepoDbContext peopleRepoDbContext)
        {
            _peopleRepoDbContext = peopleRepoDbContext;
        }

        public Person Create(string name, City city, int phoneNumber)
        {

            Person pers = new Person
            {
                Name = name,
                City = city,
                PhoneNumber = phoneNumber

            };
            city.People.Add(pers);
            _peopleRepoDbContext.Cities.Update(city);
            _peopleRepoDbContext.People.Add(pers);
            _peopleRepoDbContext.SaveChanges();
            return pers;
        }

        public bool Delete(Person person)
        {
            if (_peopleRepoDbContext.People.Contains(person))
            {
                _peopleRepoDbContext.People.Remove(person);
                _peopleRepoDbContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public List<Person> Read()
        {
            return _peopleRepoDbContext.People.ToList();
        }

        public Person Read(int id)
        {
            return _peopleRepoDbContext.People.FirstOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            Person pers =
                (Person)(from p in _peopleRepoDbContext.People
                where p.Id == person.Id
                select p);
            pers.Name = person.Name;
            pers.City = person.City;
            pers.PhoneNumber = person.PhoneNumber;
            _peopleRepoDbContext.SaveChanges();

            return pers;

        }
    }
}
