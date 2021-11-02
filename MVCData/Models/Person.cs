using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        public City City { get; set; }
        public int CityId { get; set; }

        public List<PersonLanguage> PersonLanguages { get; set; } = new List<PersonLanguage>();
    }
}
