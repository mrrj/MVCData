using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public interface IPeopleRepo
    {

        Person Create(string name, City city, int phoneNumber);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool Delete(Person person);


    }
}
