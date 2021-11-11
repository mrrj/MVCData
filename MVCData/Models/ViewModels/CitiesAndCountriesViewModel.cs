using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.ViewModels
{
    public class CitiesAndCountriesViewModel
    {
        public List<Country> Countries { get; set; }    
        public List<City> Cities { get; set; }
                             
    }
}
