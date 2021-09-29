using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Person
    {
        private int id;
        private string name;
        private int phoneNumber;
        private City city;

     
        public Person(string name, City city, int phoneNumber)
        {
            this.Name = name;
            this.City = city;
            this.PhoneNumber = phoneNumber;
        }
        [Key]
        public int Id { get => id; set => id = value; }

        [Required]
        public string Name { get => name; set => name = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public City City { get => city; set => city = value; }
    }
}
