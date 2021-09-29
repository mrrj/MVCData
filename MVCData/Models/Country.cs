using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Country
    {
        private string name;
        private List<City> cities;

        public Country(string name)
        {
            this.name = name;
        }
    }
}
