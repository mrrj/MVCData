using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
