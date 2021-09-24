using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Models;

namespace MVCData.Data
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleRepoDbContext _peopleRepoDbContext;

        public DatabasePeopleRepo(PeopleRepoDbContext peopleRepoDbContext)
        {
            _peopleRepoDbContext = peopleRepoDbContext;
        }

        public Person Create(string name, string city, int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            return _peopleRepoDbContext.People.ToList();
        }

        public Person Read(int id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
