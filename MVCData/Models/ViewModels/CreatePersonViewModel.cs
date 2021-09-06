using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MVCData.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        int phoneNumber;
        string name;
        string city;

        //[MinLength(5)]
        //[MaxLength(12)]
        //public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        //[Required]
        //[StringLength(100)]
        //public string Name { get => name; set => name = value; }
        //[Required]
        //[StringLength(50)]
        //public string City { get => city; set => city = value; }

        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public string Name { get => name; set => name = value; }

        public string City { get => city; set => city = value; }

    }
}
