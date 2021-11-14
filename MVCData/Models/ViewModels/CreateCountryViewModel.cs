using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
