using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Person
    {
        //private int id;
        //private string name;
        //private int phoneNumber;
        //private string city;

     
        //public Person(string name, string city, int phoneNumber)
        //{
        //    //this.Id = id;
        //    this.Name = name;
        //    this.City = city;
        //    this.PhoneNumber = phoneNumber;
        //}
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
