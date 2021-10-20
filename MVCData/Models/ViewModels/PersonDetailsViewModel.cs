using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models.ViewModels
{
    public class PersonDetailsViewModel
    {
        public Person Person { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }

    }
}
