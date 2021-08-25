using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Person
    {
        private int id;
        private string name;
        private int phoneNumber;
        private string city;

     
        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string City { get => city; set => city = value; }
    }
}
