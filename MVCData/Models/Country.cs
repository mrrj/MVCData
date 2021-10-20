using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
        
    }
}
