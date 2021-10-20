using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
    }
}
